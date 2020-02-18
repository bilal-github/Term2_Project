namespace Team5_Workshop4
{
    partial class frmPackageManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPackages = new System.Windows.Forms.DataGridView();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.ViewPackagesTab = new System.Windows.Forms.TabPage();
            this.btnEditProductsPackage = new System.Windows.Forms.Button();
            this.btnDeleteSelectedPackage = new System.Windows.Forms.Button();
            this.btnEditSelectedPackage = new System.Windows.Forms.Button();
            this.AddPackageTab = new System.Windows.Forms.TabPage();
            this.btnClearStartDate = new System.Windows.Forms.Button();
            this.btnClearEndDate = new System.Windows.Forms.Button();
            this.btnAddPackage = new System.Windows.Forms.Button();
            this.txtPackageBasePrice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPackageAgencyCommission = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPackageDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtpPackageEndDate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpPackageStartDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EditPackageTab = new System.Windows.Forms.TabPage();
            this.lblOverlayEditPackage = new System.Windows.Forms.Label();
            this.dgvOverlayEditPackage = new System.Windows.Forms.DataGridView();
            this.txtEditPackageID = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnEditSave = new System.Windows.Forms.Button();
            this.btnEditClearStartDate = new System.Windows.Forms.Button();
            this.btnEditClearEndDate = new System.Windows.Forms.Button();
            this.txtEditBasePrice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEditAgencyCommission = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEditPackageDescription = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpEditEndDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpEditStartDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEdiPackageName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnEditClear = new System.Windows.Forms.Button();
            this.btnCancelEdit = new System.Windows.Forms.Button();
            this.EditPackageProductsTab = new System.Windows.Forms.TabPage();
            this.lblOverlayEditProducts = new System.Windows.Forms.Label();
            this.dgvOverlayEditProducts = new System.Windows.Forms.DataGridView();
            this.btnRemoveProductFromPackage = new System.Windows.Forms.Button();
            this.btnAddProductToPackage = new System.Windows.Forms.Button();
            this.cmbProducts = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lstSuppliers = new System.Windows.Forms.ListBox();
            this.dgvEditProducts = new System.Windows.Forms.DataGridView();
            this.btnCompleteEditing = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).BeginInit();
            this.tabControl.SuspendLayout();
            this.ViewPackagesTab.SuspendLayout();
            this.AddPackageTab.SuspendLayout();
            this.EditPackageTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlayEditPackage)).BeginInit();
            this.EditPackageProductsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlayEditProducts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPackages
            // 
            this.dgvPackages.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPackages.Location = new System.Drawing.Point(6, 6);
            this.dgvPackages.Name = "dgvPackages";
            this.dgvPackages.RowHeadersWidth = 51;
            this.dgvPackages.RowTemplate.Height = 24;
            this.dgvPackages.Size = new System.Drawing.Size(1509, 401);
            this.dgvPackages.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.ViewPackagesTab);
            this.tabControl.Controls.Add(this.AddPackageTab);
            this.tabControl.Controls.Add(this.EditPackageTab);
            this.tabControl.Controls.Add(this.EditPackageProductsTab);
            this.tabControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(2, 7);
            this.tabControl.Name = "tabControl";
            this.tabControl.Padding = new System.Drawing.Point(20, 3);
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1541, 716);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl.TabIndex = 1;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // ViewPackagesTab
            // 
            this.ViewPackagesTab.Controls.Add(this.btnEditProductsPackage);
            this.ViewPackagesTab.Controls.Add(this.btnDeleteSelectedPackage);
            this.ViewPackagesTab.Controls.Add(this.btnEditSelectedPackage);
            this.ViewPackagesTab.Controls.Add(this.dgvPackages);
            this.ViewPackagesTab.Location = new System.Drawing.Point(4, 34);
            this.ViewPackagesTab.Name = "ViewPackagesTab";
            this.ViewPackagesTab.Padding = new System.Windows.Forms.Padding(3);
            this.ViewPackagesTab.Size = new System.Drawing.Size(1533, 678);
            this.ViewPackagesTab.TabIndex = 0;
            this.ViewPackagesTab.Text = "View Packages";
            this.ViewPackagesTab.UseVisualStyleBackColor = true;
            // 
            // btnEditProductsPackage
            // 
            this.btnEditProductsPackage.BackColor = System.Drawing.Color.Aqua;
            this.btnEditProductsPackage.Location = new System.Drawing.Point(504, 437);
            this.btnEditProductsPackage.Name = "btnEditProductsPackage";
            this.btnEditProductsPackage.Size = new System.Drawing.Size(368, 70);
            this.btnEditProductsPackage.TabIndex = 3;
            this.btnEditProductsPackage.Text = "Edit Products in Package";
            this.btnEditProductsPackage.UseVisualStyleBackColor = false;
            this.btnEditProductsPackage.Click += new System.EventHandler(this.btnEditProductsPackage_Click);
            // 
            // btnDeleteSelectedPackage
            // 
            this.btnDeleteSelectedPackage.BackColor = System.Drawing.Color.DarkRed;
            this.btnDeleteSelectedPackage.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDeleteSelectedPackage.Location = new System.Drawing.Point(973, 437);
            this.btnDeleteSelectedPackage.Name = "btnDeleteSelectedPackage";
            this.btnDeleteSelectedPackage.Size = new System.Drawing.Size(387, 70);
            this.btnDeleteSelectedPackage.TabIndex = 2;
            this.btnDeleteSelectedPackage.Text = "Delete Selected Package";
            this.btnDeleteSelectedPackage.UseVisualStyleBackColor = false;
            this.btnDeleteSelectedPackage.Click += new System.EventHandler(this.btnDeleteSelectedPackage_Click);
            // 
            // btnEditSelectedPackage
            // 
            this.btnEditSelectedPackage.BackColor = System.Drawing.Color.Aqua;
            this.btnEditSelectedPackage.Location = new System.Drawing.Point(77, 437);
            this.btnEditSelectedPackage.Name = "btnEditSelectedPackage";
            this.btnEditSelectedPackage.Size = new System.Drawing.Size(368, 70);
            this.btnEditSelectedPackage.TabIndex = 1;
            this.btnEditSelectedPackage.Text = "Edit Selected Package";
            this.btnEditSelectedPackage.UseVisualStyleBackColor = false;
            this.btnEditSelectedPackage.Click += new System.EventHandler(this.btnEditSelectedPackage_Click);
            // 
            // AddPackageTab
            // 
            this.AddPackageTab.Controls.Add(this.btnClearStartDate);
            this.AddPackageTab.Controls.Add(this.btnClearEndDate);
            this.AddPackageTab.Controls.Add(this.btnAddPackage);
            this.AddPackageTab.Controls.Add(this.txtPackageBasePrice);
            this.AddPackageTab.Controls.Add(this.label6);
            this.AddPackageTab.Controls.Add(this.txtPackageAgencyCommission);
            this.AddPackageTab.Controls.Add(this.label3);
            this.AddPackageTab.Controls.Add(this.txtPackageDescription);
            this.AddPackageTab.Controls.Add(this.label5);
            this.AddPackageTab.Controls.Add(this.dtpPackageEndDate);
            this.AddPackageTab.Controls.Add(this.label4);
            this.AddPackageTab.Controls.Add(this.dtpPackageStartDate);
            this.AddPackageTab.Controls.Add(this.label2);
            this.AddPackageTab.Controls.Add(this.txtPackageName);
            this.AddPackageTab.Controls.Add(this.label1);
            this.AddPackageTab.Location = new System.Drawing.Point(4, 34);
            this.AddPackageTab.Name = "AddPackageTab";
            this.AddPackageTab.Padding = new System.Windows.Forms.Padding(3);
            this.AddPackageTab.Size = new System.Drawing.Size(1533, 678);
            this.AddPackageTab.TabIndex = 1;
            this.AddPackageTab.Text = "Add Package";
            this.AddPackageTab.UseVisualStyleBackColor = true;
            // 
            // btnClearStartDate
            // 
            this.btnClearStartDate.BackColor = System.Drawing.Color.Aqua;
            this.btnClearStartDate.Location = new System.Drawing.Point(803, 93);
            this.btnClearStartDate.Name = "btnClearStartDate";
            this.btnClearStartDate.Size = new System.Drawing.Size(184, 43);
            this.btnClearStartDate.TabIndex = 3;
            this.btnClearStartDate.Text = "Clear Start Date";
            this.btnClearStartDate.UseVisualStyleBackColor = false;
            this.btnClearStartDate.Click += new System.EventHandler(this.btnClearStartDate_Click);
            // 
            // btnClearEndDate
            // 
            this.btnClearEndDate.BackColor = System.Drawing.Color.Aqua;
            this.btnClearEndDate.Location = new System.Drawing.Point(803, 142);
            this.btnClearEndDate.Name = "btnClearEndDate";
            this.btnClearEndDate.Size = new System.Drawing.Size(184, 40);
            this.btnClearEndDate.TabIndex = 5;
            this.btnClearEndDate.Text = "Clear End Date";
            this.btnClearEndDate.UseVisualStyleBackColor = false;
            this.btnClearEndDate.Click += new System.EventHandler(this.btnClearEndDate_Click);
            // 
            // btnAddPackage
            // 
            this.btnAddPackage.BackColor = System.Drawing.Color.Aqua;
            this.btnAddPackage.FlatAppearance.BorderSize = 0;
            this.btnAddPackage.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAddPackage.Location = new System.Drawing.Point(461, 327);
            this.btnAddPackage.Name = "btnAddPackage";
            this.btnAddPackage.Size = new System.Drawing.Size(166, 54);
            this.btnAddPackage.TabIndex = 9;
            this.btnAddPackage.Text = "Submit";
            this.btnAddPackage.UseVisualStyleBackColor = false;
            this.btnAddPackage.Click += new System.EventHandler(this.btnAddPackage_Click);
            // 
            // txtPackageBasePrice
            // 
            this.txtPackageBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageBasePrice.Location = new System.Drawing.Point(397, 231);
            this.txtPackageBasePrice.Name = "txtPackageBasePrice";
            this.txtPackageBasePrice.Size = new System.Drawing.Size(376, 30);
            this.txtPackageBasePrice.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(88, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(194, 25);
            this.label6.TabIndex = 11;
            this.label6.Text = "Package Base Price:";
            // 
            // txtPackageAgencyCommission
            // 
            this.txtPackageAgencyCommission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageAgencyCommission.Location = new System.Drawing.Point(397, 273);
            this.txtPackageAgencyCommission.Name = "txtPackageAgencyCommission";
            this.txtPackageAgencyCommission.Size = new System.Drawing.Size(376, 30);
            this.txtPackageAgencyCommission.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(88, 276);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(280, 25);
            this.label3.TabIndex = 9;
            this.label3.Text = "Package Agency Commission:";
            // 
            // txtPackageDescription
            // 
            this.txtPackageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageDescription.Location = new System.Drawing.Point(397, 190);
            this.txtPackageDescription.Name = "txtPackageDescription";
            this.txtPackageDescription.Size = new System.Drawing.Size(376, 30);
            this.txtPackageDescription.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(197, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Package Description:";
            // 
            // dtpPackageEndDate
            // 
            this.dtpPackageEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPackageEndDate.Location = new System.Drawing.Point(397, 148);
            this.dtpPackageEndDate.Name = "dtpPackageEndDate";
            this.dtpPackageEndDate.Size = new System.Drawing.Size(376, 30);
            this.dtpPackageEndDate.TabIndex = 4;
            this.dtpPackageEndDate.ValueChanged += new System.EventHandler(this.dtpPackageEndDate_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(88, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Package End Date:";
            // 
            // dtpPackageStartDate
            // 
            this.dtpPackageStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpPackageStartDate.Location = new System.Drawing.Point(397, 105);
            this.dtpPackageStartDate.Name = "dtpPackageStartDate";
            this.dtpPackageStartDate.Size = new System.Drawing.Size(376, 30);
            this.dtpPackageStartDate.TabIndex = 2;
            this.dtpPackageStartDate.ValueChanged += new System.EventHandler(this.dtpPackageStartDate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(88, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(187, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Package Start Date:";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPackageName.Location = new System.Drawing.Point(397, 63);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(376, 30);
            this.txtPackageName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(88, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Package Name: ";
            // 
            // EditPackageTab
            // 
            this.EditPackageTab.Controls.Add(this.lblOverlayEditPackage);
            this.EditPackageTab.Controls.Add(this.dgvOverlayEditPackage);
            this.EditPackageTab.Controls.Add(this.txtEditPackageID);
            this.EditPackageTab.Controls.Add(this.label15);
            this.EditPackageTab.Controls.Add(this.btnEditSave);
            this.EditPackageTab.Controls.Add(this.btnEditClearStartDate);
            this.EditPackageTab.Controls.Add(this.btnEditClearEndDate);
            this.EditPackageTab.Controls.Add(this.txtEditBasePrice);
            this.EditPackageTab.Controls.Add(this.label7);
            this.EditPackageTab.Controls.Add(this.txtEditAgencyCommission);
            this.EditPackageTab.Controls.Add(this.label8);
            this.EditPackageTab.Controls.Add(this.txtEditPackageDescription);
            this.EditPackageTab.Controls.Add(this.label9);
            this.EditPackageTab.Controls.Add(this.dtpEditEndDate);
            this.EditPackageTab.Controls.Add(this.label10);
            this.EditPackageTab.Controls.Add(this.dtpEditStartDate);
            this.EditPackageTab.Controls.Add(this.label11);
            this.EditPackageTab.Controls.Add(this.txtEdiPackageName);
            this.EditPackageTab.Controls.Add(this.label12);
            this.EditPackageTab.Controls.Add(this.btnEditClear);
            this.EditPackageTab.Controls.Add(this.btnCancelEdit);
            this.EditPackageTab.Location = new System.Drawing.Point(4, 34);
            this.EditPackageTab.Name = "EditPackageTab";
            this.EditPackageTab.Size = new System.Drawing.Size(1533, 678);
            this.EditPackageTab.TabIndex = 2;
            this.EditPackageTab.Text = "Edit Package";
            this.EditPackageTab.UseVisualStyleBackColor = true;
            // 
            // lblOverlayEditPackage
            // 
            this.lblOverlayEditPackage.AutoSize = true;
            this.lblOverlayEditPackage.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlayEditPackage.ForeColor = System.Drawing.Color.Red;
            this.lblOverlayEditPackage.Location = new System.Drawing.Point(89, 190);
            this.lblOverlayEditPackage.Name = "lblOverlayEditPackage";
            this.lblOverlayEditPackage.Size = new System.Drawing.Size(1216, 58);
            this.lblOverlayEditPackage.TabIndex = 38;
            this.lblOverlayEditPackage.Text = "Select a package from View Packages to Start Editing";
            // 
            // dgvOverlayEditPackage
            // 
            this.dgvOverlayEditPackage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverlayEditPackage.Location = new System.Drawing.Point(-4, 2);
            this.dgvOverlayEditPackage.Name = "dgvOverlayEditPackage";
            this.dgvOverlayEditPackage.RowHeadersWidth = 51;
            this.dgvOverlayEditPackage.RowTemplate.Height = 24;
            this.dgvOverlayEditPackage.Size = new System.Drawing.Size(1537, 675);
            this.dgvOverlayEditPackage.TabIndex = 39;
            // 
            // txtEditPackageID
            // 
            this.txtEditPackageID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditPackageID.Location = new System.Drawing.Point(425, 54);
            this.txtEditPackageID.Name = "txtEditPackageID";
            this.txtEditPackageID.ReadOnly = true;
            this.txtEditPackageID.Size = new System.Drawing.Size(343, 30);
            this.txtEditPackageID.TabIndex = 37;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(61, 54);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(119, 25);
            this.label15.TabIndex = 36;
            this.label15.Text = "Package ID:";
            // 
            // btnEditSave
            // 
            this.btnEditSave.BackColor = System.Drawing.Color.Aqua;
            this.btnEditSave.Location = new System.Drawing.Point(1092, 174);
            this.btnEditSave.Name = "btnEditSave";
            this.btnEditSave.Size = new System.Drawing.Size(256, 56);
            this.btnEditSave.TabIndex = 9;
            this.btnEditSave.Text = "Save Changes";
            this.btnEditSave.UseVisualStyleBackColor = false;
            this.btnEditSave.Click += new System.EventHandler(this.btnEditSave_Click);
            // 
            // btnEditClearStartDate
            // 
            this.btnEditClearStartDate.BackColor = System.Drawing.Color.Aqua;
            this.btnEditClearStartDate.Location = new System.Drawing.Point(809, 260);
            this.btnEditClearStartDate.Name = "btnEditClearStartDate";
            this.btnEditClearStartDate.Size = new System.Drawing.Size(184, 33);
            this.btnEditClearStartDate.TabIndex = 5;
            this.btnEditClearStartDate.Text = "Clear Start Date";
            this.btnEditClearStartDate.UseVisualStyleBackColor = false;
            this.btnEditClearStartDate.Click += new System.EventHandler(this.btnEditClearStartDate_Click);
            // 
            // btnEditClearEndDate
            // 
            this.btnEditClearEndDate.BackColor = System.Drawing.Color.Aqua;
            this.btnEditClearEndDate.Location = new System.Drawing.Point(809, 304);
            this.btnEditClearEndDate.Name = "btnEditClearEndDate";
            this.btnEditClearEndDate.Size = new System.Drawing.Size(184, 33);
            this.btnEditClearEndDate.TabIndex = 7;
            this.btnEditClearEndDate.Text = "Clear End Date";
            this.btnEditClearEndDate.UseVisualStyleBackColor = false;
            this.btnEditClearEndDate.Click += new System.EventHandler(this.btnEditClearEndDate_Click);
            // 
            // txtEditBasePrice
            // 
            this.txtEditBasePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditBasePrice.Location = new System.Drawing.Point(425, 174);
            this.txtEditBasePrice.Name = "txtEditBasePrice";
            this.txtEditBasePrice.Size = new System.Drawing.Size(343, 30);
            this.txtEditBasePrice.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(61, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(194, 25);
            this.label7.TabIndex = 25;
            this.label7.Text = "Package Base Price:";
            // 
            // txtEditAgencyCommission
            // 
            this.txtEditAgencyCommission.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditAgencyCommission.Location = new System.Drawing.Point(425, 216);
            this.txtEditAgencyCommission.Name = "txtEditAgencyCommission";
            this.txtEditAgencyCommission.Size = new System.Drawing.Size(343, 30);
            this.txtEditAgencyCommission.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(61, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(280, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Package Agency Commission:";
            // 
            // txtEditPackageDescription
            // 
            this.txtEditPackageDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEditPackageDescription.Location = new System.Drawing.Point(425, 133);
            this.txtEditPackageDescription.Name = "txtEditPackageDescription";
            this.txtEditPackageDescription.Size = new System.Drawing.Size(343, 30);
            this.txtEditPackageDescription.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(61, 133);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(197, 25);
            this.label9.TabIndex = 21;
            this.label9.Text = "Package Description:";
            // 
            // dtpEditEndDate
            // 
            this.dtpEditEndDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEditEndDate.Location = new System.Drawing.Point(425, 305);
            this.dtpEditEndDate.Name = "dtpEditEndDate";
            this.dtpEditEndDate.Size = new System.Drawing.Size(343, 30);
            this.dtpEditEndDate.TabIndex = 6;
            this.dtpEditEndDate.ValueChanged += new System.EventHandler(this.dtpEditEndDate_ValueChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(64, 308);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(181, 25);
            this.label10.TabIndex = 19;
            this.label10.Text = "Package End Date:";
            // 
            // dtpEditStartDate
            // 
            this.dtpEditStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpEditStartDate.Location = new System.Drawing.Point(425, 261);
            this.dtpEditStartDate.Name = "dtpEditStartDate";
            this.dtpEditStartDate.Size = new System.Drawing.Size(343, 30);
            this.dtpEditStartDate.TabIndex = 4;
            this.dtpEditStartDate.ValueChanged += new System.EventHandler(this.dtpEditStartDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(63, 264);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(187, 25);
            this.label11.TabIndex = 17;
            this.label11.Text = "Package Start Date:";
            // 
            // txtEdiPackageName
            // 
            this.txtEdiPackageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEdiPackageName.Location = new System.Drawing.Point(425, 90);
            this.txtEdiPackageName.Name = "txtEdiPackageName";
            this.txtEdiPackageName.Size = new System.Drawing.Size(343, 30);
            this.txtEdiPackageName.TabIndex = 0;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(61, 90);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(157, 25);
            this.label12.TabIndex = 15;
            this.label12.Text = "Package Name: ";
            // 
            // btnEditClear
            // 
            this.btnEditClear.BackColor = System.Drawing.Color.Aqua;
            this.btnEditClear.Location = new System.Drawing.Point(1092, 59);
            this.btnEditClear.Name = "btnEditClear";
            this.btnEditClear.Size = new System.Drawing.Size(256, 56);
            this.btnEditClear.TabIndex = 8;
            this.btnEditClear.Text = "Clear Form";
            this.btnEditClear.UseVisualStyleBackColor = false;
            this.btnEditClear.Click += new System.EventHandler(this.btnEditClear_Click);
            // 
            // btnCancelEdit
            // 
            this.btnCancelEdit.BackColor = System.Drawing.Color.DarkRed;
            this.btnCancelEdit.ForeColor = System.Drawing.Color.White;
            this.btnCancelEdit.Location = new System.Drawing.Point(1092, 292);
            this.btnCancelEdit.Name = "btnCancelEdit";
            this.btnCancelEdit.Size = new System.Drawing.Size(256, 56);
            this.btnCancelEdit.TabIndex = 10;
            this.btnCancelEdit.Text = "Cancel";
            this.btnCancelEdit.UseVisualStyleBackColor = false;
            this.btnCancelEdit.Click += new System.EventHandler(this.btnCancelEdit_Click);
            // 
            // EditPackageProductsTab
            // 
            this.EditPackageProductsTab.Controls.Add(this.lblOverlayEditProducts);
            this.EditPackageProductsTab.Controls.Add(this.dgvOverlayEditProducts);
            this.EditPackageProductsTab.Controls.Add(this.btnRemoveProductFromPackage);
            this.EditPackageProductsTab.Controls.Add(this.btnAddProductToPackage);
            this.EditPackageProductsTab.Controls.Add(this.cmbProducts);
            this.EditPackageProductsTab.Controls.Add(this.label14);
            this.EditPackageProductsTab.Controls.Add(this.label13);
            this.EditPackageProductsTab.Controls.Add(this.lstSuppliers);
            this.EditPackageProductsTab.Controls.Add(this.dgvEditProducts);
            this.EditPackageProductsTab.Controls.Add(this.btnCompleteEditing);
            this.EditPackageProductsTab.Location = new System.Drawing.Point(4, 34);
            this.EditPackageProductsTab.Name = "EditPackageProductsTab";
            this.EditPackageProductsTab.Size = new System.Drawing.Size(1533, 678);
            this.EditPackageProductsTab.TabIndex = 3;
            this.EditPackageProductsTab.Text = "Edit Products In Package";
            this.EditPackageProductsTab.UseVisualStyleBackColor = true;
            // 
            // lblOverlayEditProducts
            // 
            this.lblOverlayEditProducts.AutoSize = true;
            this.lblOverlayEditProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlayEditProducts.ForeColor = System.Drawing.Color.Red;
            this.lblOverlayEditProducts.Location = new System.Drawing.Point(145, 252);
            this.lblOverlayEditProducts.Name = "lblOverlayEditProducts";
            this.lblOverlayEditProducts.Size = new System.Drawing.Size(1216, 58);
            this.lblOverlayEditProducts.TabIndex = 43;
            this.lblOverlayEditProducts.Text = "Select a package from View Packages to Start Editing";
            // 
            // dgvOverlayEditProducts
            // 
            this.dgvOverlayEditProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOverlayEditProducts.Location = new System.Drawing.Point(-4, 3);
            this.dgvOverlayEditProducts.Name = "dgvOverlayEditProducts";
            this.dgvOverlayEditProducts.RowHeadersWidth = 51;
            this.dgvOverlayEditProducts.RowTemplate.Height = 24;
            this.dgvOverlayEditProducts.Size = new System.Drawing.Size(1537, 675);
            this.dgvOverlayEditProducts.TabIndex = 44;
            // 
            // btnRemoveProductFromPackage
            // 
            this.btnRemoveProductFromPackage.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveProductFromPackage.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProductFromPackage.Location = new System.Drawing.Point(648, 193);
            this.btnRemoveProductFromPackage.Name = "btnRemoveProductFromPackage";
            this.btnRemoveProductFromPackage.Size = new System.Drawing.Size(158, 58);
            this.btnRemoveProductFromPackage.TabIndex = 42;
            this.btnRemoveProductFromPackage.Text = "<< Remove ";
            this.btnRemoveProductFromPackage.UseVisualStyleBackColor = false;
            this.btnRemoveProductFromPackage.Click += new System.EventHandler(this.btnRemoveProductFromPackage_Click_1);
            // 
            // btnAddProductToPackage
            // 
            this.btnAddProductToPackage.BackColor = System.Drawing.Color.Aqua;
            this.btnAddProductToPackage.Location = new System.Drawing.Point(648, 105);
            this.btnAddProductToPackage.Name = "btnAddProductToPackage";
            this.btnAddProductToPackage.Size = new System.Drawing.Size(159, 56);
            this.btnAddProductToPackage.TabIndex = 41;
            this.btnAddProductToPackage.Text = "Add >>";
            this.btnAddProductToPackage.UseVisualStyleBackColor = false;
            this.btnAddProductToPackage.Click += new System.EventHandler(this.btnAddProductToPackage_Click_1);
            // 
            // cmbProducts
            // 
            this.cmbProducts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProducts.FormattingEnabled = true;
            this.cmbProducts.Location = new System.Drawing.Point(197, 62);
            this.cmbProducts.Name = "cmbProducts";
            this.cmbProducts.Size = new System.Drawing.Size(398, 33);
            this.cmbProducts.TabIndex = 40;
            this.cmbProducts.SelectedIndexChanged += new System.EventHandler(this.cmbProducts_SelectedIndexChanged_1);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(59, 65);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(95, 25);
            this.label14.TabIndex = 39;
            this.label14.Text = "Products:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(59, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 25);
            this.label13.TabIndex = 38;
            this.label13.Text = "Suppliers:";
            // 
            // lstSuppliers
            // 
            this.lstSuppliers.FormattingEnabled = true;
            this.lstSuppliers.ItemHeight = 25;
            this.lstSuppliers.Location = new System.Drawing.Point(197, 121);
            this.lstSuppliers.Name = "lstSuppliers";
            this.lstSuppliers.Size = new System.Drawing.Size(398, 229);
            this.lstSuppliers.TabIndex = 37;
            // 
            // dgvEditProducts
            // 
            this.dgvEditProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditProducts.Location = new System.Drawing.Point(848, 65);
            this.dgvEditProducts.Name = "dgvEditProducts";
            this.dgvEditProducts.RowHeadersWidth = 51;
            this.dgvEditProducts.RowTemplate.Height = 24;
            this.dgvEditProducts.Size = new System.Drawing.Size(617, 303);
            this.dgvEditProducts.TabIndex = 36;
            // 
            // btnCompleteEditing
            // 
            this.btnCompleteEditing.BackColor = System.Drawing.Color.DarkRed;
            this.btnCompleteEditing.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompleteEditing.ForeColor = System.Drawing.Color.White;
            this.btnCompleteEditing.Location = new System.Drawing.Point(408, 397);
            this.btnCompleteEditing.Name = "btnCompleteEditing";
            this.btnCompleteEditing.Size = new System.Drawing.Size(299, 61);
            this.btnCompleteEditing.TabIndex = 45;
            this.btnCompleteEditing.Text = "Done";
            this.btnCompleteEditing.UseVisualStyleBackColor = false;
            this.btnCompleteEditing.Click += new System.EventHandler(this.btnCompleteEditing_Click);
            // 
            // frmPackageManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1547, 726);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPackageManager";
            this.Text = "frmPackageManager";
            this.Load += new System.EventHandler(this.frmPackageManager_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPackages)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.ViewPackagesTab.ResumeLayout(false);
            this.AddPackageTab.ResumeLayout(false);
            this.AddPackageTab.PerformLayout();
            this.EditPackageTab.ResumeLayout(false);
            this.EditPackageTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlayEditPackage)).EndInit();
            this.EditPackageProductsTab.ResumeLayout(false);
            this.EditPackageProductsTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOverlayEditProducts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPackages;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage ViewPackagesTab;
        private System.Windows.Forms.TabPage AddPackageTab;
        private System.Windows.Forms.DateTimePicker dtpPackageStartDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackageBasePrice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPackageAgencyCommission;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPackageDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtpPackageEndDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAddPackage;
        private System.Windows.Forms.Button btnClearStartDate;
        private System.Windows.Forms.Button btnClearEndDate;
        private System.Windows.Forms.TabPage EditPackageTab;
        private System.Windows.Forms.Button btnEditSelectedPackage;
        private System.Windows.Forms.Button btnEditClearStartDate;
        private System.Windows.Forms.Button btnEditClearEndDate;
        private System.Windows.Forms.TextBox txtEditBasePrice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEditAgencyCommission;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtEditPackageDescription;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpEditEndDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpEditStartDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEdiPackageName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnEditSave;
        private System.Windows.Forms.TextBox txtEditPackageID;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblOverlayEditPackage;
        private System.Windows.Forms.DataGridView dgvOverlayEditPackage;
        private System.Windows.Forms.Button btnDeleteSelectedPackage;
        private System.Windows.Forms.Button btnEditClear;
        private System.Windows.Forms.TabPage EditPackageProductsTab;
        private System.Windows.Forms.Label lblOverlayEditProducts;
        private System.Windows.Forms.DataGridView dgvOverlayEditProducts;
        private System.Windows.Forms.Button btnRemoveProductFromPackage;
        private System.Windows.Forms.Button btnAddProductToPackage;
        private System.Windows.Forms.ComboBox cmbProducts;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox lstSuppliers;
        private System.Windows.Forms.DataGridView dgvEditProducts;
        private System.Windows.Forms.Button btnEditProductsPackage;
        private System.Windows.Forms.Button btnCompleteEditing;
        private System.Windows.Forms.Button btnCancelEdit;
    }
}