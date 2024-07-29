using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;

namespace PwdKeychain.Implementations
{
    public class PassManager : IPassManager
    {
        private List<PasswordEntry> _passEntries = new List<PasswordEntry>();

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

        public List<PasswordEntry> GetAllPasswords()
        {
            return _passEntries;
        }
        
        public void LoadPasswords()
        {
            if (File.Exists("SecretPwd.json"))
            {
                string json = File.ReadAllText("SecretPwd.json");
                _passEntries = JsonConvert.DeserializeObject<List<PasswordEntry>>(json);
            }
        }

        public void SavePasswords()
        {
            string json = JsonConvert.SerializeObject(_passEntries, Formatting.Indented);
            File.WriteAllText("SecretPwd.json", json);
        }
    }
}