using DataAccess;
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
    public partial class frmPackageManager : Form
    {
        int globalPackageID = -1;
        //initialize form level objects and variables
        PackageManagerPackage package = new PackageManagerPackage();
        PackageManagerPackage editPackage = new PackageManagerPackage();

        public frmPackageManager()
        {
            InitializeComponent();
        }
        private void frmPackageManager_Load(object sender, EventArgs e)
        {
            tabControl.SizeMode = TabSizeMode.FillToRight;
            dgvEditProducts.ReadOnly = true;
            EditPackageTab.Enabled = false;
            EditPackageProductsTab.Enabled = false;
            lblOverlayEditPackage.Visible = true;
            lblOverlayEditProducts.Visible = true;
            lblOverlayEditProducts.Location = lblOverlayEditPackage.Location;
            dgvOverlayEditPackage.Visible = true;
            dgvOverlayEditProducts.Visible = true;
            LoadViewPackageDataGridView();
            StyleViewPackageDataGridView();
        }
        /// <summary>
        /// Styles datagridview in view packages
        /// </summary>
        private void StyleViewPackageDataGridView()
        {
            dgvPackages.Columns[0].HeaderText = "Package ID";
            dgvPackages.Columns[1].HeaderText = "Package Name";
            dgvPackages.Columns[2].HeaderText = "Package Start Date";
            dgvPackages.Columns[3].HeaderText = "Package End Date";
            dgvPackages.Columns[4].HeaderText = "Package Description";
            dgvPackages.Columns[5].HeaderText = "Package Base Price";
            dgvPackages.Columns[6].HeaderText = "Package Agency Commission";

            dgvPackages.Columns[5].DefaultCellStyle.Format = "c";
            dgvPackages.Columns[6].DefaultCellStyle.Format = "c";

            dgvPackages.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;
            dgvPackages.EnableHeadersVisualStyles = false;


            dgvPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPackages.AutoResizeColumns();


        }
        private void StyleProductNameSupplierNameDataGridView()
        {
            dgvEditProducts.Columns[0].HeaderText = "Product Name";
            dgvEditProducts.Columns[1].HeaderText = "Supplier Name";

            dgvEditProducts.ColumnHeadersDefaultCellStyle.BackColor = Color.Aqua;
            dgvEditProducts.EnableHeadersVisualStyles = false;

            dgvEditProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEditProducts.AutoResizeColumns();
        }

        /// <summary>
        /// Loads Packages to the DataGridView in View Packages
        /// </summary>
        private void LoadViewPackageDataGridView()
        {
            //loads packages list from PackageDB
            List<PackageManagerPackage> packages = PackageManagerPackageDB.GetPackages();

            dgvPackages.DataSource = packages;


        }

        /// <summary>
        /// adds packages to the database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddPackage_Click(object sender, EventArgs e)
        {
            bool addpackage = false;
            if (AddPackagehasValues())
            {
                if (txtPackageAgencyCommission.Text != "") //not null
                {
                    if (Validator.IsNonNegativeDecimal(txtPackageAgencyCommission, "Package Agency Commission"))
                    {
                        if (Convert.ToDecimal(txtPackageAgencyCommission.Text) > Convert.ToDecimal(txtPackageBasePrice.Text))
                        {
                            MessageBox.Show($"Commission cannot be greater than the Base Price: {txtPackageBasePrice.Text}");
                            addpackage = false;
                        }
                        else
                        {
                            addpackage = true;
                        }
                    }
                    else
                    {
                        addpackage = false;
                    }

                }
                else
                {
                    addpackage = true;
                }

                if ((dtpPackageStartDate.Format == DateTimePickerFormat.Long) && (dtpPackageEndDate.Format == DateTimePickerFormat.Long))
                {
                    if (addpackage == true)
                    {
                        if (dtpPackageEndDate.Value.Date < dtpPackageStartDate.Value.Date)
                        {
                            MessageBox.Show("End date can't be before start date", "Invalid Date");
                            addpackage = false;
                        }
                        else
                        {
                            addpackage = true;
                            //AddPackage();
                        }
                    }
                    else
                    {
                        addpackage = false;
                    }

                }
                else
                {
                    if (addpackage == true)
                    {
                        addpackage = true;
                    }

                }

                if (addpackage == true)
                {
                    AddPackage();
                }

            }

        }

        private void AddPackage()
        {
            try
            {
                InputDataToAddPackage(package);
                package.PackageID = PackageManagerPackageDB.AddPackage(package);
                MessageBox.Show($"The inserted package has been given an ID of: {package.PackageID}", "Package Added");
                LoadViewPackageDataGridView(); // refresh the datagridview
                ResetAddPackageFields();
                tabControl.SelectedTab = ViewPackagesTab;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ResetAddPackageFields()
        {
            txtPackageName.Text = "";
            txtPackageDescription.Text = "";
            txtPackageBasePrice.Text = "";
            txtPackageAgencyCommission.Text = "";

        }

        /// <summary>
        /// grabs data from fields and builds a package
        /// </summary>
        /// <param name="package"></param>
        /// <returns>Package</returns>
        private PackageManagerPackage InputDataToAddPackage(PackageManagerPackage package)
        {
            //add validator
            package.PkgName = txtPackageName.Text;
            package.PkgDesc = txtPackageDescription.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtPackageBasePrice.Text);
            if (dtpPackageStartDate.Format != DateTimePickerFormat.Long)
            {
                package.PkgStartDate = null;
            }
            else
            {
                package.PkgStartDate = (DateTime)dtpPackageStartDate.Value.Date;
            }

            if (dtpPackageEndDate.Format != DateTimePickerFormat.Long)
            {
                package.PkgEndDate = null;
            }
            else
            {
                package.PkgEndDate = (DateTime)dtpPackageEndDate.Value.Date;
            }

            //Check Commission
            if (txtPackageAgencyCommission.Text != "") // not empty // check to see if commission is numbers or not
            {
                if (Validator.IsNonNegativeDecimal(txtPackageAgencyCommission, "Package Agency commission"))
                {
                    decimal? packageAgencyCommission;
                    packageAgencyCommission = Convert.ToDecimal(txtPackageAgencyCommission.Text);
                    package.PkgAgencyCommission = PriceCommissionValidate(package.PkgBasePrice, packageAgencyCommission, "add");
                }

            }
            else
            {
                package.PkgAgencyCommission = null;
            }

            return package;

        }

        private decimal? PriceCommissionValidate(decimal PackageBasePrice, decimal? PackageAgencyCommission, string addOrEdit)
        {
            if (PackageAgencyCommission > PackageBasePrice)
            {
                MessageBox.Show($"Commission cannot be greater than the Base Price: {PackageBasePrice}");
                if (addOrEdit == "add")
                {
                    txtPackageAgencyCommission.Focus();
                }
                else
                {
                    txtEditAgencyCommission.Focus();
                }
            }

            return PackageAgencyCommission;

        }
        //goes to the edit tab to edit the selected package
        private void btnEditSelectedPackage_Click(object sender, EventArgs e)
        {
            //int packageID = 0;
            if (globalPackageID == -1)
            {

                PackageManagerPackage selectedPackage = new PackageManagerPackage();
                if (dgvPackages.SelectedCells.Count > 0)
                {
                    EditPackageTab.Enabled = true;
                    lblOverlayEditPackage.Visible = false;
                    dgvOverlayEditPackage.Visible = false;
                    tabControl.SelectedTab = EditPackageTab; // switch to edit tab
                    InputDataToEditPackage(selectedPackage); //loads data to a package
                    LoadPackageIntoEditFields(selectedPackage); //fills fields from the package


                }
            }
            else
            {

                if (EditPackageProductsTab.Enabled == true)
                {
                    tabControl.SelectedTab = EditPackageProductsTab;
                    MessageBox.Show("An edit is already in process, Press Done to Continue",
                                          "Edit Already in Progress", MessageBoxButtons.OK);
                }
                else
                {
                    tabControl.SelectedTab = EditPackageTab;
                    MessageBox.Show("An edit is already in process, Press Save or Cancel to Continue",
                                    "Edit Already in Progress", MessageBoxButtons.OK);
                }
            }



        }
        //loads the data into fields inside the edit tab
        private void LoadPackageIntoEditFields(PackageManagerPackage selectedPackage)
        {
            //not nullable
            txtEditPackageID.Text = globalPackageID.ToString();
            txtEdiPackageName.Text = selectedPackage.PkgName.ToString();
            txtEditPackageDescription.Text = selectedPackage.PkgDesc.ToString();
            txtEditBasePrice.Text = (String.Format("{0:0.00}", selectedPackage.PkgBasePrice));

            //nullable
            if (selectedPackage.PkgStartDate == null)
            {
                dtpEditStartDate.CustomFormat = " ";
                dtpEditStartDate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpEditStartDate.Value = (DateTime)selectedPackage.PkgStartDate.Value.Date;
            }
            if (selectedPackage.PkgEndDate == null)
            {
                dtpEditEndDate.CustomFormat = " ";
                dtpEditEndDate.Format = DateTimePickerFormat.Custom;
            }
            else
            {
                dtpEditEndDate.Value = (DateTime)selectedPackage.PkgEndDate.Value.Date;
            }

            if (selectedPackage.PkgAgencyCommission == null)
            {
                txtEditAgencyCommission.Text = null;
            }
            else
            {
                txtEditAgencyCommission.Text = String.Format("{0:0.00}", Convert.ToDecimal(selectedPackage.PkgAgencyCommission));
            }
        }


        /// <summary>
        /// extracts data from datagridview's selected row and puts it into a package object
        /// </summary>
        /// <param name="selectedPackage"></param>
        /// <returns>Package</returns>
        private PackageManagerPackage InputDataToEditPackage(PackageManagerPackage selectedPackage)
        {

            int selectedRowIndex = dgvPackages.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvPackages.Rows[selectedRowIndex];
            //not nullable
            selectedPackage.PackageID = Convert.ToInt32(selectedRow.Cells["PackageID"].Value);
            globalPackageID = selectedPackage.PackageID;
            selectedPackage.PkgName = (string)selectedRow.Cells["PkgName"].Value;
            selectedPackage.PkgDesc = (string)selectedRow.Cells["PkgDesc"].Value;
            selectedPackage.PkgBasePrice = (decimal)selectedRow.Cells["PkgBasePrice"].Value;
            //nullable
            if (selectedRow.Cells["PkgStartDate"].Value == null)
            {
                selectedPackage.PkgStartDate = null;
            }
            else
            {
                selectedPackage.PkgStartDate = (DateTime)selectedRow.Cells["PkgStartDate"].Value;
            }

            if (selectedRow.Cells["PkgEndDate"].Value == null)
            {
                selectedPackage.PkgEndDate = null;
            }
            else
            {
                selectedPackage.PkgEndDate = (DateTime)selectedRow.Cells["PkgEndDate"].Value;
            }

            if (selectedRow.Cells["PkgAgencyCommission"].Value == null)
            {
                selectedPackage.PkgAgencyCommission = null;
            }
            else
            {
                selectedPackage.PkgAgencyCommission = (decimal)selectedRow.Cells["PkgAgencyCommission"].Value;
            }

            LoadProductNameandSupplierName(selectedPackage.PackageID);
            if (cmbProducts.Items.Count == 0)
            {
                LoadProductsNamesToComboBox();
            }
            cmbProducts.SelectedIndex = 0;
            LoadSuppliersForProduct(selectedPackage.PackageID, cmbProducts.Items[0].ToString());

            return selectedPackage;
        }

        /// <summary>
        /// Loads suppliers for the slected product for selected Package
        /// </summary>
        /// <param name="PackageID"></param>
        /// <param name="ProductName"></param>
        private void LoadSuppliersForProduct(int PackageID, string ProductName)
        {
            lstSuppliers.Items.Clear();
            List<PackageManagerSuppliers> suppliers = PackageManagerProductsDB.GetSuppliersByProductName(PackageID, ProductName);
            foreach (PackageManagerSuppliers supplier in suppliers)
            {
                lstSuppliers.Items.Add(supplier.SupName);
            }
        }

        /// <summary>
        /// loads Products to the comboBox
        /// </summary>
        /// <returns></returns>
        private List<PackageManagerProducts> LoadProductsNamesToComboBox()
        {
            List<PackageManagerProducts> products = PackageManagerProductsDB.GetProducts();
            foreach (PackageManagerProducts product in products)
            {
                cmbProducts.Items.Add(Convert.ToString(product.ProdName));
            }

            return products;
        }
        /// <summary>
        /// Loads the ProductName and SupplierName Datagridview
        /// </summary>
        /// <param name="PackageID"></param>
        private void LoadProductNameandSupplierName(int PackageID)
        {
            List<PackageMangerProductSuppliers> ProductsList = PackageManagerPackageDB.GetProductsSuppliersByPackageID(PackageID);
            dgvEditProducts.DataSource = ProductsList;
            StyleProductNameSupplierNameDataGridView();
        }



        /// <summary>
        /// Adds product_supplier To the selected package
        /// </summary>
        private void AddProductSupplierToPackage()
        {
            if (lstSuppliers.SelectedIndex >= 0)
            {
                string supplierName = lstSuppliers.SelectedItem.ToString();
                string productName = cmbProducts.Text;

                PackageManagerProductsDB.AddSupplierAndProduct(globalPackageID, productName, supplierName);
                RefreshAllViews();

                LoadSuppliersForProduct(globalPackageID, productName);
            }
            else
            {
                MessageBox.Show("Please select a supplier from the list to continue", "No Supplier Selected");
                cmbProducts.SelectedIndex = 0;
            }


        }
        /// <summary>
        /// Removes the Product_Supplier from the selected Package
        /// </summary>
        private void RemoveProductSupplierFromPackage()
        {
            int selectedRowIndex;
            string ProductName;
            string SupplierName;
            string selectedProduct;
            selectedProduct = cmbProducts.Text;
            if (dgvEditProducts.SelectedCells.Count > 0)
            {
                selectedRowIndex = dgvEditProducts.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = dgvEditProducts.Rows[selectedRowIndex];
                //not nullable
                ProductName = (selectedRow.Cells["ProdName"].Value).ToString();
                SupplierName = (selectedRow.Cells["SupplierName"].Value).ToString();
                PackageManagerProductsDB.RemoveSupplierAndProduct(globalPackageID, ProductName, SupplierName);
                RefreshAllViews();
                if (selectedProduct != "")
                {
                    LoadSuppliersForProduct(globalPackageID, selectedProduct);
                }
            }
            else
            {
                MessageBox.Show("This Package doesn't contain any products to be removed", "No Products");
            }


        }

        /// <summary>
        /// Saves the edited package information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditSave_Click(object sender, EventArgs e)
        {
            bool editPackage = false;
            if (EditPackagehasValues())
            {
                if (txtEditAgencyCommission.Text != "") //not null
                {
                    if (Validator.IsNonNegativeDecimal(txtEditAgencyCommission, "Package Agency Commission"))
                    {
                        if (Convert.ToDecimal(txtEditAgencyCommission.Text) > Convert.ToDecimal(txtEditBasePrice.Text))
                        {
                            MessageBox.Show($"Commission cannot be greater than the Base Price: {txtEditBasePrice.Text}");
                            editPackage = false;
                        }
                        else
                        {
                            editPackage = true;
                        }
                    }
                    else
                    {
                        editPackage = false;
                    }

                }
                else
                {
                    editPackage = true;
                }

                if ((dtpEditStartDate.Format == DateTimePickerFormat.Long) && (dtpEditEndDate.Format == DateTimePickerFormat.Long))
                {
                    if (editPackage == true)
                    {
                        if (dtpEditEndDate.Value.Date < dtpEditStartDate.Value.Date)
                        {
                            MessageBox.Show("End date can't be before start date", "Invalid Date");
                            editPackage = false;
                        }
                        else
                        {
                            editPackage = true;
                        }
                    }
                    else
                    {
                        editPackage = false;
                    }

                }
                else
                {
                    if (editPackage == true)
                    {
                        editPackage = true;
                    }

                }

                if (editPackage == true)
                {
                    EditPackage();

                }

            }
        }

        private void EditPackage()
        {
            try
            {
                DataToUpdatePackage(editPackage);
                PackageManagerPackageDB.UpdatePackage(editPackage);
                MessageBox.Show($"The Package with ID: {editPackage.PackageID} has been updated", "Package Updated");
                Done();
                RefreshAllViews();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Refreshes ViewPackages Datagridview and ProductSupplier Datagridview
        /// </summary>
        private void RefreshAllViews()
        {
            LoadViewPackageDataGridView();
            LoadProductNameandSupplierName(globalPackageID);
        }

        /// <summary>
        /// grabs data from edit fields and builds a package
        /// </summary>
        /// <param name="package"></param>
        /// <returns>Package</returns>
        private PackageManagerPackage DataToUpdatePackage(PackageManagerPackage package)
        {
            package.PackageID = globalPackageID;
            package.PkgName = txtEdiPackageName.Text;
            package.PkgDesc = txtEditPackageDescription.Text;
            package.PkgBasePrice = Convert.ToDecimal(txtEditBasePrice.Text);
            //nullable dates
            if (dtpEditStartDate.Format != DateTimePickerFormat.Long)
            {
                package.PkgStartDate = null;
            }
            else
            {
                package.PkgStartDate = (DateTime)dtpEditStartDate.Value.Date;
            }

            if (dtpEditEndDate.Format != DateTimePickerFormat.Long)
            {
                package.PkgEndDate = null;
            }
            else
            {
                package.PkgEndDate = (DateTime)dtpEditEndDate.Value.Date;
            }

            //Check Commission
            if (txtEditAgencyCommission.Text != "") // not empty
            {
                decimal? packageAgencyCommission;
                packageAgencyCommission = Convert.ToDecimal(txtEditAgencyCommission.Text);
                package.PkgAgencyCommission = PriceCommissionValidate(package.PkgBasePrice, packageAgencyCommission, "edit");
            }
            else
            {
                package.PkgAgencyCommission = null;
            }

            return package;
        }
        private void DeleteSelectedPackage()
        {
            int selectedRowIndex = dgvPackages.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = dgvPackages.Rows[selectedRowIndex];
            //not nullable
            int PackageID = Convert.ToInt32(selectedRow.Cells["PackageID"].Value);
            string PackageName = (string)selectedRow.Cells["PkgName"].Value;
            string PackageDescription = (string)selectedRow.Cells["PkgDesc"].Value;
            decimal PackageBaseprice = (decimal)selectedRow.Cells["PkgBasePrice"].Value;

            bool productsExist = PackageManagerPackageDB.ProductsExist(PackageID);
            if (productsExist == true)
            {
                DialogResult result = MessageBox.Show("There are one or more products in the Package, Would you like to still delete the package\n\n" +
                                 "\tClick Yes to continue Deleting the Package\n" +
                                 "\tClick No to Cancel", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    PackageManagerPackageDB.RemovePackage(PackageID);
                    RefreshAllViews();
                    MessageBox.Show($"Package with PackagID: {PackageID} has been deleted", "Package Deleted");

                }
            }
            else
            {
                PackageManagerPackageDB.RemovePackage(PackageID);
                RefreshAllViews();
                MessageBox.Show($"Package with PackagID: {PackageID} has been deleted", "Package Deleted");

            }



        }

        private bool AddPackagehasValues()
        {
            return
                Validator.IsPresent(txtPackageName, "Package Name") &&
                Validator.Length(txtPackageName, "Package Name", 50) &&
                Validator.IsPresent(txtPackageDescription, "Package Description") &&
                Validator.Length(txtPackageDescription, "Package Description", 50) &&
                Validator.IsPresent(txtPackageBasePrice, "Package Base Price") &&
                Validator.IsNonNegativeDecimal(txtPackageBasePrice, "Package Base Price");

        }
        private bool EditPackagehasValues()
        {

            return
                Validator.IsPresent(txtEdiPackageName, "Package Name") &&
                Validator.Length(txtEdiPackageName, "Package Name", 50) &&
                Validator.IsPresent(txtEditPackageDescription, "Package Description") &&
                Validator.Length(txtEditPackageDescription, "Package Description", 50) &&
                Validator.IsPresent(txtEditBasePrice, "Package Base Price") &&
                Validator.IsNonNegativeDecimal(txtEditBasePrice, "Package Base Price");

        }

        //datetimepicker start date clears
        private void btnClearStartDate_Click(object sender, EventArgs e)
        {
            dtpPackageStartDate.CustomFormat = " ";
            dtpPackageStartDate.Format = DateTimePickerFormat.Custom;
        }
        //datetimepicker end date clears
        private void btnClearEndDate_Click(object sender, EventArgs e)
        {
            dtpPackageEndDate.CustomFormat = " ";
            dtpPackageEndDate.Format = DateTimePickerFormat.Custom;
        }
        //datetimepicker value changes, the format goes back to long
        private void dtpPackageStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpPackageStartDate.Format = DateTimePickerFormat.Long;
        }
        //datetimepicker value changes, the format goes back to long
        private void dtpPackageEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpPackageEndDate.Format = DateTimePickerFormat.Long;
        }
        private void dtpEditStartDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEditStartDate.Format = DateTimePickerFormat.Long;
        }
        private void dtpEditEndDate_ValueChanged(object sender, EventArgs e)
        {
            dtpEditEndDate.Format = DateTimePickerFormat.Long;
        }

        private void btnAddProductToPackage_Click(object sender, EventArgs e)
        {
            AddProductSupplierToPackage();
        }

        private void btnRemoveProductFromPackage_Click(object sender, EventArgs e)
        {
            RemoveProductSupplierFromPackage();
        }

        private void btnEditClearStartDate_Click(object sender, EventArgs e)
        {
            dtpEditStartDate.CustomFormat = " ";
            dtpEditStartDate.Format = DateTimePickerFormat.Custom;
        }

        private void btnEditClearEndDate_Click(object sender, EventArgs e)
        {
            dtpEditEndDate.CustomFormat = " ";
            dtpEditEndDate.Format = DateTimePickerFormat.Custom;
        }

        /// <summary>
        /// Changes tab to View Packages and disables the edit tabs
        /// </summary>
        private void Done()
        {
            tabControl.SelectedTab = ViewPackagesTab;
            globalPackageID = -1;
            EditPackageTab.Enabled = false;
            EditPackageProductsTab.Enabled = false;

            lblOverlayEditPackage.Visible = true;
            lblOverlayEditProducts.Visible = true;

            dgvOverlayEditPackage.Visible = true;
            dgvOverlayEditProducts.Visible = true;

        }

        private void btnDeleteSelectedPackage_Click(object sender, EventArgs e)
        {
            DeleteSelectedPackage();
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab == AddPackageTab)
            {
                txtPackageName.Focus();
            }
        }

        private void btnEditClear_Click(object sender, EventArgs e)
        {
            txtEdiPackageName.Text = "";
            txtEditPackageDescription.Text = "";
            txtEditBasePrice.Text = "";
            txtEditAgencyCommission.Text = "";
        }

        private void btnEditProductsPackage_Click(object sender, EventArgs e)
        {
            if (globalPackageID == -1)
            {

                PackageManagerPackage selectedPackage = new PackageManagerPackage();
                if (dgvPackages.SelectedCells.Count > 0)
                {
                    EditPackageProductsTab.Enabled = true;
                    lblOverlayEditProducts.Visible = false;
                    dgvOverlayEditProducts.Visible = false;
                    tabControl.SelectedTab = EditPackageProductsTab; // switch to editproducts tab
                    InputDataToEditPackage(selectedPackage); //loads data to a package
                }
            }
            else
            {
                if (EditPackageProductsTab.Enabled == true)
                {
                    tabControl.SelectedTab = EditPackageProductsTab;
                    MessageBox.Show("An edit is already in process, Press Done to Continue",
                                          "Edit Already in Progress", MessageBoxButtons.OK);
                }
                else
                {
                    tabControl.SelectedTab = EditPackageTab;
                    MessageBox.Show("An edit is already in process, Press Save or Cancel to Continue",
                                    "Edit Already in Progress", MessageBoxButtons.OK);
                }


            }
        }

        private void btnCancelEdit_Click(object sender, EventArgs e)
        {
            Done();
        }

        private void btnAddProductToPackage_Click_1(object sender, EventArgs e)
        {
            AddProductSupplierToPackage();
        }

        private void btnRemoveProductFromPackage_Click_1(object sender, EventArgs e)
        {
            RemoveProductSupplierFromPackage();
        }

        private void btnCompleteEditing_Click(object sender, EventArgs e)
        {
            Done();
        }

        private void cmbProducts_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string productName = cmbProducts.Text;
            LoadSuppliersForProduct(globalPackageID, productName);
        }
    }
}
