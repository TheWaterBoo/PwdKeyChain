using PwdKeychain.Interfaces;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using PwdKeychain.Forms;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class DatabaseManager : IDatabaseManager
    {
        private const string ConnectionString = "Data Source=PasswordDB.sqlite;Version=3;";
        private readonly ICryptNDecrypt _cryptNDecrypt = new CryptNDecrypt();

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
                    (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    Website TEXT NOT NULL, 
                    Username TEXT NOT NULL, 
                    Password TEXT NOT NULL)";
                using (var command = new SQLiteCommand(createTable, connection))
                    command.ExecuteNonQuery();

                string createKeysTable =
                    @"CREATE TABLE IF NOT EXISTS EncryptionKeys 
                    (Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    PasswordEntryId INTEGER NOT NULL,
                    Key TEXT NOT NULL,
                    FOREIGN KEY(PasswordEntryId) REFERENCES PasswordEntries(Id))";
                using (var command = new SQLiteCommand(createKeysTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        public void AddPassword(string website, string username, string? password)
        {
            string encryptPass = _cryptNDecrypt.Encrypter(password, out var key);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery =
                    "INSERT INTO PasswordEntries (Website, Username, Password) VALUES (@Website, @Username, @Password)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", encryptPass);
                    command.ExecuteNonQuery();
                }

                KeyDbKeeper(connection, key);
            }
        }

        public void EditPassword(string passId, string website, string username, string? password)
        {
            string editedEncryptPass = _cryptNDecrypt.Encrypter(password, out var key);

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updateQuery =
                    "UPDATE PasswordEntries SET Website = @Website, Username = @Username, Password = @Password WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", passId);
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", editedEncryptPass);
                    command.ExecuteNonQuery();
                }

                EditKey(Convert.ToInt32(passId), key);
            }
        }

        public void DeletePassword(List<string> idList)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                foreach (var id in idList)
                {
                    //Delete data
                    string deleteQuery = "DELETE FROM PasswordEntries WHERE Id = @Id";
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }

                    //Delete key
                    string deleteKeyQuery = "DELETE FROM EncryptionKeys WHERE PasswordEntryId = @PasswordEntryId";
                    using (var command = new SQLiteCommand(deleteKeyQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordEntryId", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        private void KeyDbKeeper(SQLiteConnection connection, string key)
        {
            string lastId = "SELECT last_insert_rowid()";
            int lastEntryId;
            using (var command = new SQLiteCommand(lastId, connection))
            {
                lastEntryId = (int)(long)command.ExecuteScalar();
            }

            SaveKey(lastEntryId, key);
        }

        private void SaveKey(int passwordEntryId, string key)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery =
                    "INSERT INTO EncryptionKeys (PasswordEntryId, Key) VALUES (@PasswordEntryId, @Key)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@PasswordEntryId", passwordEntryId);
                    command.Parameters.AddWithValue("@Key", key);
                    command.ExecuteNonQuery();
                }
            }
        }

        private string GetKey(int passwordEntryId)
        {
            string retrievedKey = "";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                string getKeyQuery = "SELECT Key FROM EncryptionKeys WHERE PasswordEntryId = @PasswordEntryId";
                using (var command = new SQLiteCommand(getKeyQuery, connection))
                {
                    command.Parameters.AddWithValue("@PasswordEntryId", passwordEntryId);
                    retrievedKey = command.ExecuteScalar() as string;
                }
            }

            return retrievedKey;
        }

        private void EditKey(int passwordEntryId, string newKey)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string updateQuery = @"UPDATE EncryptionKeys SET Key = @Key WHERE PasswordEntryId = @PasswordEntryId";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@PasswordEntryId", passwordEntryId);
                    command.Parameters.AddWithValue("@Key", newKey);
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
            try
            {
                BindingList<PasswordEntry> entries = [];
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
                                reader["Id"].ToString()
                            ));
                        }
                }

                return entries;
            }
            catch (FormatException ex)
            {
                throw;
            }
            catch (SQLiteException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new Exception();
            }
        }

        public PasswordEntry GetOnePass(string passId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM PasswordEntries WHERE Id = @Id";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", passId);
                    using (var reader = command.ExecuteReader())
                    {
                        string tempKey = GetKey(Convert.ToInt32(passId));

                        if (reader.Read())
                        {
                            return new PasswordEntry(reader["Website"].ToString(), reader["Username"].ToString(),
                                _cryptNDecrypt.Decrypter(reader["Password"].ToString(), tempKey), reader["Id"].ToString());
                        }
                    }
                }
            }

            return null;
        }
    }
}