namespace PwdKeychain.Models
{
    public class PasswordEntry(string websiteName, string username, string? password, string id, string? type)
    {
        public string WebsiteName { get; set; } = websiteName;
        public string Username { get; set; } = username;
        public string? Password { get; set; } = password;
        public string Id { get; set; } = id;
        public string? Type { get; set; } = type;

        public PasswordEntry(string websiteName, string username, string id) : this(websiteName, username,
            null, id, null)
        {
        }
    }
}