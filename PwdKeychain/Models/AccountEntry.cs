namespace PwdKeychain.Models
{
    public record AccountEntry(string WebsiteName, string Username, string? Password, string Id)
    {
        public AccountEntry(string websiteName, string username, string id) : this(websiteName, username, null, id)
        {
        }
    }
}