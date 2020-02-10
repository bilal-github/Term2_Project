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
    public partial class frmAddModifyDeleteSuppliers : Form
    {
        public frmAddModifyDeleteSuppliers()
        {
            InitializeComponent();
        }

        public bool addSupplier;
        public Suppliers supplier;


        private void frmAddModifyDeleteSuppliers_Load(object sender, EventArgs e)
        {
            if (addSupplier)
            {
                this.Text = "Add Supplier";
            }
            else
            {
                this.Text = "Modify Supplier";
                
            }
        }

        private void DisplaySupplier()
        {
            txtSupName.Text = supplier.SupName;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (addSupplier) // INSERT
            {
                supplier = new Suppliers();
                this.PutSupplierData(supplier);
                try
                {
                   SuppliersDB.AddSupplier(supplier);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
            else // UPDATE
            {
                Suppliers newSupplier = new Suppliers();
                newSupplier.SupName = supplier.SupName;
                this.PutSupplierData(newSupplier);
                try
                {
                    if (!SuppliersDB.UpdateSupplier(supplier, newSupplier))
                    {
                        MessageBox.Show("Another user has updated or " +
                            "deleted that customer.", "Database Error");
                        this.DialogResult = DialogResult.Retry;
                    }
                    else // success
                    {
                        supplier = newSupplier;
                        this.DialogResult = DialogResult.OK;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }
        private void PutSupplierData(Suppliers supplier)
        {
            supplier.SupName = txtSupName.Text;
            supplier.SupplierId = Convert.ToInt32(txtSupID.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
