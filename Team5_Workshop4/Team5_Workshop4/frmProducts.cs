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
    public partial class frmProducts : Form
    {
        public frmProducts()
        {
            InitializeComponent();
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {

            DisplayProducts();
        }

        private void DisplayProducts()
        {
            List<Products> products = ProductsDB.GetProducts();
            gvProducts.DataSource = products;
            gvProducts.Columns[0].Visible = false;
            gvProducts.Columns[1].HeaderText = "Name";
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            Form newForm = new frmAddEditProduct(true, 0);
            newForm.MdiParent = ActiveForm;
            newForm.Show();
        }

        private void btnEditProduct_Click(object sender, EventArgs e)
        {
            int idx = (int)gvProducts.SelectedCells[0].Value;
            Form newForm = new frmAddEditProduct(false, idx);
            newForm.MdiParent = ActiveForm;
            newForm.Show();
        }

        private void frmProducts_Enter(object sender, EventArgs e)
        {
            DisplayProducts();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
