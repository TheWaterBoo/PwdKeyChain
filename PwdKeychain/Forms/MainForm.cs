using System.Reflection;
using PwdKeychain.Interfaces;
using PwdKeychain.Properties;

namespace PwdKeychain.Forms
{
    public partial class MainForm : Form
    {
        private readonly IDatabaseManager _dbManager;
        private readonly IPasswordService _passwordService;

        public MainForm(IDatabaseManager dbManager, IPasswordService passwordService)
        {
            _passwordService = passwordService;
            _dbManager = dbManager;
            InitializeComponent();
            InitGridView();
            ShowVersion();
        }

        private void InitGridView()
        {
            GetGridViewData();
            accGridView.Columns["Password"]!.Visible = false;
            accGridView.Columns["Id"]!.Visible = false;
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
            using (var entryForm = new EntryAndEditForm(_passwordService, "Save", "Cancel",
                       Resources.EntryAndEditForm_customForm_Add_new_account))
            {
                if (entryForm.ShowDialog() != DialogResult.OK) return;
                _dbManager.AddData(entryForm.Website, entryForm.Email, entryForm.Password);
                GetGridViewData();
            }
        }

        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count <= 0) return;
            var row = accGridView.SelectedRows[0];
            var (websiteName, email, password, passId) = _dbManager.GetOneAccount(row.Cells["Id"].Value!.ToString()!);

            using (var editForm = new EntryAndEditForm(_passwordService, "Update", "Cancel",
                       Resources.EntryAndEditForm_customForm_Editing_existing_account))
            {
                editForm.Website = websiteName;
                editForm.Email = email;
                editForm.Password = password;

                if (editForm.ShowDialog() != DialogResult.OK) return;
                _dbManager.EditData(passId, editForm.Website, editForm.Email, editForm.Password);
                GetGridViewData();
            }
        }

        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            var msgText = $"The following {accGridView.SelectedRows.Count} item(s) will be deleted,\n are you sure?";
            using (var deleteVerification = new ConfirmationForm(msgText, "Sure", "Cancel", "Warning"))
            {
                var idList = (from DataGridViewRow row in accGridView.SelectedRows
                    select row.Cells["Id"].Value?.ToString()).ToList();

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