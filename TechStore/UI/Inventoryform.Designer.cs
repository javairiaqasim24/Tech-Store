namespace TechStore
{
    partial class Inventoryform
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Inventoryform));
            this.panel1 = new System.Windows.Forms.Panel();
            this.toplbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnedit = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnstate = new FontAwesome.Sharp.IconButton();
            this.btnlogs = new FontAwesome.Sharp.IconButton();
            this.btncategory = new FontAwesome.Sharp.IconButton();
            this.btnproducts = new FontAwesome.Sharp.IconButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
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
            this.panel1.TabIndex = 11;
            // 
            // toplbl
            // 
            this.toplbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.toplbl.AutoSize = true;
            this.toplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toplbl.Location = new System.Drawing.Point(538, 26);
            this.toplbl.Name = "toplbl";
            this.toplbl.Size = new System.Drawing.Size(160, 38);
            this.toplbl.TabIndex = 6;
            this.toplbl.Text = "Inventory";
            this.toplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(239)))), ((int)(((byte)(236)))));
            this.panel2.Controls.Add(this.dataGridView2);
            this.panel2.Controls.Add(this.pictureBox10);
            this.panel2.Controls.Add(this.btndelete);
            this.panel2.Controls.Add(this.btnedit);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button9);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.btnstate);
            this.panel2.Controls.Add(this.btnlogs);
            this.panel2.Controls.Add(this.btncategory);
            this.panel2.Controls.Add(this.btnproducts);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1312, 708);
            this.panel2.TabIndex = 12;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Lime;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView2.Location = new System.Drawing.Point(12, 133);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(1269, 407);
            this.dataGridView2.TabIndex = 103;
            // 
            // pictureBox10
            // 
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(500, 61);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(43, 43);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 102;
            this.pictureBox10.TabStop = false;
            // 
            // btndelete
            // 
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btndelete.Location = new System.Drawing.Point(328, 62);
            this.btndelete.Margin = new System.Windows.Forms.Padding(4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(149, 42);
            this.btndelete.TabIndex = 101;
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = false;
            // 
            // btnedit
            // 
            this.btnedit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnedit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnedit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnedit.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.btnedit.Location = new System.Drawing.Point(170, 62);
            this.btnedit.Margin = new System.Windows.Forms.Padding(4);
            this.btnedit.Name = "btnedit";
            this.btnedit.Size = new System.Drawing.Size(149, 42);
            this.btnedit.TabIndex = 100;
            this.btnedit.Text = "Edit";
            this.btnedit.UseVisualStyleBackColor = false;
            // 
            // button8
            // 
            this.button8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button8.Location = new System.Drawing.Point(12, 61);
            this.button8.Margin = new System.Windows.Forms.Padding(4);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(149, 42);
            this.button8.TabIndex = 99;
            this.button8.Text = "Add";
            this.button8.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.label4.Location = new System.Drawing.Point(820, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 96;
            this.label4.Text = "Search :";
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(1158, 67);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 31);
            this.button9.TabIndex = 98;
            this.button9.Text = "Search";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(906, 67);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 29);
            this.textBox1.TabIndex = 97;
            // 
            // btnstate
            // 
            this.btnstate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnstate.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnstate.FlatAppearance.BorderSize = 2;
            this.btnstate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnstate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnstate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnstate.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstate.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnstate.IconChar = FontAwesome.Sharp.IconChar.BuildingCircleArrowRight;
            this.btnstate.IconColor = System.Drawing.Color.White;
            this.btnstate.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnstate.IconSize = 35;
            this.btnstate.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstate.Location = new System.Drawing.Point(593, 0);
            this.btnstate.Name = "btnstate";
            this.btnstate.Size = new System.Drawing.Size(201, 34);
            this.btnstate.TabIndex = 94;
            this.btnstate.Text = "State";
            this.btnstate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnstate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnstate.UseVisualStyleBackColor = false;
            // 
            // btnlogs
            // 
            this.btnlogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnlogs.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnlogs.FlatAppearance.BorderSize = 2;
            this.btnlogs.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnlogs.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnlogs.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnlogs.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnlogs.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnlogs.IconChar = FontAwesome.Sharp.IconChar.ClipboardList;
            this.btnlogs.IconColor = System.Drawing.Color.White;
            this.btnlogs.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlogs.IconSize = 35;
            this.btnlogs.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogs.Location = new System.Drawing.Point(395, 0);
            this.btnlogs.Name = "btnlogs";
            this.btnlogs.Size = new System.Drawing.Size(201, 34);
            this.btnlogs.TabIndex = 93;
            this.btnlogs.Text = "Inventory Logs";
            this.btnlogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnlogs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnlogs.UseVisualStyleBackColor = false;
            // 
            // btncategory
            // 
            this.btncategory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btncategory.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btncategory.FlatAppearance.BorderSize = 2;
            this.btncategory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btncategory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btncategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btncategory.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncategory.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btncategory.IconChar = FontAwesome.Sharp.IconChar.LayerGroup;
            this.btncategory.IconColor = System.Drawing.Color.White;
            this.btncategory.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btncategory.IconSize = 35;
            this.btncategory.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategory.Location = new System.Drawing.Point(199, 0);
            this.btncategory.Name = "btncategory";
            this.btncategory.Size = new System.Drawing.Size(201, 34);
            this.btncategory.TabIndex = 92;
            this.btncategory.Text = "Categories";
            this.btncategory.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncategory.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btncategory.UseVisualStyleBackColor = false;
            // 
            // btnproducts
            // 
            this.btnproducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnproducts.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnproducts.FlatAppearance.BorderSize = 2;
            this.btnproducts.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnproducts.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnproducts.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnproducts.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnproducts.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnproducts.IconChar = FontAwesome.Sharp.IconChar.BoxesStacked;
            this.btnproducts.IconColor = System.Drawing.Color.White;
            this.btnproducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnproducts.IconSize = 35;
            this.btnproducts.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducts.Location = new System.Drawing.Point(1, 0);
            this.btnproducts.Name = "btnproducts";
            this.btnproducts.Size = new System.Drawing.Size(201, 34);
            this.btnproducts.TabIndex = 91;
            this.btnproducts.Text = "Products";
            this.btnproducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproducts.UseVisualStyleBackColor = false;
            // 
            // Inventoryform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 792);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inventoryform";
            this.Text = "Inventoryform";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.PictureBox pictureBox10;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnedit;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnstate;
        private FontAwesome.Sharp.IconButton btnlogs;
        private FontAwesome.Sharp.IconButton btncategory;
        private FontAwesome.Sharp.IconButton btnproducts;
    }
}