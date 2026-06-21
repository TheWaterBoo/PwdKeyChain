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

        private ICryptNDecrypt Cryptor =>
            _cryptNDecrypt ??
            throw new InvalidOperationException("Cryptor has not been initialized.");

        public DatabaseManager()
        {
            CreateDatabase();
        }

        public void InitializeCryptor(ICryptNDecrypt cryptNDecrypt)
        {
            _cryptNDecrypt = cryptNDecrypt ?? throw new ArgumentNullException(nameof(cryptNDecrypt));
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
                    Email TEXT NOT NULL, 
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

        public MainData? GetStoredData()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                const string query = @"SELECT Hash, Salt FROM MainData LIMIT 1";
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

        public void AddData(string website, string email, string password)
        {
            var newId = Guid.NewGuid().ToString();
            var creationTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            var encryptPass = Cryptor.Encrypter(password, newId);
            var encryptEmail = Cryptor.Encrypter(email, newId);

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            const string insertQuery = 
                "INSERT INTO PasswordEntries (Id, Website, Email, Password, CreationTime) VALUES (@Id, @Website, @Email, @Password, @CreationTime)";
            
            using (var command = new SQLiteCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", newId);
                command.Parameters.AddWithValue("@Website", website);
                command.Parameters.AddWithValue("@Email", encryptEmail);
                command.Parameters.AddWithValue("@Password", encryptPass);
                command.Parameters.AddWithValue("@CreationTime", creationTime);
                command.ExecuteNonQuery();
            }
        }

        public void EditData(string passId, string website, string email, string password)
        {
            var editedEncryptPass = Cryptor.Encrypter(password, passId);
            var editedEncryptEmail = Cryptor.Encrypter(email, passId);

            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            const string updateQuery =
                "UPDATE PasswordEntries SET Website = @Website, Email = @Email, Password = @Password WHERE Id = @Id";
            using (var command = new SQLiteCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@Id", passId);
                command.Parameters.AddWithValue("@Website", website);
                command.Parameters.AddWithValue("@Email", editedEncryptEmail);
                command.Parameters.AddWithValue("@Password", editedEncryptPass);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteData(List<string> idList)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Open();

            using var transaction = connection.BeginTransaction();

            try
            {
                const string deleteQuery =
                    "DELETE FROM PasswordEntries WHERE Id = @Id";

                using var command =
                    new SQLiteCommand(deleteQuery, connection, transaction);

                var parameter =
                    command.Parameters.Add("@Id", System.Data.DbType.String);

                foreach (var id in idList)
                {
                    parameter.Value = id;

                    command.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        public BindingList<AccountEntry> GetAllTableData()
        {
            BindingList<AccountEntry> entries = [];
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                const string selectQuery = "SELECT * FROM PasswordEntries";
                using (var command = new SQLiteCommand(selectQuery, connection))
                using (var reader = command.ExecuteReader())
                    while (reader.Read())
                    {
                        var id = reader["Id"].ToString();

                        entries.Add(new AccountEntry(
                            reader["Website"].ToString()!,
                            Cryptor.Decrypter(reader["Email"].ToString()!, id!), id!
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
                const string selectQuery = "SELECT * FROM PasswordEntries WHERE Id = @Id";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", passId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (!reader.Read())
                            throw new InvalidOperationException("An error occurred while reading the database");

                        var id = reader["Id"].ToString();

                        return new AccountEntry(reader["Website"].ToString()!,
                            Cryptor.Decrypter(reader["Email"].ToString()!, id!),
                            Cryptor.Decrypter(reader["Password"].ToString()!, id!), id!);
                    }
                }
            }
        }
    }
}