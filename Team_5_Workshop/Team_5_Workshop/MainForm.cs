using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Team_5_Workshop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProducts_Click(object sender, EventArgs e)
        {
            leftPanel.Height = btnProducts.Height;
            leftPanel.Top = btnProducts.Top;
        }

        private void btnSuppliers_Click(object sender, EventArgs e)
        {
            leftPanel.Height = btnSuppliers.Height;
            leftPanel.Top = btnSuppliers.Top;
        }

        private void btnPackages_Click(object sender, EventArgs e)
        {
            leftPanel.Height = btnPackages.Height;
            leftPanel.Top = btnPackages.Top;
        }

   

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            leftPanel.Height = btnDashboard.Height;
            leftPanel.Top = btnDashboard.Top;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
