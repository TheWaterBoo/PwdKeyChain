using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Reflection;
using System.Windows.Forms;
using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;
using PwdKeychain.Properties;

namespace PwdKeychain.Forms
{
    public partial class MainForm : Form
    {
        public Keys ShortcutKeys { get; set; }
        private IDatabaseManager _dbManager = new DatabaseManager();

        public MainForm()
        {
            InitializeComponent();
            InitiGridView();
            ShowVersion();
        }

        private void InitiGridView()
        {
            GetGridViewData();
            accGridView.Columns["Password"].Visible = false;
            accGridView.Columns["Id"].Visible = true;
            accGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GetGridViewData()
        {
            accGridView.DataSource = _dbManager.GetAllPass();
        }

        private void ShowVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Resources.MainForm_ShowVersion_Version___0_, version);
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            using (EntryAndEditForm entryForm = new EntryAndEditForm("Save", "Cancel", Resources.EntryAndEditForm_customForm_Add_new_account))
            {
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    _dbManager.AddPassword(entryForm.Website, entryForm.Username, entryForm.Password);
                    GetGridViewData();
                }
            }
        }

        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = accGridView.SelectedRows[0];
                PasswordEntry pwdInd = _dbManager.GetOnePass(row.Cells["Id"].Value.ToString());

                using (EntryAndEditForm editForm = new EntryAndEditForm("Edit", "Cancel", Resources.EntryAndEditForm_customForm_Editing_existing_account))
                {
                    editForm.Website = pwdInd.WebsiteName;
                    editForm.Username = pwdInd.Username;
                    editForm.Password = pwdInd.Password;
                    string passId = pwdInd.Id;

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        _dbManager.EditPassword(passId, editForm.Website, editForm.Username, editForm.Password);
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
                _dbManager.DeletePassword(idList);
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

        private void Shortcuts()
        {
            ShortcutKeys = Keys.Control | Keys.N;
        }

        //Temporal Button, Remove later...
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _dbManager.DropDatabase();
            Dispose();
        }
    }
}