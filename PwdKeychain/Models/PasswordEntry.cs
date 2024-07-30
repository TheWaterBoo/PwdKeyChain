namespace PwdKeychain.Models
{
    public class PasswordEntry
    {
        public string WebsiteName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public PasswordEntry(string websiteName, string username, string password)
        {
            WebsiteName = websiteName;
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            return $"{WebsiteName} - {Password}";
        }
    }
}