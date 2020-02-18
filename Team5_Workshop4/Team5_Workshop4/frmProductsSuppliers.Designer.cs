namespace Team5_Workshop4
{
    partial class frmProductsSuppliers
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
            this.cmbSuppliers = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gvExistingProd = new System.Windows.Forms.DataGridView();
            this.btnAddProd = new System.Windows.Forms.Button();
            this.btnRemoveProd = new System.Windows.Forms.Button();
            this.gvAvailableProd = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gvExistingProd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAvailableProd)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbSuppliers
            // 
            this.cmbSuppliers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSuppliers.FormattingEnabled = true;
            this.cmbSuppliers.Location = new System.Drawing.Point(40, 70);
            this.cmbSuppliers.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSuppliers.Name = "cmbSuppliers";
            this.cmbSuppliers.Size = new System.Drawing.Size(488, 33);
            this.cmbSuppliers.TabIndex = 0;
            this.cmbSuppliers.SelectionChangeCommitted += new System.EventHandler(this.cmbSuppliers_SelectionChangeCommitted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier";
            // 
            // gvExistingProd
            // 
            this.gvExistingProd.AllowUserToAddRows = false;
            this.gvExistingProd.AllowUserToDeleteRows = false;
            this.gvExistingProd.AllowUserToResizeColumns = false;
            this.gvExistingProd.AllowUserToResizeRows = false;
            this.gvExistingProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvExistingProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvExistingProd.ColumnHeadersVisible = false;
            this.gvExistingProd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvExistingProd.Location = new System.Drawing.Point(313, 198);
            this.gvExistingProd.Name = "gvExistingProd";
            this.gvExistingProd.ReadOnly = true;
            this.gvExistingProd.RowHeadersVisible = false;
            this.gvExistingProd.RowHeadersWidth = 51;
            this.gvExistingProd.RowTemplate.Height = 24;
            this.gvExistingProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvExistingProd.Size = new System.Drawing.Size(215, 190);
            this.gvExistingProd.TabIndex = 2;
            // 
            // btnAddProd
            // 
            this.btnAddProd.BackColor = System.Drawing.Color.Aqua;
            this.btnAddProd.Location = new System.Drawing.Point(257, 227);
            this.btnAddProd.Name = "btnAddProd";
            this.btnAddProd.Size = new System.Drawing.Size(54, 47);
            this.btnAddProd.TabIndex = 3;
            this.btnAddProd.Text = ">>";
            this.btnAddProd.UseVisualStyleBackColor = false;
            this.btnAddProd.Click += new System.EventHandler(this.btnAddProd_Click);
            // 
            // btnRemoveProd
            // 
            this.btnRemoveProd.BackColor = System.Drawing.Color.Crimson;
            this.btnRemoveProd.ForeColor = System.Drawing.Color.White;
            this.btnRemoveProd.Location = new System.Drawing.Point(257, 304);
            this.btnRemoveProd.Name = "btnRemoveProd";
            this.btnRemoveProd.Size = new System.Drawing.Size(54, 47);
            this.btnRemoveProd.TabIndex = 3;
            this.btnRemoveProd.Text = "<<";
            this.btnRemoveProd.UseVisualStyleBackColor = false;
            this.btnRemoveProd.Click += new System.EventHandler(this.btnRemoveProd_Click);
            // 
            // gvAvailableProd
            // 
            this.gvAvailableProd.AllowUserToAddRows = false;
            this.gvAvailableProd.AllowUserToDeleteRows = false;
            this.gvAvailableProd.AllowUserToResizeColumns = false;
            this.gvAvailableProd.AllowUserToResizeRows = false;
            this.gvAvailableProd.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gvAvailableProd.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvAvailableProd.ColumnHeadersVisible = false;
            this.gvAvailableProd.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gvAvailableProd.Location = new System.Drawing.Point(40, 198);
            this.gvAvailableProd.Name = "gvAvailableProd";
            this.gvAvailableProd.ReadOnly = true;
            this.gvAvailableProd.RowHeadersVisible = false;
            this.gvAvailableProd.RowHeadersWidth = 51;
            this.gvAvailableProd.RowTemplate.Height = 24;
            this.gvAvailableProd.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gvAvailableProd.Size = new System.Drawing.Size(215, 190);
            this.gvAvailableProd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "Products to Add";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(308, 170);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Products Offered";
            // 
            // frmProductsSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(568, 426);
            this.ControlBox = false;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gvAvailableProd);
            this.Controls.Add(this.btnRemoveProd);
            this.Controls.Add(this.btnAddProd);
            this.Controls.Add(this.gvExistingProd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSuppliers);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmProductsSuppliers";
            this.Text = "Supplier Products";
            this.Load += new System.EventHandler(this.frmProductsSuppliers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvExistingProd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvAvailableProd)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSuppliers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gvExistingProd;
        private System.Windows.Forms.Button btnAddProd;
        private System.Windows.Forms.Button btnRemoveProd;
        private System.Windows.Forms.DataGridView gvAvailableProd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}