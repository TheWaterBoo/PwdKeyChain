using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;
using PwdKeychain.Properties;

namespace PwdKeychain
{
    public partial class MainForm : Form
    {
        private IPassManager _passwordManager = new PassManager();
        //private BindingList<PasswordEntry> _passwordEntries;
        
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
            accGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GetGridViewData()
        {
            accGridView.ClearSelection();
            _passwordManager.LoadPasswords();
            //_passwordEntries = new BindingList<PasswordEntry>(_passwordManager.GetAllPasswords());
            //accGridView.DataSource = _passwordEntries;
            accGridView.DataSource = _passwordManager.GetAllPasswords();
        }
        
        private void ShowVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Resources.MainForm_ShowVersion_Version___0_, version);
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            using (EntryAndEditForm entryForm = new EntryAndEditForm("0"))
            {
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    PasswordEntry newEntry = new PasswordEntry(entryForm.Website, entryForm.Username, entryForm.Password);
                    _passwordManager.AddPassword(newEntry);
                    _passwordManager.SavePasswords();
                }
            }
        }
        
        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count > 0)
            {
                int index = accGridView.SelectedRows[0].Index;
                PasswordEntry pwdInd = _passwordManager.GetAllPasswords()[index];

                using (EntryAndEditForm editForm = new EntryAndEditForm("1"))
                {
                    editForm.Website = pwdInd.WebsiteName;
                    editForm.Username = pwdInd.Username;
                    editForm.Password = pwdInd.Password;
                    
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        PasswordEntry editedEntry = new PasswordEntry(editForm.Website, editForm.Username, editForm.Password);
                        _passwordManager.EditPassword(index, editedEntry);
                        _passwordManager.SavePasswords();
                        accGridView.ClearSelection();
                        //GetGridViewData();
                    }
                }
            }
        }
        
        private void deleteDataButton_Click(object sender, EventArgs e)
        {
            while (accGridView.SelectedRows.Count > 0)
            {
                int index = accGridView.SelectedRows[0].Index;
                _passwordManager.ErasePassword(index);
                _passwordManager.SavePasswords();
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
        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _passwordManager.SavePasswords();
        }
        
        private void MainForm_Load(object sender, EventArgs e)
        {
            accGridView.ClearSelection();
        }
    }
}
