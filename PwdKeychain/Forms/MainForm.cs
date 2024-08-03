﻿using System;
using System.Collections.Generic;
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
        private IPassManager _passwordManager = new PassManager();
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
            //accGridView.Columns["Id"].Visible = false;
            accGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void GetGridViewData()
        {
            accGridView.DataSource = _dbManager.GetAllPass();
            /*accGridView.Refresh();
            accGridView.ClearSelection();*/
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
                    _dbManager.AddPassword(entryForm.Website, entryForm.Username, entryForm.Password);
                    GetGridViewData();
                }
            }
        }
        
        private void editDataButton_Click(object sender, EventArgs e)
        {
            if (accGridView.SelectedRows.Count > 0)
            {
                int index = accGridView.SelectedRows[0].Index;
                PasswordEntry pwdInd = _dbManager.GetAllPass()[index];

                using (EntryAndEditForm editForm = new EntryAndEditForm("1"))
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
            using (ConfirmationForm deleteVerification = new ConfirmationForm(msgText, "Sure","Cancel", "Warning"))
            {
                List<int> selectedIndex = new List<int>();
                foreach (DataGridViewRow row in accGridView.SelectedRows)
                {
                    selectedIndex.Add(row.Index);
                }
                
                if (deleteVerification.ShowDialog() != DialogResult.OK) return;
                while (accGridView.SelectedRows.Count > 0)
                {
                    //int index = accGridView.SelectedRows[0].Index;
                    //PasswordEntry pwdInd = _dbManager.GetAllPass()[index];
                    //string passId = pwdInd.Id;
                    
                    _dbManager.DeletePassword(selectedIndex);
                }
                //GetGridViewData();
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

        //Temporal Button, Remove later...
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            _dbManager.DropDatabase();
        }
    }
}
