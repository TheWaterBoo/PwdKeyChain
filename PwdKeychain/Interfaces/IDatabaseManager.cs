using System.ComponentModel;
using PwdKeychain.Models;

namespace PwdKeychain.Interfaces
{
    public interface IDatabaseManager
    {
        void InitializeCryptor(ICryptNDecrypt cryptNDecrypt);
        MainData? GetStoredData();
        void StoreData(byte[] hash, byte[] salt);
        void AddData(string website, string email, string password);
        void EditData(string passId, string website, string email, string password);
        void DeleteData(List<string> idList);
        BindingList<AccountEntry> GetAllTableData();
        AccountEntry GetOneAccount(string passId);
    }
}