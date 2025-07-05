namespace TechStore.UI
{
    partial class Inventorylogform
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toplbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton3 = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
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
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.toplbl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1294, 84);
            this.panel1.TabIndex = 15;
            // 
            // toplbl
            // 
            this.toplbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.toplbl.AutoSize = true;
            this.toplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toplbl.Location = new System.Drawing.Point(529, 26);
            this.toplbl.Name = "toplbl";
            this.toplbl.Size = new System.Drawing.Size(245, 38);
            this.toplbl.TabIndex = 6;
            this.toplbl.Text = "Inventory Logs";
            this.toplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.SeaShell;
            this.panel2.Controls.Add(this.iconButton3);
            this.panel2.Controls.Add(this.iconButton2);
            this.panel2.Controls.Add(this.dataGridView2);
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
            this.panel2.Size = new System.Drawing.Size(1294, 694);
            this.panel2.TabIndex = 16;
            // 
            // iconButton3
            // 
            this.iconButton3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.iconButton3.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.iconButton3.FlatAppearance.BorderSize = 2;
            this.iconButton3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.iconButton3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.iconButton3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton3.IconChar = FontAwesome.Sharp.IconChar.BuildingCircleArrowRight;
            this.iconButton3.IconColor = System.Drawing.Color.White;
            this.iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton3.IconSize = 35;
            this.iconButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.Location = new System.Drawing.Point(983, -1);
            this.iconButton3.Name = "iconButton3";
            this.iconButton3.Size = new System.Drawing.Size(201, 34);
            this.iconButton3.TabIndex = 137;
            this.iconButton3.Text = "Batches";
            this.iconButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton3.UseVisualStyleBackColor = false;
            // 
            // iconButton2
            // 
            this.iconButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.iconButton2.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.iconButton2.FlatAppearance.BorderSize = 2;
            this.iconButton2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.iconButton2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.iconButton2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.iconButton2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iconButton2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.BuildingCircleArrowRight;
            this.iconButton2.IconColor = System.Drawing.Color.White;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 35;
            this.iconButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.Location = new System.Drawing.Point(792, -1);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Size = new System.Drawing.Size(201, 34);
            this.iconButton2.TabIndex = 136;
            this.iconButton2.Text = "Batch Details";
            this.iconButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.iconButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.iconButton2.UseVisualStyleBackColor = false;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.Teal;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Lime;
            this.dataGridView2.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView2.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.AppWorkspace;
            this.dataGridView2.Location = new System.Drawing.Point(14, 133);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView2.Size = new System.Drawing.Size(1249, 391);
            this.dataGridView2.TabIndex = 134;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(55)))), ((int)(((byte)(71)))));
            this.label4.Location = new System.Drawing.Point(13, 88);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 25);
            this.label4.TabIndex = 130;
            this.label4.Text = "Search :";
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(351, 87);
            this.button9.Margin = new System.Windows.Forms.Padding(4);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(112, 31);
            this.button9.TabIndex = 132;
            this.button9.Text = "Search";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(99, 87);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(230, 29);
            this.textBox1.TabIndex = 131;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
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
            this.btnstate.Location = new System.Drawing.Point(595, 0);
            this.btnstate.Name = "btnstate";
            this.btnstate.Size = new System.Drawing.Size(201, 34);
            this.btnstate.TabIndex = 129;
            this.btnstate.Text = "Sell Product";
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
            this.btnlogs.Location = new System.Drawing.Point(397, 0);
            this.btnlogs.Name = "btnlogs";
            this.btnlogs.Size = new System.Drawing.Size(201, 34);
            this.btnlogs.TabIndex = 128;
            this.btnlogs.Text = "Inventory ";
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
            this.btncategory.Location = new System.Drawing.Point(201, 0);
            this.btncategory.Name = "btncategory";
            this.btncategory.Size = new System.Drawing.Size(201, 34);
            this.btncategory.TabIndex = 127;
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
            this.btnproducts.Location = new System.Drawing.Point(3, 0);
            this.btnproducts.Name = "btnproducts";
            this.btnproducts.Size = new System.Drawing.Size(201, 34);
            this.btnproducts.TabIndex = 126;
            this.btnproducts.Text = "Products";
            this.btnproducts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnproducts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnproducts.UseVisualStyleBackColor = false;
            // 
            // Inventorylogform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1294, 778);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Inventorylogform";
            this.Text = "Inventorylogform";
            this.Load += new System.EventHandler(this.Inventorylogform_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private FontAwesome.Sharp.IconButton btnstate;
        private FontAwesome.Sharp.IconButton btnlogs;
        private FontAwesome.Sharp.IconButton btncategory;
        private FontAwesome.Sharp.IconButton btnproducts;
    }
}