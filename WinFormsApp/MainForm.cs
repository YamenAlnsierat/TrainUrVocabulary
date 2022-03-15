using DictionaryLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var Lists = WordList.GetLists();
            WordlistBindingSource.DataSource = Lists;
            lbWordLists.DataSource = WordlistBindingSource;
            lbWordLists.DisplayMember = "Name";
        }
    }
}
