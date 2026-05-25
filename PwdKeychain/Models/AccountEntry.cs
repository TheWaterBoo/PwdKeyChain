namespace PwdKeychain.Models
{
    public class AccountEntry(string websiteName, string username, string? password, string id)
    {
        public string WebsiteName { get; set; } = websiteName;
        public string Username { get; set; } = username;
        public string? Password { get; set; } = password;
        public string Id { get; set; } = id;

        public AccountEntry(string websiteName, string username, string id) : this(websiteName, username, null, id)
        {
        }
    }
}