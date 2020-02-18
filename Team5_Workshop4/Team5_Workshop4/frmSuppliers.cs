/*
 * Author: Ivan Lo.
 * Date: January 24, 2020
 * Purpose: Suppliers Form
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
    public partial class frmSuppliers : Form
    {
        public frmSuppliers()
        {
            InitializeComponent();
        }

        private Suppliers supplier = new Suppliers();

        /// <summary>
        /// Quit Supplier form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnQuit_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Form Load Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            int supplierID = (int)LoadStateComboBox(0);
           
            
            DisplaySuppliers(supplierID);
            dblSupplierID.SelectedIndex = 0;
            GridStyle();

        }

        /// <summary>
        /// Load Supplier combobox method
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int LoadStateComboBox(int index)
        {
            List<Suppliers> supplier = new List<Suppliers>();
            try
            {
                supplier = SuppliersDB.GetSupplier();
                dblSupplierID.Items.Clear();
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

        /// <summary>
        /// Display Data in GridView
        /// </summary>
        /// <param name="supplierID"></param>
        private void DisplaySuppliers(int supplierID)
        {
            List<Suppliers> Supplier = SuppliersDB.GetSuppliersBYID(supplierID);
            dataGridView1.DataSource = Supplier;             
        }

        private void DisplaySupName(string supname)
        {
            List<Suppliers> Supplier = SuppliersDB.GetSuppliersBYName(supname);            
        }

        private void dblSupplierID_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplaySuppliers(Convert.ToInt32(dblSupplierID.Text));
        }

        /// <summary>
        /// Add Button properties for Suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModifyDeleteSuppliers  addSupplierForm = new frmAddModifyDeleteSuppliers(supplier);
            addSupplierForm.addSupplier = true;
            DialogResult result = addSupplierForm.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                supplier = addSupplierForm.supplier;
                LoadStateComboBox(0);                              
            }
        }

        /// <summary>
        /// Modify Button properties for Suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifySupplier_Click(object sender, EventArgs e)
        {           
            int selectedRowIndex = dataGridView1.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            supplier.SupplierId = Convert.ToInt32(selectedRow.Cells[0].Value);
            supplier.SupName = selectedRow.Cells[1].Value.ToString();
            frmAddModifyDeleteSuppliers modifySupplierForm = new frmAddModifyDeleteSuppliers(supplier);
            modifySupplierForm.addSupplier = false;
            modifySupplierForm.supplier = supplier;

            
            DialogResult result = modifySupplierForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                supplier = modifySupplierForm.supplier;
                this.DisplaySupName(supplier.SupName);
                DisplaySuppliers(supplier.SupplierId);
                
            }            
        }


        /// <summary>
        /// Delete Button properties for Suppliers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int supID = Convert.ToInt32(dblSupplierID.SelectedItem);
            supplier = SuppliersDB.GetSuppliersBYID(supID)[0];
            DialogResult result = MessageBox.Show("Delete " + dblSupplierID.SelectedItem.ToString() + "?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            
            if (result == DialogResult.Yes)
            {                
                DisplaySuppliers(supplier.SupplierId);               
                try
                {
                    if (!SuppliersDB.DeleteSupplier(supplier))
                    {
                        MessageBox.Show("Another user has updated or deleted " +
                            "that customer.", "Database Error");
                                                                    
                    }
                    else
                    {
                        UpdateRefresh();
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.GetType().ToString());
                }
            }
        }


        /// <summary>
        /// Update and refresh for combobox and gridview
        /// </summary>
        private void UpdateRefresh()
        {
            DisplaySuppliers(supplier.SupplierId);
            LoadStateComboBox(0);
            dataGridView1.Update();
            dataGridView1.Refresh();
        }

        private void GridStyle()
        {
            dataGridView1.Columns[0].HeaderText = "Supplier ID";
            dataGridView1.Columns[1].HeaderText = "Supplier Name";

            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;
            dataGridView1.EnableHeadersVisualStyles = false;
            //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            //dataGridView1.AutoResizeColumns();
            //dataGridView1.Columns[0].Width = 50;
            //dataGridView1.Columns[1].Width = 250;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}

