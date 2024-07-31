using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using Newtonsoft.Json;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class PassManager : IPassManager
    {
        private BindingList<PasswordEntry> _passEntries = new BindingList<PasswordEntry>();

        public void AddPassword(PasswordEntry newEntry)
        {
            _passEntries.Add(newEntry);
        }

        public void EditPassword(int index, PasswordEntry entry)
        {
            if (index >= 0 && index < _passEntries.Count)
                _passEntries[index] = entry;
        }

        public void ErasePassword(int index)
        {
            if (index >= 0 && index < _passEntries.Count)
                _passEntries.RemoveAt(index);
        }

        public BindingList<PasswordEntry> GetAllPasswords()
        {
            return _passEntries;
        }
        
        //Metodos temporales
        public void LoadPasswords()
        {
            if (File.Exists("SecretPwd.json"))
            {
                string json = File.ReadAllText("SecretPwd.json");
                _passEntries = JsonConvert.DeserializeObject<BindingList<PasswordEntry>>(json);
            }
        }

        public void SavePasswords()
        {
            string json = JsonConvert.SerializeObject(_passEntries, Formatting.Indented);
            File.WriteAllText("SecretPwd.json", json);
        }
    }
}