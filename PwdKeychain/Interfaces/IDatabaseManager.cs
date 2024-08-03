using System.Collections.Generic;
using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Interfaces
{
    public interface IDatabaseManager
    {
        void AddPassword(string website, string username, string password);
        void EditPassword(string passId, string website, string username, string password);
        void DeletePassword(List<int> index);
        void DropDatabase();
        BindingList<PasswordEntry> GetAllPass();
    }
}