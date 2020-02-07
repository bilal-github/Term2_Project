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
            LoadStateComboBox();
            //if (dblSupplierID.Text != null)
            //{
                
            //}
            
            DisplaySuppliers();

            
        }
        private void LoadStateComboBox()
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
        }
        private void DisplaySuppliers()
        {
            
            

            List<Suppliers> Supplier = SuppliersDB.GetSuppliersBYID(Convert.ToInt32(dblSupplierID.Items[0]));
                dataGridView1.DataSource = Supplier;
            //txtSupplierName.Text = supplier.SupName;   
        }

        private void dblSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySuppliers();
        }
    }
}
