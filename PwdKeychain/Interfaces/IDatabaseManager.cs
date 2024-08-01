using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Interfaces
{
    public interface IDatabaseManager
    {
        void AddPassword(string website, string username, string password);
        void EditPassword(int id, string website, string username, string password);
        void DeletePassword(int id);
        BindingList<PasswordEntry> GetAllPass();
    }
}