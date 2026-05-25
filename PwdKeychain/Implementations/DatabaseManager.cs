using PwdKeychain.Interfaces;
using System.Data.SQLite;
using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class DatabaseManager : IDatabaseManager
    {
        private const string ConnectionString = "Data Source=PwdKeyChainAccountsDb.sqlite;Version=3;";
        private readonly ICryptNDecrypt _cryptNDecrypt;

        public DatabaseManager(ICryptNDecrypt cryptNDecrypt)
        {
            _cryptNDecrypt = cryptNDecrypt;
            CreateDatabase();
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

                    //Delete key
                    var deleteKeyQuery = "DELETE FROM EncryptionKeys WHERE PasswordEntryId = @PasswordEntryId";
                    using (var command = new SQLiteCommand(deleteKeyQuery, connection))
                    {
                        command.Parameters.AddWithValue("@PasswordEntryId", id);
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
                        if (!reader.Read()) return null;
                        var entryId = reader["Id"].ToString();

                        return new AccountEntry(reader["Website"].ToString(), reader["Username"].ToString(),
                            _cryptNDecrypt.Decrypter(reader["Password"].ToString(), entryId),
                            reader["Id"].ToString());
                    }
                }
            }
        }
    }
}