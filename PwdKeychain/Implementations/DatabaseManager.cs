using PwdKeychain.Interfaces;
using System.Data.SQLite;
using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class DatabaseManager : IDatabaseManager
    {
        private const string ConnectionString = "Data Source=PwdKeyChainAccountsDb.sqlite;Version=3;";
        private ICryptNDecrypt? _cryptNDecrypt;

        public DatabaseManager()
        {
            CreateDatabase();
        }

        public void InitializeCryptor(ICryptNDecrypt cryptNDecrypt)
        {
            _cryptNDecrypt = cryptNDecrypt;
        }

        private static void CreateDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var createTable =
                    @"CREATE TABLE IF NOT EXISTS PasswordEntries 
                    (Id TEXT PRIMARY KEY, 
                    Website TEXT NOT NULL, 
                    Username TEXT NOT NULL, 
                    Password TEXT NOT NULL,
                    CreationTime TEXT NOT NULL)";
                using (var command = new SQLiteCommand(createTable, connection))
                    command.ExecuteNonQuery();

                createTable =
                    @"CREATE TABLE IF NOT EXISTS MainData 
                    (Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Hash BLOB NOT NULL,
                    Salt BLOB NOT NULL)";
                using (var command = new SQLiteCommand(createTable, connection))
                    command.ExecuteNonQuery();
            }
        }

        public MainData GetStoredData()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var query = @"SELECT Hash, Salt FROM MainData LIMIT 1";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    if (!reader.Read())
                        return null;

                    var hash = (byte[])reader["Hash"];
                    var salt = (byte[])reader["Salt"];

                    return new MainData(hash, salt);
                }
            }
        }

        public void StoreData(byte[] hash, byte[] salt)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var insertQuery = "INSERT INTO MainData (Hash, Salt) VALUES (@Hash, @Salt)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Hash", hash);
                    command.Parameters.AddWithValue("@Salt", salt);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddData(string website, string username, string? password)
        {
            var newId = Guid.NewGuid().ToString();
            var creationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var insertQuery =
                    "INSERT INTO PasswordEntries (Id, Website, Username, Password, CreationTime) VALUES (@Id, @Website, @Username, @Password, @CreationTime)";
                using (var command = new SQLiteCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", newId);
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", "PASS_PLACEHOLDER");
                    command.Parameters.AddWithValue("@CreationTime", creationTime);
                    command.ExecuteNonQuery();
                }

                var encryptPass = _cryptNDecrypt.Encrypter(password, newId);

                var updateQuery = "UPDATE PasswordEntries SET Password = @Password WHERE Id = @Id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", newId);
                    command.Parameters.AddWithValue("@Password", encryptPass);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EditData(string passId, string website, string username, string? password)
        {
            var editedEncryptPass = _cryptNDecrypt.Encrypter(password, passId);

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
            }
        }

        public void DeleteData(List<string> idList)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                foreach (var id in idList)
                {
                    //Delete data
                    var deleteQuery = "DELETE FROM PasswordEntries WHERE Id = @Id";
                    using (var command = new SQLiteCommand(deleteQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public BindingList<AccountEntry> GetAllTableData()
        {
            BindingList<AccountEntry> entries = [];
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectQuery = "SELECT * FROM PasswordEntries";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        entries.Add(new AccountEntry(
                            reader["Website"].ToString(),
                            reader["Username"].ToString(),
                            reader["Id"].ToString()
                        ));
                    }
            }

            return entries;
        }

        public AccountEntry GetOneAccount(string passId)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectQuery = "SELECT * FROM PasswordEntries WHERE Id = @Id";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", passId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new SQLiteException("An error occurred while reading the database");

                        var entryId = reader["Id"].ToString();

                        return new AccountEntry(reader["Website"].ToString()!, reader["Username"].ToString()!,
                            _cryptNDecrypt.Decrypter(reader["Password"].ToString()!, entryId!), entryId!);
                    }
                }
            }
        }
    }
}