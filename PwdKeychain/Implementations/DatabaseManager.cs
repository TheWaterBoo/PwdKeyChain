﻿using PwdKeychain.Interfaces;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Text;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class DatabaseManager : IDatabaseManager
    {
        private const string ConnectionString = "Data Source=PasswordDB.sqlite;Version=3;";

        public DatabaseManager()
        {
            CreateDatabase();
        }

        private void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string createTable =
                    @"CREATE TABLE IF NOT EXISTS PasswordEntries 
                    (Id INTEGER PRIMARY KEY, 
                    Website TEXT NOT NULL, 
                    Username TEXT NOT NULL, 
                    Password TEXT NOT NULL)";
                using (var command = new SQLiteCommand(createTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        public void AddPassword(string website, string username, string password)
        {
            //string encryptedPassword = Encrypt(password);
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO PasswordEntries (Website, Username, Password) VALUES (@Website, @Username, @Password)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditPassword(string passId, string website, string username, string password)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE PasswordEntries SET Website = @Website, Username = @Username, Password = @Password WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", passId);
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeletePassword(List<int> index)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteQuery = "DELETE FROM PasswordEntries WHERE Id = @Id";
                using (var command = new SQLiteCommand(deleteQuery, connection))
                {
                    foreach (var id in index)
                    {
                        
                    }
                    
                    command.Parameters.AddWithValue("@Id", passId);
                    command.ExecuteNonQuery();
                }
            }
        }
        
        public void DropDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string doropDaraBeis = "DROP TABLE IF EXISTS PasswordEntries";
                using (var command = new SQLiteCommand(doropDaraBeis, connection))
                    command.ExecuteNonQuery();
            }
        }

        public BindingList<PasswordEntry> GetAllPass()
        {
            BindingList<PasswordEntry> entries = new BindingList<PasswordEntry>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM PasswordEntries";
                using (var command = new SQLiteCommand(selectQuery, connection))
                    using (var reader = command.ExecuteReader())
                        while (reader.Read())
                        {
                            entries.Add(new PasswordEntry(
                                reader["Website"].ToString(),
                                reader["Username"].ToString(),
                                reader["Password"].ToString(),
                                reader["Id"].ToString()
                                ));
                        }
            }

            return entries;
        }

        private string Encrypt(string data)
        {
            byte[] dataBytes = Encoding.UTF8.GetBytes(data);
            using (var md5 = MD5.Create())
            {
                byte[] encryptedBytes = md5.ComputeHash(dataBytes);
                return Convert.ToBase64String(encryptedBytes);
            }
        }

        private string Decrypt(string encryptedData)
        {
            return encryptedData;
        }
    }
}