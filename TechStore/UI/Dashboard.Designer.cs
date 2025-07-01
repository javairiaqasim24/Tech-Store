namespace TechStore
{
    partial class Dashboard
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
            this.panelmenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
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
            this.panelmenu.Name = "panelmenu";
            this.panelmenu.Size = new System.Drawing.Size(270, 862);
            this.panelmenu.TabIndex = 8;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox1.Image = global::TechStore.Properties.Resources.Screenshot_2025_06_28_221639_Photoroom;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 176);
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
            this.btndashboard.Location = new System.Drawing.Point(3, 185);
            this.btndashboard.Name = "btndashboard";
            this.btndashboard.Size = new System.Drawing.Size(267, 60);
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
            this.btninventory.Location = new System.Drawing.Point(3, 251);
            this.btninventory.Name = "btninventory";
            this.btninventory.Size = new System.Drawing.Size(265, 60);
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
            this.btnrepair.Location = new System.Drawing.Point(3, 317);
            this.btnrepair.Name = "btnrepair";
            this.btnrepair.Size = new System.Drawing.Size(270, 60);
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
            this.btnreport.Location = new System.Drawing.Point(3, 383);
            this.btnreport.Name = "btnreport";
            this.btnreport.Size = new System.Drawing.Size(270, 60);
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
            this.btnsupplier.Location = new System.Drawing.Point(3, 449);
            this.btnsupplier.Name = "btnsupplier";
            this.btnsupplier.Size = new System.Drawing.Size(270, 60);
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
            this.btnsales.Location = new System.Drawing.Point(3, 515);
            this.btnsales.Name = "btnsales";
            this.btnsales.Size = new System.Drawing.Size(270, 60);
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
            this.btncustomers.Location = new System.Drawing.Point(3, 581);
            this.btncustomers.Name = "btncustomers";
            this.btncustomers.Size = new System.Drawing.Size(270, 60);
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
            this.btnlogout.Location = new System.Drawing.Point(3, 647);
            this.btnlogout.Name = "btnlogout";
            this.btnlogout.Size = new System.Drawing.Size(270, 60);
            this.btnlogout.TabIndex = 8;
            this.btnlogout.Text = "Logout";
            this.btnlogout.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlogout.UseVisualStyleBackColor = false;
            this.btnlogout.Click += new System.EventHandler(this.btnlogout_Click);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(270, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1042, 862);
            this.panel2.TabIndex = 10;
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.ClientSize = new System.Drawing.Size(1312, 862);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panelmenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Dashboard";
            this.Text = "Form1";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.panelmenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
    }
}

