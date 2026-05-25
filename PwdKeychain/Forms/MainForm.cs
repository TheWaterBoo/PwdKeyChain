using System.Reflection;
using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;
using PwdKeychain.Properties;
using System.ComponentModel;

namespace PwdKeychain.Forms
{
    public partial class MainForm : Form
    {
        private readonly IDatabaseManager _dbManager;

        public MainForm(IDatabaseManager dbManager)
        {
            _dbManager = dbManager;
            InitializeComponent();
            InitGridView();
            ShowVersion();
        }

        private void InitGridView()
        {
            GetGridViewData();
            accGridView.Columns["Password"].Visible = false;
            accGridView.Columns["Id"].Visible = false;
            accGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GetGridViewData()
        {
            accGridView.DataSource = _dbManager.GetAllTableData();
        }

        private void ShowVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Resources.MainForm_ShowVersion_Version___0_, version);
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            using (var entryForm = new EntryAndEditForm("Save", "Cancel",
                       Resources.EntryAndEditForm_customForm_Add_new_account))
            {
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    var newAccount = entryForm.GetAccountData();
                    _dbManager.AddData(newAccount.WebsiteName, newAccount.Username, newAccount.Password);
                    GetGridViewData();
                }
            }
        }

        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count > 0)
            {
                var row = accGridView.SelectedRows[0];
                var pwdInd = _dbManager.GetOneAccount(row.Cells["Id"].Value.ToString());

                using (var editForm = new EntryAndEditForm("Update", "Cancel",
                           Resources.EntryAndEditForm_customForm_Editing_existing_account))
                {
                    var editAccount = editForm.GetAccountData();
                    editAccount.WebsiteName = pwdInd.WebsiteName;
                    editAccount.Username = pwdInd.Username;
                    editAccount.Password = pwdInd.Password;
                    var passId = pwdInd.Id;

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        _dbManager.EditData(passId, editAccount.WebsiteName, editAccount.Username, editAccount.Password);
                        GetGridViewData();
                    }
                }
            }
        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            var msgText = $"The following {accGridView.SelectedRows.Count} item(s) will be deleted,\n are you sure?";
            using (ConfirmationForm deleteVerification = new ConfirmationForm(msgText, "Sure", "Cancel", "Warning"))
            {
                List<string> idList = new List<string>();
                foreach (DataGridViewRow row in accGridView.SelectedRows)
                {
                    idList.Add(row.Cells["Id"].Value.ToString());
                }

                if (deleteVerification.ShowDialog() != DialogResult.OK) return;
                _dbManager.DeleteData(idList);
                GetGridViewData();
            }
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            accGridView.ClearSelection();
        }

        private void accGridView_SelectionChanged(object sender, EventArgs e)
        {
            editDataButton.Enabled = accGridView.SelectedRows.Count == 1;
            deleteDataButton.Enabled = accGridView.SelectedRows.Count >= 1;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            accGridView.ClearSelection();
        }
    }
}