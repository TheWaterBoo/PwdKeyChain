using System.Collections.Generic;
using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Interfaces
{
    public interface IDatabaseManager
    {
        void AddData(string website, string username, string? password);
        void EditData(string passId, string website, string username, string? password);
        void DeleteData(List<string> idList);
        BindingList<AccountEntry> GetAllTableData();
        AccountEntry GetOneAccount(string passId);
    }
}