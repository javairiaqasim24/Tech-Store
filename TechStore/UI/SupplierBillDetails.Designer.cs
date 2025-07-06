namespace TechStore
{
    partial class SupplierBillDetails
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblPendingAmount = new System.Windows.Forms.Label();
            this.lblPaidAmount = new System.Windows.Forms.Label();
            this.lblTotalAmount = new System.Windows.Forms.Label();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.btnPrintBill = new System.Windows.Forms.Button();
            this.dgvPaymentHistory = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnAddPayment = new System.Windows.Forms.Button();
            this.dgvBillProducts = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.lblPendingAmount);
            this.panel2.Controls.Add(this.lblPaidAmount);
            this.panel2.Controls.Add(this.lblTotalAmount);
            this.panel2.Controls.Add(this.lblSupplierName);
            this.panel2.Controls.Add(this.btnPrintBill);
            this.panel2.Controls.Add(this.dgvPaymentHistory);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnBack);
            this.panel2.Controls.Add(this.btnAddPayment);
            this.panel2.Controls.Add(this.dgvBillProducts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1878, 1078);
            this.panel2.TabIndex = 10;
            // 
            // lblPendingAmount
            // 
            this.lblPendingAmount.AutoSize = true;
            this.lblPendingAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPendingAmount.Location = new System.Drawing.Point(81, 417);
            this.lblPendingAmount.Name = "lblPendingAmount";
            this.lblPendingAmount.Size = new System.Drawing.Size(70, 25);
            this.lblPendingAmount.TabIndex = 14;
            this.lblPendingAmount.Text = "label2";
            // 
            // lblPaidAmount
            // 
            this.lblPaidAmount.AutoSize = true;
            this.lblPaidAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidAmount.Location = new System.Drawing.Point(81, 374);
            this.lblPaidAmount.Name = "lblPaidAmount";
            this.lblPaidAmount.Size = new System.Drawing.Size(70, 25);
            this.lblPaidAmount.TabIndex = 13;
            this.lblPaidAmount.Text = "label2";
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.AutoSize = true;
            this.lblTotalAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAmount.Location = new System.Drawing.Point(81, 325);
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.Size = new System.Drawing.Size(70, 25);
            this.lblTotalAmount.TabIndex = 12;
            this.lblTotalAmount.Text = "label2";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.Location = new System.Drawing.Point(81, 275);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(70, 25);
            this.lblSupplierName.TabIndex = 11;
            this.lblSupplierName.Text = "label2";
            // 
            // btnPrintBill
            // 
            this.btnPrintBill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnPrintBill.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrintBill.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintBill.ForeColor = System.Drawing.Color.White;
            this.btnPrintBill.Location = new System.Drawing.Point(1411, 252);
            this.btnPrintBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnPrintBill.Name = "btnPrintBill";
            this.btnPrintBill.Size = new System.Drawing.Size(134, 48);
            this.btnPrintBill.TabIndex = 10;
            this.btnPrintBill.Text = "Print";
            this.btnPrintBill.UseVisualStyleBackColor = false;
            // 
            // dgvPaymentHistory
            // 
            this.dgvPaymentHistory.AllowUserToAddRows = false;
            this.dgvPaymentHistory.AllowUserToDeleteRows = false;
            this.dgvPaymentHistory.AllowUserToResizeColumns = false;
            this.dgvPaymentHistory.AllowUserToResizeRows = false;
            this.dgvPaymentHistory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPaymentHistory.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvPaymentHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvPaymentHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPaymentHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPaymentHistory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPaymentHistory.Location = new System.Drawing.Point(1203, 596);
            this.dgvPaymentHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvPaymentHistory.Name = "dgvPaymentHistory";
            this.dgvPaymentHistory.RowHeadersWidth = 62;
            this.dgvPaymentHistory.RowTemplate.Height = 28;
            this.dgvPaymentHistory.Size = new System.Drawing.Size(585, 328);
            this.dgvPaymentHistory.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1936, 226);
            this.panel1.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(395, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(684, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Supplier Billing Records";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBack.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBack.ForeColor = System.Drawing.Color.White;
            this.btnBack.Location = new System.Drawing.Point(1243, 252);
            this.btnBack.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(125, 48);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // btnAddPayment
            // 
            this.btnAddPayment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnAddPayment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddPayment.ForeColor = System.Drawing.Color.White;
            this.btnAddPayment.Location = new System.Drawing.Point(1600, 252);
            this.btnAddPayment.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPayment.Name = "btnAddPayment";
            this.btnAddPayment.Size = new System.Drawing.Size(188, 48);
            this.btnAddPayment.TabIndex = 2;
            this.btnAddPayment.Text = "Add Payment";
            this.btnAddPayment.UseVisualStyleBackColor = false;
            this.btnAddPayment.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // dgvBillProducts
            // 
            this.dgvBillProducts.AllowUserToAddRows = false;
            this.dgvBillProducts.AllowUserToDeleteRows = false;
            this.dgvBillProducts.AllowUserToResizeColumns = false;
            this.dgvBillProducts.AllowUserToResizeRows = false;
            this.dgvBillProducts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBillProducts.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBillProducts.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillProducts.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBillProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillProducts.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvBillProducts.Location = new System.Drawing.Point(68, 596);
            this.dgvBillProducts.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBillProducts.Name = "dgvBillProducts";
            this.dgvBillProducts.RowHeadersWidth = 62;
            this.dgvBillProducts.RowTemplate.Height = 28;
            this.dgvBillProducts.Size = new System.Drawing.Size(1041, 343);
            this.dgvBillProducts.TabIndex = 0;
            this.dgvBillProducts.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingRecords_CellClick);
            // 
            // SupplierBillDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1878, 1078);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SupplierBillDetails";
            this.Text = "Supplier Billing Records Overview";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BillingRecordsOverview_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPaymentHistory)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnAddPayment;
        private System.Windows.Forms.DataGridView dgvBillProducts;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvPaymentHistory;
        private System.Windows.Forms.Button btnPrintBill;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblPendingAmount;
        private System.Windows.Forms.Label lblPaidAmount;
        private System.Windows.Forms.Label lblTotalAmount;
    }
}

