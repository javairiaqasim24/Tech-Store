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
            this.panelmenu = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btndashboard = new FontAwesome.Sharp.IconButton();
            this.btninventory = new FontAwesome.Sharp.IconButton();
            this.btnrepair = new FontAwesome.Sharp.IconButton();
            this.btnreport = new FontAwesome.Sharp.IconButton();
            this.btnsupplier = new FontAwesome.Sharp.IconButton();
            this.btnsales = new FontAwesome.Sharp.IconButton();
            this.btncustomers = new FontAwesome.Sharp.IconButton();
            this.btnlogout = new FontAwesome.Sharp.IconButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dgvBillingRecords = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingRecords)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
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
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
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
            this.txtSearch.Location = new System.Drawing.Point(113, 274);
            this.txtSearch.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(257, 26);
            this.txtSearch.TabIndex = 3;
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
            this.dgvBillingRecords.Size = new System.Drawing.Size(1395, 566);
            this.dgvBillingRecords.TabIndex = 0;
            this.dgvBillingRecords.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillingRecords_CellClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1575, 226);
            this.panel1.TabIndex = 8;
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
            this.panelmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillingRecords)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panelmenu;
        private FontAwesome.Sharp.IconButton btndashboard;
        private FontAwesome.Sharp.IconButton btninventory;
        private FontAwesome.Sharp.IconButton btnsales;
        private FontAwesome.Sharp.IconButton btnrepair;
        private FontAwesome.Sharp.IconButton btncustomers;
        private FontAwesome.Sharp.IconButton btnsupplier;
        private FontAwesome.Sharp.IconButton btnreport;
        private FontAwesome.Sharp.IconButton btnlogout;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.DataGridView dgvBillingRecords;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}

