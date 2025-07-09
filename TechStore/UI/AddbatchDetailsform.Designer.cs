namespace TechStore.UI
{
    partial class AddbatchDetailsform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtBname = new System.Windows.Forms.ComboBox();
            this.txtproducts = new System.Windows.Forms.ComboBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSprice = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            this.btnsave = new FontAwesome.Sharp.IconButton();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtserialinput = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtserailnumber = new System.Windows.Forms.ListBox();
            this.iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // txtprice
            // 
            this.txtprice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtprice.BackColor = System.Drawing.Color.Gainsboro;
            this.txtprice.Location = new System.Drawing.Point(28, 316);
            this.txtprice.Multiline = true;
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(313, 37);
            this.txtprice.TabIndex = 162;
            // 
            // txtBname
            // 
            this.txtBname.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBname.FormattingEnabled = true;
            this.txtBname.Location = new System.Drawing.Point(31, 102);
            this.txtBname.Name = "txtBname";
            this.txtBname.Size = new System.Drawing.Size(313, 24);
            this.txtBname.TabIndex = 161;
            this.txtBname.SelectedIndexChanged += new System.EventHandler(this.txtBname_SelectedIndexChanged);
            // 
            // txtproducts
            // 
            this.txtproducts.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtproducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtproducts.FormattingEnabled = true;
            this.txtproducts.Location = new System.Drawing.Point(28, 162);
            this.txtproducts.Name = "txtproducts";
            this.txtproducts.Size = new System.Drawing.Size(313, 24);
            this.txtproducts.TabIndex = 159;
            this.txtproducts.SelectedIndexChanged += new System.EventHandler(this.txtproducts_SelectedIndexChanged);
            // 
            // txtquantity
            // 
            this.txtquantity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtquantity.BackColor = System.Drawing.Color.Gainsboro;
            this.txtquantity.Location = new System.Drawing.Point(31, 243);
            this.txtquantity.Multiline = true;
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(313, 37);
            this.txtquantity.TabIndex = 158;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label7.Location = new System.Drawing.Point(27, 210);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 30);
            this.label7.TabIndex = 157;
            this.label7.Text = "Quantity recieved";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label9.Location = new System.Drawing.Point(27, 129);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 30);
            this.label9.TabIndex = 156;
            this.label9.Text = "Product Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label10.Location = new System.Drawing.Point(27, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 30);
            this.label10.TabIndex = 155;
            this.label10.Text = "Batch Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label11.Location = new System.Drawing.Point(291, 18);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(200, 38);
            this.label11.TabIndex = 154;
            this.label11.Text = "Add Record";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(27, 283);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 30);
            this.label1.TabIndex = 163;
            this.label1.Text = "Cost Price";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(27, 356);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 30);
            this.label3.TabIndex = 167;
            this.label3.Text = "Sale Price";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSprice
            // 
            this.txtSprice.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSprice.BackColor = System.Drawing.Color.Gainsboro;
            this.txtSprice.Location = new System.Drawing.Point(31, 389);
            this.txtSprice.Multiline = true;
            this.txtSprice.Name = "txtSprice";
            this.txtSprice.Size = new System.Drawing.Size(313, 37);
            this.txtSprice.TabIndex = 166;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView2.Location = new System.Drawing.Point(404, 82);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(876, 313);
            this.dataGridView2.TabIndex = 170;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellClick);
            // 
            // iconPictureBox2
            // 
            this.iconPictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.iconPictureBox2.ForeColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.iconPictureBox2.IconColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox2.IconSize = 37;
            this.iconPictureBox2.Location = new System.Drawing.Point(350, 102);
            this.iconPictureBox2.Name = "iconPictureBox2";
            this.iconPictureBox2.Size = new System.Drawing.Size(47, 37);
            this.iconPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox2.TabIndex = 171;
            this.iconPictureBox2.TabStop = false;
            this.iconPictureBox2.Click += new System.EventHandler(this.iconPictureBox2_Click);
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnsave.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnsave.FlatAppearance.BorderSize = 2;
            this.btnsave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnsave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnsave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnsave.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnsave.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.btnsave.IconColor = System.Drawing.Color.LimeGreen;
            this.btnsave.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnsave.IconSize = 35;
            this.btnsave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.Location = new System.Drawing.Point(72, 646);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(151, 42);
            this.btnsave.TabIndex = 160;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(357, 402);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(136, 24);
            this.checkBox1.TabIndex = 172;
            this.checkBox1.Text = "Is Serialized";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panel1.Controls.Add(this.txtserialinput);
            this.panel1.Controls.Add(this.iconPictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtserailnumber);
            this.panel1.Location = new System.Drawing.Point(28, 432);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(465, 178);
            this.panel1.TabIndex = 175;
            // 
            // txtserialinput
            // 
            this.txtserialinput.BackColor = System.Drawing.Color.Gainsboro;
            this.txtserialinput.Location = new System.Drawing.Point(4, 52);
            this.txtserialinput.Multiline = true;
            this.txtserialinput.Name = "txtserialinput";
            this.txtserialinput.Size = new System.Drawing.Size(312, 37);
            this.txtserialinput.TabIndex = 173;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.IconSize = 55;
            this.iconPictureBox1.Location = new System.Drawing.Point(350, 55);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(90, 55);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox1.TabIndex = 172;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(15, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 30);
            this.label2.TabIndex = 171;
            this.label2.Text = "Serial Number";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtserailnumber
            // 
            this.txtserailnumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserailnumber.FormattingEnabled = true;
            this.txtserailnumber.ItemHeight = 20;
            this.txtserailnumber.Location = new System.Drawing.Point(4, 110);
            this.txtserailnumber.Name = "txtserailnumber";
            this.txtserailnumber.Size = new System.Drawing.Size(313, 44);
            this.txtserailnumber.TabIndex = 170;
            // 
            // iconPictureBox3
            // 
            this.iconPictureBox3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.iconPictureBox3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.iconPictureBox3.ForeColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.iconPictureBox3.IconColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox3.IconSize = 37;
            this.iconPictureBox3.Location = new System.Drawing.Point(350, 162);
            this.iconPictureBox3.Name = "iconPictureBox3";
            this.iconPictureBox3.Size = new System.Drawing.Size(47, 37);
            this.iconPictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox3.TabIndex = 176;
            this.iconPictureBox3.TabStop = false;
            this.iconPictureBox3.Click += new System.EventHandler(this.iconPictureBox3_Click);
            // 
            // AddbatchDetailsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 727);
            this.Controls.Add(this.iconPictureBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.iconPictureBox2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtSprice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtBname);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.txtproducts);
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddbatchDetailsform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddbatchDetailsform";
            this.Load += new System.EventHandler(this.AddbatchDetailsform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.ComboBox txtBname;
        private FontAwesome.Sharp.IconButton btnsave;
        private System.Windows.Forms.ComboBox txtproducts;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSprice;
        private System.Windows.Forms.DataGridView dataGridView2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtserialinput;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox txtserailnumber;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
    }
}