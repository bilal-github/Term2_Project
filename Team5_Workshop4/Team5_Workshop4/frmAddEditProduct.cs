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
    public partial class frmAddEditProduct : Form
    {
        bool AddProd;
        int ProdIdx;

        public frmAddEditProduct(bool add, int idx)
        {
            InitializeComponent();
            AddProd = add;
            ProdIdx = idx;
        }

        private void frmAddEditProduct_Load(object sender, EventArgs e)
        {
            List<Products> products = ProductsDB.GetProducts();
            cmbProducts.DataSource = products;
            cmbProducts.DisplayMember = "ProdName";
            cmbProducts.ValueMember = "ProductID";

            if (AddProd) // If it's an Add Product command
            {
                lblAddEditProduct.Text = "Add Product"; // Change label to read Add Product
                cmbProducts.Visible = false; // Hide combo box of products
            }
            else // Edit an existing product
            {
                lblAddEditProduct.Text = "Edit Product:"; // Change label to read Edit Product
                cmbProducts.Visible = true; // Show combo box of products
                cmbProducts.SelectedValue = ProdIdx; // change selected item in combo box
                //Console.WriteLine("Combobox " + ProdIdx);
            }

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Products oldProd = ProductsDB.GetProductByID(Convert.ToInt32(cmbProducts.SelectedValue));
            Products prod = new Products();
            if (Validator.IsPresent(txtNewProdName,"Product Name"))
            {
                prod.ProdName = txtNewProdName.Text;
                if (AddProd)
                {
                    ProductsDB.AddProduct(prod);
                }
                else
                {
                    ProductsDB.UpdateProduct(oldProd, prod);
                }
                Close();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbProducts.SelectedValue = ProdIdx;
            //else
            //    cmbProducts.SelectedIndex = 0;
            txtNewProdName.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
