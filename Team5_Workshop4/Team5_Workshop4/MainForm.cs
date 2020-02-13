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

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmSuppliers();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
        }

        private void manageSuppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmProducts();
            newForm.MdiParent = this;
            newForm.Show();
        }

        private void supplierProductstoolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newForm = new frmProductsSuppliers();
            newForm.MdiParent = this;
            newForm.Show();
        }
    }
}
