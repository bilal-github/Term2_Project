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
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private Suppliers supplier;

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            int supplierID = (int)LoadStateComboBox(0);
            //if (dblSupplierID.Text != null)
            //{
                
            //}
            
            DisplaySuppliers(supplierID);

            
        }
        private int LoadStateComboBox(int index)
        {
            List<Suppliers> supplier = new List<Suppliers>();
            try
            {
                supplier = SuppliersDB.GetSupplier();
                foreach (Suppliers s in supplier)
                {
                    
                    dblSupplierID.Items.Add(s.SupplierId);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.GetType().ToString());
            }
            return supplier[index].SupplierId;
        }
        private void DisplaySuppliers(int supplierID)
        {
            List<Suppliers> Supplier = SuppliersDB.GetSuppliersBYID(supplierID);
            dataGridView1.DataSource = Supplier;
            //txtSupplierName.Text = supplier.SupName;   
        }

        private void DisplaySupName(string supname)
        {
            List<Suppliers> Supplier = SuppliersDB.GetSuppliersBYName(supname);
            txtSupName.Text = supplier.SupName;
                 
        }

        private void dblSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySuppliers(Convert.ToInt32(dblSupplierID.Text));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyDeleteSuppliers  addSupplierForm = new frmAddModifyDeleteSuppliers();
            addSupplierForm.addSupplier = true;
            DialogResult result = addSupplierForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                supplier = addSupplierForm.supplier;
                dblSupplierID.SelectedIndex = Convert.ToInt32(supplier.SupplierId);
                
            }


        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAddModifyDeleteSuppliers addSupplierForm = new frmAddModifyDeleteSuppliers();
            //addSupplierForm.addSupplier = true;
            //DialogResult result = addSupplierForm.ShowDialog();
            //if (result == DialogResult.OK)
            //{
            //    supplier = addSupplierForm.supplier;
            //    dblSupplierID.SelectedIndex = Convert.ToInt32(supplier.SupplierId);

            //}
        }

        private void btnModifySupplier_Click(object sender, EventArgs e)
        {
            frmAddModifyDeleteSuppliers modifySupplierForm = new frmAddModifyDeleteSuppliers();
            modifySupplierForm.addSupplier = false;
            modifySupplierForm.supplier = supplier;
            DialogResult result = modifySupplierForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                supplier = modifySupplierForm.supplier;
                this.DisplaySupName(supplier.SupName);
            }
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //DialogResult result = MessageBox.Show("Delete " + supplier.SupplierId + "?",
            //    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //if (result == DialogResult.Yes)
            //{
            //try
            //{
            //    if (!SuppliersDB.DeleteSupplier(supplier))
            //    {
            //        MessageBox.Show("Another user has updated or deleted " +
            //            "that customer.", "Database Error");
            //        this.DisplaySuppliers(supplier.SupplierId);
            //        //if (supplier != null)
            //        //    this.DisplaySupName();

            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message, ex.GetType().ToString());
            //}
            
        }
    }
}

