namespace PwdKeychain.Models
{
    public record AccountEntry(string WebsiteName, string? Email, string? Password, string Id)
    {
        public AccountEntry(string websiteName, string? Email, string id) : this(websiteName, Email, null, id)
        {
        }
    }
}