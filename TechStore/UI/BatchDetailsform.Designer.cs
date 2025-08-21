namespace TechStore.UI
{
    partial class BatchDetailsform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toplbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.paneledit = new System.Windows.Forms.Panel();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtBname = new System.Windows.Forms.ComboBox();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.btnsave = new FontAwesome.Sharp.IconButton();
            this.txtproducts = new System.Windows.Forms.ComboBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btncancle1 = new FontAwesome.Sharp.IconButton();
            this.btnsave1 = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.paneledit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.toplbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 84);
            this.panel1.TabIndex = 15;
            // 
            // toplbl
            // 
            this.toplbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.toplbl.AutoSize = true;
            this.toplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toplbl.Location = new System.Drawing.Point(538, 26);
            this.toplbl.Name = "toplbl";
            this.toplbl.Size = new System.Drawing.Size(143, 38);
            this.toplbl.TabIndex = 6;
            this.toplbl.Text = "Batches";
            this.toplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.MintCream;
            this.panel2.Controls.Add(this.paneledit);
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 779);
            this.panel2.TabIndex = 16;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // paneledit
            // 
            this.paneledit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.paneledit.Controls.Add(this.txtprice);
            this.paneledit.Controls.Add(this.label1);
            this.paneledit.Controls.Add(this.txtBname);
            this.paneledit.Controls.Add(this.iconButton1);
            this.paneledit.Controls.Add(this.btnsave);
            this.paneledit.Controls.Add(this.txtproducts);
            this.paneledit.Controls.Add(this.txtquantity);
            this.paneledit.Controls.Add(this.label7);
            this.paneledit.Controls.Add(this.btncancle1);
            this.paneledit.Controls.Add(this.btnsave1);
            this.paneledit.Controls.Add(this.label9);
            this.paneledit.Controls.Add(this.label10);
            this.paneledit.Controls.Add(this.label11);
            this.paneledit.Location = new System.Drawing.Point(545, 54);
            this.paneledit.Name = "paneledit";
            this.paneledit.Size = new System.Drawing.Size(443, 572);
            this.paneledit.TabIndex = 125;
            // 
            // txtprice
            // 
            this.txtprice.BackColor = System.Drawing.Color.Gainsboro;
            this.txtprice.Location = new System.Drawing.Point(76, 317);
            this.txtprice.Multiline = true;
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(313, 37);
            this.txtprice.TabIndex = 153;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(71, 284);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 30);
            this.label1.TabIndex = 152;
            this.label1.Text = "Cost Price";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBname
            // 
            this.txtBname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBname.FormattingEnabled = true;
            this.txtBname.Location = new System.Drawing.Point(76, 91);
            this.txtBname.Name = "txtBname";
            this.txtBname.Size = new System.Drawing.Size(313, 24);
            this.txtBname.TabIndex = 151;
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.iconButton1.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.iconButton1.FlatAppearance.BorderSize = 2;
            this.iconButton1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.iconButton1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.FloppyDisk;
            this.iconButton1.IconColor = System.Drawing.Color.Red;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 35;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.Location = new System.Drawing.Point(262, 458);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(151, 42);
            this.iconButton1.TabIndex = 150;
            this.iconButton1.Text = "Cancel";
            this.iconButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
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
            this.btnsave.Location = new System.Drawing.Point(49, 458);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(151, 42);
            this.btnsave.TabIndex = 149;
            this.btnsave.Text = "Save";
            this.btnsave.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtproducts
            // 
            this.txtproducts.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtproducts.FormattingEnabled = true;
            this.txtproducts.Location = new System.Drawing.Point(73, 174);
            this.txtproducts.Name = "txtproducts";
            this.txtproducts.Size = new System.Drawing.Size(313, 24);
            this.txtproducts.TabIndex = 140;
            // 
            // txtquantity
            // 
            this.txtquantity.BackColor = System.Drawing.Color.Gainsboro;
            this.txtquantity.Location = new System.Drawing.Point(73, 234);
            this.txtquantity.Multiline = true;
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(313, 37);
            this.txtquantity.TabIndex = 139;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label7.Location = new System.Drawing.Point(68, 201);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(190, 30);
            this.label7.TabIndex = 138;
            this.label7.Text = "Quantity recieved";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.btncancle1.Location = new System.Drawing.Point(235, 608);
            this.btncancle1.Name = "btncancle1";
            this.btncancle1.Size = new System.Drawing.Size(151, 42);
            this.btncancle1.TabIndex = 137;
            this.btncancle1.Text = "Cancel";
            this.btncancle1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncancle1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncancle1.UseVisualStyleBackColor = false;
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
            this.btnsave1.Location = new System.Drawing.Point(47, 608);
            this.btnsave1.Name = "btnsave1";
            this.btnsave1.Size = new System.Drawing.Size(151, 42);
            this.btnsave1.TabIndex = 136;
            this.btnsave1.Text = "Save";
            this.btnsave1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave1.UseVisualStyleBackColor = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label9.Location = new System.Drawing.Point(71, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 30);
            this.label9.TabIndex = 132;
            this.label9.Text = "Product Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label10.Location = new System.Drawing.Point(71, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 30);
            this.label10.TabIndex = 130;
            this.label10.Text = "Batch Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label11.Location = new System.Drawing.Point(132, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(207, 38);
            this.label11.TabIndex = 7;
            this.label11.Text = "Edit Product";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Lime;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView2.Location = new System.Drawing.Point(13, 84);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(1267, 405);
            this.dataGridView2.TabIndex = 121;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.label4.Location = new System.Drawing.Point(818, 22);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 117;
            this.label4.Text = "Search :";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(1156, 21);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 31);
            this.button9.TabIndex = 119;
            this.button9.Text = "Search";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(904, 21);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 29);
            this.textBox1.TabIndex = 118;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // BatchDetailsform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 863);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BatchDetailsform";
            this.Text = "BatchDetailsform";
            this.Load += new System.EventHandler(this.BatchDetailsform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.paneledit.ResumeLayout(false);
            this.paneledit.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel paneledit;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton btnsave;
        private System.Windows.Forms.ComboBox txtproducts;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btncancle1;
        private FontAwesome.Sharp.IconButton btnsave1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox txtBname;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.Label label1;
    }
}