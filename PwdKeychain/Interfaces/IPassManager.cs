using System.Collections.Generic;
using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Interfaces
{
    public interface IPassManager
    {
        void AddPassword(PasswordEntry newEntry);
        void EditPassword(int index, PasswordEntry entry);
        void ErasePassword(int index);
        BindingList<PasswordEntry> GetAllPasswords();
        void LoadPasswords();
        void SavePasswords();
    }
}