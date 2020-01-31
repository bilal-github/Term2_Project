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

        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            List<Suppliers> Supplier = SuppliersDB.GetSuppliers();

            dataGridView1.DataSource = Supplier;
        }
    }
}
