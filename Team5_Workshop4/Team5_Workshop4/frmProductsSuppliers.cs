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
    public partial class frmProductsSuppliers : Form
    {
        public frmProductsSuppliers()
        {
            InitializeComponent();
        }

        private void frmProductsSuppliers_Load(object sender, EventArgs e)
        {
            DisplaySuppliers();
            DisplayExistingProd();
            DisplayAvailableProd();
        }
        private void DisplaySuppliers()
        {
            List<Suppliers> suppliers = SuppliersDB.GetSuppliers();
            cmbSuppliers.DataSource = suppliers;
            cmbSuppliers.DisplayMember = "SupName";
            cmbSuppliers.ValueMember = "SupplierID";

        }
        private void DisplayExistingProd()
        {
            int supID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            List<Products> pslist = ProductsSuppliersDB.GetExistingProdBySupID(supID);
            gvExistingProd.DataSource = pslist;
            //gvExistingProd.RowHeadersVisible = false;
            //gvExistingProd.ColumnHeadersVisible = false;
            gvExistingProd.Columns[0].Visible = false;
            gvExistingProd.Columns[1].HeaderText = "Products";
            //gvExistingProd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DisplayAvailableProd()
        {
            int supID = Convert.ToInt32(cmbSuppliers.SelectedValue);
            List<Products> pslist = ProductsSuppliersDB.GetAvailableProdBySupID(supID);
            gvAvailableProd.DataSource = pslist;
            //gvAvailableProd.RowHeadersVisible = false;
            //gvAvailableProd.ColumnHeadersVisible = false;
            gvAvailableProd.Columns[0].Visible = false;
            gvAvailableProd.Columns[1].HeaderText = "Products";
            //gvAvailableProd.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void cmbSuppliers_SelectionChangeCommitted(object sender, EventArgs e)
        {
            DisplayExistingProd();
            DisplayAvailableProd();
        }

        private void btnAddProd_Click(object sender, EventArgs e)
        {
            int prodID = Convert.ToInt32(gvAvailableProd.SelectedCells[0].Value);
            int supID = Convert.ToInt32(cmbSuppliers.SelectedValue);

            ProductsSuppliersDB.AddProductToSupplier(prodID, supID);

            DisplayExistingProd();
            DisplayAvailableProd();
        }

        private void btnRemoveProd_Click(object sender, EventArgs e)
        {
            int prodID = Convert.ToInt32(gvExistingProd.SelectedCells[0].Value);
            int supID = Convert.ToInt32(cmbSuppliers.SelectedValue);

            ProductsSuppliersDB.DeleteProductFromSupplier(prodID, supID);

            DisplayExistingProd();
            DisplayAvailableProd();
        }
    }
}
