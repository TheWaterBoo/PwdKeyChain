using PwdKeychain.Interfaces;
using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using PwdKeychain.Models;
using PwdKeychain.Utils;

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

        private static void CreateDatabase()
        {
            try
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
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(CreateDatabase), [], "Unable to create database table", 1);
            }
        }

        public void AddPassword(string website, string username, string? password)
        {
            try
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
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(AddPassword), [website, username, "Any Password"],
                    "SQLiteException, Unable to add data", 1);
            }
            catch (Exception ex)
            {
                HandleException(ex, nameof(AddPassword), [website, username, "Any Password"],
                    "Exception in AddPassword", 1);
            }
        }

        public void EditPassword(string passId, string website, string username, string? password)
        {
            try
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
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(EditPassword), [passId, website, username, "Any Password"],
                    "SQLiteException - Cannot edit existing data", 1);
            }
            catch (Exception ex)
            {
                HandleException(ex, nameof(EditPassword), [passId, website, username, "Any Password"],
                    "Exception in EditPassword", 1);
            }
        }

        public void DeletePassword(List<string> idList)
        {
            try
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
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(AddPassword), [idList],
                    "SQLiteException - An error Ocurred while deleting data", 1);
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
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(GetAllPass), [], "SQLiteException - Unable to get user data", 1);
                return [];
            }
        }

        public PasswordEntry GetOnePass(string passId)
        {
            try
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
                                return new PasswordEntry(reader["Website"].ToString(), reader["Username"].ToString(),
                                    _cryptNDecrypt.Decrypter(reader["Password"].ToString(), tempKey),
                                    reader["Id"].ToString());
                        }
                    }
                }

                return null;
            }
            catch (SQLiteException ex)
            {
                HandleException(ex, nameof(AddPassword), [passId], "Unable to create database table", 1);
                return null;
            }
        }

        private static void KeyDbKeeper(SQLiteConnection connection, string key)
        {
            string lastId = "SELECT last_insert_rowid()";
            int lastEntryId;
            using (var command = new SQLiteCommand(lastId, connection))
            {
                lastEntryId = (int)(long)command.ExecuteScalar();
            }

            SaveKey(lastEntryId, key);
        }

        private static void SaveKey(int passwordEntryId, string key)
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

        private static string GetKey(int passwordEntryId)
        {
            string retrievedKey;

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

        private static void EditKey(int passwordEntryId, string newKey)
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

        private static void HandleException(Exception ex, string? method, object[]? args, string title, int exitCode)
        {
            var customEx = new CustomExceptions(ex, nameof(CreateDatabase), method, args);
            customEx.ShowErrDialog(title, exitCode);
        }
    }
}