/*
 * Author: Ivan Lo
 * Date: January 24, 2020
 * Purpose: Suppliers Add/Modify/Delete Form
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
    public partial class frmAddModifyDeleteSuppliers : Form
    { public Suppliers supplier;


        public frmAddModifyDeleteSuppliers(Suppliers _supplier)
        {
            supplier = _supplier;
            InitializeComponent();
        }

        public bool addSupplier;
         

        /// <summary>
        /// Form Load Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmAddModifyDeleteSuppliers_Load(object sender, EventArgs e)
        {
            txtSupID.Text = supplier.SupplierId.ToString();
            txtSupName.Text = supplier.SupName;
            if (addSupplier)
            {
                this.Text = "Add Supplier";
                this.txtSupID.Enabled = false;
                //this.txtSupID.Text = "0";
                this.txtSupName.Text = "";

            }
            else
            {
                this.Text = "Modify Supplier";
                this.txtSupID.Enabled = false;
                this.DisplaySupplier();
            }
        }


        private void DisplaySupplier()
        {
            //txtSupName.Text = supplier.SupName;
        }

        /// <summary>
        /// Accept Button Properties
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if(Validator.IsPresent(txtSupName, "Supplier Name"))
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
                    Suppliers oldSupplier = supplier;
                    newSupplier.SupName = txtSupName.Text;
                    oldSupplier = SuppliersDB.GetSuppliersBYID(Convert.ToInt32(txtSupID.Text))[0];
                
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
        }

        /// <summary>
        /// Insert Supplier Data into Textboxes
        /// </summary>
        /// <param name="supplier"></param>
        private void PutSupplierData(Suppliers supplier)
        {
            supplier.SupName = txtSupName.Text;
            supplier.SupplierId = Convert.ToInt32(txtSupID.Text);
        }

        /// <summary>
        /// Exit and or Cancel form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
