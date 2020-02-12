/*
 * Name: Bilal Ahmad, Eli, Ivan
 * Purpose: Manages Packages, add, edit and delete
 * Project: Workshop 4
 * Date: Feb 12, 2020
 * 
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team5_Workshop4
{
    
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            WindowState = FormWindowState.Maximized;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void managePackagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frmPackageManager = new frmPackageManager();
            frmPackageManager.MdiParent = this;
            frmPackageManager.Show();
            frmPackageManager.WindowState = FormWindowState.Maximized;
        }

        private void closeCurrentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeForm = this.ActiveMdiChild;
            if(activeForm != null)
            {
                activeForm.Close();
            }
        }

        

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmSuppliers();
            newForm.MdiParent = this;
            newForm.Show();
        }

        
    }
}
