namespace TechStore
{
    partial class BillingRecordsOverview
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
            this.paneledit = new System.Windows.Forms.Panel();
            this.txtremarks = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtpayment = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtamount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btncancle1 = new FontAwesome.Sharp.IconButton();
            this.btnsave1 = new FontAwesome.Sharp.IconButton();
            this.txtbill = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtname1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvBillingRecords = new System.Windows.Forms.DataGridView();
            this.btnlogout = new FontAwesome.Sharp.IconButton();
            this.btncustomers = new FontAwesome.Sharp.IconButton();
            this.btnsales = new FontAwesome.Sharp.IconButton();
            this.btnsupplier = new FontAwesome.Sharp.IconButton();
            this.btnreport = new FontAwesome.Sharp.IconButton();
            this.btnrepair = new FontAwesome.Sharp.IconButton();
            this.btninventory = new FontAwesome.Sharp.IconButton();
            this.btndashboard = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelmenu = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2.SuspendLayout();
            this.paneledit.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingRecords)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelmenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.paneledit);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.btnRefresh);
            this.panel2.Controls.Add(this.dgvBillingRecords);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(303, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1575, 1078);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // paneledit
            // 
            this.paneledit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.paneledit.Controls.Add(this.txtremarks);
            this.paneledit.Controls.Add(this.label5);
            this.paneledit.Controls.Add(this.txtdate);
            this.paneledit.Controls.Add(this.label3);
            this.paneledit.Controls.Add(this.txtpayment);
            this.paneledit.Controls.Add(this.label2);
            this.paneledit.Controls.Add(this.txtamount);
            this.paneledit.Controls.Add(this.label4);
            this.paneledit.Controls.Add(this.btncancle1);
            this.paneledit.Controls.Add(this.btnsave1);
            this.paneledit.Controls.Add(this.txtbill);
            this.paneledit.Controls.Add(this.label8);
            this.paneledit.Controls.Add(this.txtname1);
            this.paneledit.Controls.Add(this.label10);
            this.paneledit.Controls.Add(this.label11);
            this.paneledit.Location = new System.Drawing.Point(758, 236);
            this.paneledit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.paneledit.Name = "paneledit";
            this.paneledit.Size = new System.Drawing.Size(498, 838);
            this.paneledit.TabIndex = 155;
            this.paneledit.Paint += new System.Windows.Forms.PaintEventHandler(this.paneledit_Paint);
            // 
            // txtremarks
            // 
            this.txtremarks.BackColor = System.Drawing.Color.Gainsboro;
            this.txtremarks.Location = new System.Drawing.Point(69, 600);
            this.txtremarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(352, 143);
            this.txtremarks.TabIndex = 161;
            this.txtremarks.TextChanged += new System.EventHandler(this.txtremarks_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label5.Location = new System.Drawing.Point(66, 559);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 36);
            this.label5.TabIndex = 160;
            this.label5.Text = "Remarks";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtdate
            // 
            this.txtdate.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdate.Location = new System.Drawing.Point(72, 511);
            this.txtdate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtdate.Multiline = true;
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(352, 43);
            this.txtdate.TabIndex = 159;
            this.txtdate.TextChanged += new System.EventHandler(this.txtdate_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(70, 470);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 36);
            this.label3.TabIndex = 158;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtpayment
            // 
            this.txtpayment.BackColor = System.Drawing.Color.Gainsboro;
            this.txtpayment.Location = new System.Drawing.Point(72, 404);
            this.txtpayment.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtpayment.Multiline = true;
            this.txtpayment.Name = "txtpayment";
            this.txtpayment.Size = new System.Drawing.Size(352, 43);
            this.txtpayment.TabIndex = 157;
            this.txtpayment.TextChanged += new System.EventHandler(this.txtpayment_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(70, 362);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 36);
            this.label2.TabIndex = 156;
            this.label2.Text = "Payment";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txtamount
            // 
            this.txtamount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtamount.Location = new System.Drawing.Point(75, 304);
            this.txtamount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtamount.Multiline = true;
            this.txtamount.Name = "txtamount";
            this.txtamount.ReadOnly = true;
            this.txtamount.Size = new System.Drawing.Size(352, 43);
            this.txtamount.TabIndex = 155;
            this.txtamount.TextChanged += new System.EventHandler(this.txtamount_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label4.Location = new System.Drawing.Point(73, 262);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 36);
            this.label4.TabIndex = 154;
            this.label4.Text = "Pending Amount";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // btncancle1
            // 
            this.btncancle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btncancle1.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btncancle1.FlatAppearance.BorderSize = 2;
            this.btncancle1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btncancle1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btncancle1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncancle1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncancle1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncancle1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btncancle1.IconColor = System.Drawing.Color.Red;
            this.btncancle1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncancle1.IconSize = 35;
            this.btncancle1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancle1.Location = new System.Drawing.Point(287, 774);
            this.btncancle1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncancle1.Name = "btncancle1";
            this.btncancle1.Size = new System.Drawing.Size(170, 52);
            this.btncancle1.TabIndex = 137;
            this.btncancle1.Text = "Cancel";
            this.btncancle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancle1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancle1.UseVisualStyleBackColor = false;
            this.btncancle1.Click += new System.EventHandler(this.btncancle1_Click);
            // 
            // btnsave1
            // 
            this.btnsave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnsave1.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnsave1.FlatAppearance.BorderSize = 2;
            this.btnsave1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnsave1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsave1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnsave1.IconColor = System.Drawing.Color.LimeGreen;
            this.btnsave1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsave1.IconSize = 35;
            this.btnsave1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave1.Location = new System.Drawing.Point(72, 774);
            this.btnsave1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsave1.Name = "btnsave1";
            this.btnsave1.Size = new System.Drawing.Size(170, 52);
            this.btnsave1.TabIndex = 136;
            this.btnsave1.Text = "Save";
            this.btnsave1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave1.UseVisualStyleBackColor = false;
            this.btnsave1.Click += new System.EventHandler(this.btnsave1_Click);
            // 
            // txtbill
            // 
            this.txtbill.BackColor = System.Drawing.Color.Gainsboro;
            this.txtbill.Location = new System.Drawing.Point(79, 202);
            this.txtbill.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtbill.Multiline = true;
            this.txtbill.Name = "txtbill";
            this.txtbill.ReadOnly = true;
            this.txtbill.Size = new System.Drawing.Size(352, 43);
            this.txtbill.TabIndex = 135;
            this.txtbill.TextChanged += new System.EventHandler(this.txtbill_TextChanged);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label8.Location = new System.Drawing.Point(76, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 36);
            this.label8.TabIndex = 134;
            this.label8.Text = "Bill ID";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // txtname1
            // 
            this.txtname1.BackColor = System.Drawing.Color.Gainsboro;
            this.txtname1.Location = new System.Drawing.Point(82, 114);
            this.txtname1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtname1.Multiline = true;
            this.txtname1.Name = "txtname1";
            this.txtname1.ReadOnly = true;
            this.txtname1.Size = new System.Drawing.Size(352, 43);
            this.txtname1.TabIndex = 131;
            this.txtname1.TextChanged += new System.EventHandler(this.txtname1_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label10.Location = new System.Drawing.Point(80, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 36);
            this.label10.TabIndex = 130;
            this.label10.Text = "Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label11.Location = new System.Drawing.Point(148, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(241, 46);
            this.label11.TabIndex = 7;
            this.label11.Text = "Edit Record";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 226);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Snow;
            this.label1.Location = new System.Drawing.Point(395, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(725, 69);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Billing Records";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Location = new System.Drawing.Point(438, 261);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(125, 48);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(112, 274);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 26);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(603, 261);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(125, 48);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // dgvBillingRecords
            // 
            this.dgvBillingRecords.AllowUserToAddRows = false;
            this.dgvBillingRecords.AllowUserToDeleteRows = false;
            this.dgvBillingRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBillingRecords.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvBillingRecords.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBillingRecords.BackgroundColor = System.Drawing.Color.White;
            this.dgvBillingRecords.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvBillingRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillingRecords.Location = new System.Drawing.Point(83, 340);
            this.dgvBillingRecords.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dgvBillingRecords.Name = "dgvBillingRecords";
            this.dgvBillingRecords.RowHeadersWidth = 62;
            this.dgvBillingRecords.RowTemplate.Height = 28;
            this.dgvBillingRecords.Size = new System.Drawing.Size(1396, 566);
            this.dgvBillingRecords.TabIndex = 0;
            this.dgvBillingRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingRecords_CellClick);
            this.dgvBillingRecords.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingRecords_CellContentClick);
            // 
            // btnlogout
            // 
            this.btnlogout.BackColor = System.Drawing.Color.Transparent;
            this.btnlogout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnlogout.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnlogout.FlatAppearance.BorderSize = 2;
            this.btnlogout.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnlogout.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnlogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlogout.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogout.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnlogout.IconChar = FontAwesome.Sharp.IconChar.RightFromBracket;
            this.btnlogout.IconColor = System.Drawing.Color.White;
            this.btnlogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlogout.IconSize = 40;
            this.btnlogout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.Location = new System.Drawing.Point(3, 813);
            this.btnlogout.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(304, 75);
            this.btnlogout.TabIndex = 8;
            this.btnlogout.Text = "Logout";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // btncustomers
            // 
            this.btncustomers.BackColor = System.Drawing.Color.Transparent;
            this.btncustomers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btncustomers.FlatAppearance.BorderColor = System.Drawing.SystemColors.HighlightText;
            this.btncustomers.FlatAppearance.BorderSize = 2;
            this.btncustomers.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btncustomers.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btncustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncustomers.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncustomers.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncustomers.IconChar = FontAwesome.Sharp.IconChar.PeopleGroup;
            this.btncustomers.IconColor = System.Drawing.Color.White;
            this.btncustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncustomers.IconSize = 40;
            this.btncustomers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncustomers.Location = new System.Drawing.Point(3, 730);
            this.btncustomers.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btncustomers.Name = "btncustomers";
            this.btncustomers.Size = new System.Drawing.Size(304, 75);
            this.btncustomers.TabIndex = 5;
            this.btncustomers.Text = "Customers";
            this.btncustomers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncustomers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncustomers.UseVisualStyleBackColor = false;
            this.btncustomers.Click += new System.EventHandler(this.btncustomers_Click);
            // 
            // btnsales
            // 
            this.btnsales.BackColor = System.Drawing.Color.Transparent;
            this.btnsales.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsales.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsales.FlatAppearance.BorderSize = 2;
            this.btnsales.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsales.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsales.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsales.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsales.IconChar = FontAwesome.Sharp.IconChar.CartShopping;
            this.btnsales.IconColor = System.Drawing.Color.White;
            this.btnsales.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsales.IconSize = 40;
            this.btnsales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsales.Location = new System.Drawing.Point(3, 647);
            this.btnsales.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsales.Name = "btnsales";
            this.btnsales.Size = new System.Drawing.Size(304, 75);
            this.btnsales.TabIndex = 3;
            this.btnsales.Text = "Sales";
            this.btnsales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsales.UseVisualStyleBackColor = false;
            this.btnsales.Click += new System.EventHandler(this.btnsales_Click);
            // 
            // btnsupplier
            // 
            this.btnsupplier.BackColor = System.Drawing.Color.Transparent;
            this.btnsupplier.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnsupplier.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnsupplier.FlatAppearance.BorderSize = 2;
            this.btnsupplier.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsupplier.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsupplier.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsupplier.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsupplier.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsupplier.IconChar = FontAwesome.Sharp.IconChar.Truck;
            this.btnsupplier.IconColor = System.Drawing.Color.White;
            this.btnsupplier.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsupplier.IconSize = 40;
            this.btnsupplier.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsupplier.Location = new System.Drawing.Point(3, 564);
            this.btnsupplier.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnsupplier.Name = "btnsupplier";
            this.btnsupplier.Size = new System.Drawing.Size(304, 75);
            this.btnsupplier.TabIndex = 6;
            this.btnsupplier.Text = "Suppliers";
            this.btnsupplier.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsupplier.UseVisualStyleBackColor = false;
            this.btnsupplier.Click += new System.EventHandler(this.btnsupplier_Click);
            // 
            // btnreport
            // 
            this.btnreport.BackColor = System.Drawing.Color.Transparent;
            this.btnreport.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnreport.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnreport.FlatAppearance.BorderSize = 2;
            this.btnreport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnreport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnreport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreport.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreport.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnreport.IconChar = FontAwesome.Sharp.IconChar.FileInvoiceDollar;
            this.btnreport.IconColor = System.Drawing.Color.White;
            this.btnreport.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnreport.IconSize = 40;
            this.btnreport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreport.Location = new System.Drawing.Point(3, 481);
            this.btnreport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(304, 75);
            this.btnreport.TabIndex = 7;
            this.btnreport.Text = "Reports";
            this.btnreport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnreport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnreport.UseVisualStyleBackColor = false;
            this.btnreport.Click += new System.EventHandler(this.btnreport_Click);
            // 
            // btnrepair
            // 
            this.btnrepair.BackColor = System.Drawing.Color.Transparent;
            this.btnrepair.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnrepair.FlatAppearance.BorderColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnrepair.FlatAppearance.BorderSize = 2;
            this.btnrepair.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnrepair.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnrepair.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnrepair.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnrepair.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnrepair.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.btnrepair.IconColor = System.Drawing.Color.White;
            this.btnrepair.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnrepair.IconSize = 40;
            this.btnrepair.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrepair.Location = new System.Drawing.Point(3, 398);
            this.btnrepair.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnrepair.Name = "btnrepair";
            this.btnrepair.Size = new System.Drawing.Size(304, 75);
            this.btnrepair.TabIndex = 4;
            this.btnrepair.Text = "repairs";
            this.btnrepair.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnrepair.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnrepair.UseVisualStyleBackColor = false;
            this.btnrepair.Click += new System.EventHandler(this.btnrepair_Click);
            // 
            // btninventory
            // 
            this.btninventory.BackColor = System.Drawing.Color.Transparent;
            this.btninventory.Dock = System.Windows.Forms.DockStyle.Top;
            this.btninventory.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btninventory.FlatAppearance.BorderSize = 2;
            this.btninventory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btninventory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btninventory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btninventory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btninventory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btninventory.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            this.btninventory.IconColor = System.Drawing.Color.White;
            this.btninventory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btninventory.IconSize = 40;
            this.btninventory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninventory.Location = new System.Drawing.Point(3, 315);
            this.btninventory.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btninventory.Name = "btninventory";
            this.btninventory.Size = new System.Drawing.Size(298, 75);
            this.btninventory.TabIndex = 2;
            this.btninventory.Text = "Inventory";
            this.btninventory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btninventory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btninventory.UseVisualStyleBackColor = false;
            this.btninventory.Click += new System.EventHandler(this.btninventory_Click);
            // 
            // btndashboard
            // 
            this.btndashboard.BackColor = System.Drawing.Color.Transparent;
            this.btndashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btndashboard.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btndashboard.FlatAppearance.BorderSize = 2;
            this.btndashboard.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btndashboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btndashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndashboard.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndashboard.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btndashboard.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btndashboard.IconColor = System.Drawing.Color.White;
            this.btndashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndashboard.IconSize = 40;
            this.btndashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.Location = new System.Drawing.Point(3, 232);
            this.btndashboard.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(300, 75);
            this.btndashboard.TabIndex = 1;
            this.btndashboard.Text = "DashBoard";
            this.btndashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndashboard.UseVisualStyleBackColor = false;
            this.btndashboard.Click += new System.EventHandler(this.btndashboard_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TechStore.Properties.Resources.Screenshot_2025_06_28_221639_Photoroom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(298, 220);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelmenu
            // 
            this.panelmenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panelmenu.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelmenu.Controls.Add(this.pictureBox1);
            this.panelmenu.Controls.Add(this.btndashboard);
            this.panelmenu.Controls.Add(this.btninventory);
            this.panelmenu.Controls.Add(this.btnrepair);
            this.panelmenu.Controls.Add(this.btnreport);
            this.panelmenu.Controls.Add(this.btnsupplier);
            this.panelmenu.Controls.Add(this.btnsales);
            this.panelmenu.Controls.Add(this.btncustomers);
            this.panelmenu.Controls.Add(this.btnlogout);
            this.panelmenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelmenu.Location = new System.Drawing.Point(0, 0);
            this.panelmenu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(303, 1078);
            this.panelmenu.TabIndex = 8;
            this.panelmenu.Paint += new System.Windows.Forms.PaintEventHandler(this.panelmenu_Paint);
            // 
            // BillingRecordsOverview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1878, 1078);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BillingRecordsOverview";
            this.Text = "Customer Payments";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.BillingRecordsOverview_Load_1);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.paneledit.ResumeLayout(false);
            this.paneledit.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingRecords)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelmenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvBillingRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconButton btnlogout;
        private FontAwesome.Sharp.IconButton btncustomers;
        private FontAwesome.Sharp.IconButton btnsales;
        private FontAwesome.Sharp.IconButton btnsupplier;
        private FontAwesome.Sharp.IconButton btnreport;
        private FontAwesome.Sharp.IconButton btnrepair;
        private FontAwesome.Sharp.IconButton btninventory;
        private FontAwesome.Sharp.IconButton btndashboard;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.FlowLayoutPanel panelmenu;
        private System.Windows.Forms.Panel paneledit;
        private System.Windows.Forms.TextBox txtremarks;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtpayment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtamount;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btncancle1;
        private FontAwesome.Sharp.IconButton btnsave1;
        private System.Windows.Forms.TextBox txtbill;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtname1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
    }
}

