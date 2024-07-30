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
        private BindingList<PasswordEntry> _passwordEntries;
        
        public MainForm()
        {
            InitializeComponent();
            InitializeGridView();
            ShowVersion();
        }

        private void UpdateGridView()
        {
            accGridView.Rows.Clear();
            foreach (var entry in _passwordManager.GetAllPasswords())
            {
                _passwordEntries.Add(entry);
            }
        }

        private void InitializeGridView()
        {
            _passwordEntries = new BindingList<PasswordEntry>(_passwordManager.GetAllPasswords());
            accGridView.DataSource = _passwordEntries;
            accGridView.Columns["Password"].Visible = false;
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            using (EntryAndEditForm entryForm = new EntryAndEditForm("0"))
            {
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    PasswordEntry newEntry = new PasswordEntry(entryForm.Website, entryForm.Username, entryForm.Password);
                    _passwordManager.AddPassword(newEntry);
                    _passwordEntries.Add(newEntry);
                    _passwordManager.SavePasswords();
                }
            }
        }
        
        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count > 0)
            {
                int index = accGridView.SelectedRows[0].Index;
                //PasswordEntry pwdInd = _passwordManager.GetAllPasswords()[index];
                PasswordEntry pwdInd = _passwordEntries[index];

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
                        accGridView.Refresh();
                    }
                }
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _passwordManager.LoadPasswords();
            
            UpdateGridView();
            accGridView.Refresh();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _passwordManager.SavePasswords();
        }
        
        private void ShowVersion()
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version;
            Text = string.Format(Resources.MainForm_ShowVersion_Version___0_, version);
        }
    }
}
