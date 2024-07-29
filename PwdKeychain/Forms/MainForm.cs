using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PwdKeychain.Implementations;
using PwdKeychain.Interfaces;
using PwdKeychain.Models;

namespace PwdKeychain
{
    public partial class MainForm : Form
    {
        private IPassManager _passwordManager = new PassManager();
        
        public MainForm()
        {
            InitializeComponent();
            SetIcoBarButton();
        }

        private void addPass_Click(object sender, EventArgs e)
        {
            string website = websiteTxtBox.Text;
            string username = userTxtBox.Text;
            string password = pwdTxtBox.Text;

            PasswordEntry entry = new PasswordEntry(website, username, password);
            _passwordManager.AddPassword(entry);

            UpdateListView();
        }

        private void editPass_Click(object sender, EventArgs e)
        {
            if (listViewShowPass.SelectedItems.Count > 0)
            {
                int index = listViewShowPass.SelectedIndices[0];
                PasswordEntry entry = new PasswordEntry(websiteTxtBox.Text, userTxtBox.Text, pwdTxtBox.Text);
                _passwordManager.EditPassword(index, entry);

                UpdateListView();
            }
        }

        private void deletePass_Click(object sender, EventArgs e)
        {
            if (listViewShowPass.SelectedItems.Count > 0)
            {
                int index = listViewShowPass.SelectedIndices[0];
                _passwordManager.ErasePassword(index);

                UpdateListView();
            }
        }

        private void UpdateListView()
        {
            listViewShowPass.Items.Clear();
            foreach (var entry in _passwordManager.GetAllPasswords())
            {
                listViewShowPass.Items.Add(entry.ToString());
            }
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            _passwordManager.LoadPasswords();
            UpdateListView();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _passwordManager.SavePasswords();
        }

        private void SetIcoBarButton()
        {
            
        }

        private void addDataButton_Click(object sender, EventArgs e)
        {
            using (EntryAndEditForm entryForm = new EntryAndEditForm())
            {
                if (entryForm.ShowDialog() == DialogResult.OK)
                {
                    PasswordEntry entry = new PasswordEntry(entryForm.)
                }
            }
        }
    }
}
