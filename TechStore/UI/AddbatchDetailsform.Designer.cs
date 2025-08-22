namespace TechStore.UI
{
    partial class AddbatchDetailsform
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
                toolTip?.Dispose();
                statusTimer?.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.btnAdditem = new System.Windows.Forms.Button();
            this.lblSalePrice = new System.Windows.Forms.Label();
            this.lblCostPrice = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblProducts = new System.Windows.Forms.Label();
            this.lblBatch = new System.Windows.Forms.Label();
            this.txtSprice = new System.Windows.Forms.TextBox();
            this.txtprice = new System.Windows.Forms.TextBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lblSerial = new System.Windows.Forms.Label();
            this.txtserialinput = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtpro = new System.Windows.Forms.TextBox();
            this.txtBnames = new System.Windows.Forms.TextBox();
            this.iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox1
            // 
            this.checkBox1.Location = new System.Drawing.Point(420, 266);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 20);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Serialized Products?";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnsave
            // 
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnsave.Location = new System.Drawing.Point(33, 330);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(132, 35);
            this.btnsave.TabIndex = 8;
            this.btnsave.Text = "Save Batch";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // btnAdditem
            // 
            this.btnAdditem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnAdditem.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdditem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnAdditem.Location = new System.Drawing.Point(217, 325);
            this.btnAdditem.Name = "btnAdditem";
            this.btnAdditem.Size = new System.Drawing.Size(136, 40);
            this.btnAdditem.TabIndex = 7;
            this.btnAdditem.Text = "Add Item";
            this.btnAdditem.UseVisualStyleBackColor = false;
            this.btnAdditem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // lblSalePrice
            // 
            this.lblSalePrice.AutoSize = true;
            this.lblSalePrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSalePrice.Location = new System.Drawing.Point(30, 183);
            this.lblSalePrice.Name = "lblSalePrice";
            this.lblSalePrice.Size = new System.Drawing.Size(107, 25);
            this.lblSalePrice.TabIndex = 16;
            this.lblSalePrice.Text = "Sale Price:";
            // 
            // lblCostPrice
            // 
            this.lblCostPrice.AutoSize = true;
            this.lblCostPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCostPrice.Location = new System.Drawing.Point(30, 143);
            this.lblCostPrice.Name = "lblCostPrice";
            this.lblCostPrice.Size = new System.Drawing.Size(108, 25);
            this.lblCostPrice.TabIndex = 15;
            this.lblCostPrice.Text = "Cost Price:";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(30, 103);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(91, 25);
            this.lblQuantity.TabIndex = 14;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lblProducts
            // 
            this.lblProducts.AutoSize = true;
            this.lblProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProducts.Location = new System.Drawing.Point(30, 63);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(85, 25);
            this.lblProducts.TabIndex = 13;
            this.lblProducts.Text = "Product:";
            // 
            // lblBatch
            // 
            this.lblBatch.AutoSize = true;
            this.lblBatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBatch.Location = new System.Drawing.Point(30, 23);
            this.lblBatch.Name = "lblBatch";
            this.lblBatch.Size = new System.Drawing.Size(125, 25);
            this.lblBatch.TabIndex = 12;
            this.lblBatch.Text = "Batch Name:";
            // 
            // txtSprice
            // 
            this.txtSprice.Location = new System.Drawing.Point(186, 187);
            this.txtSprice.Name = "txtSprice";
            this.txtSprice.Size = new System.Drawing.Size(250, 22);
            this.txtSprice.TabIndex = 4;
            // 
            // txtprice
            // 
            this.txtprice.Location = new System.Drawing.Point(186, 147);
            this.txtprice.Name = "txtprice";
            this.txtprice.Size = new System.Drawing.Size(250, 22);
            this.txtprice.TabIndex = 3;
            // 
            // txtquantity
            // 
            this.txtquantity.Location = new System.Drawing.Point(186, 107);
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(250, 22);
            this.txtquantity.TabIndex = 2;
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView2.ColumnHeadersHeight = 29;
            this.dataGridView2.Location = new System.Drawing.Point(598, 49);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(545, 237);
            this.dataGridView2.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView1.ColumnHeadersHeight = 29;
            this.dataGridView1.Location = new System.Drawing.Point(33, 385);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(1182, 342);
            this.dataGridView1.TabIndex = 10;
            // 
            // lblSerial
            // 
            this.lblSerial.AutoSize = true;
            this.lblSerial.Location = new System.Drawing.Point(10, 23);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(93, 16);
            this.lblSerial.TabIndex = 1;
            this.lblSerial.Text = "Serial Number";
            // 
            // txtserialinput
            // 
            this.txtserialinput.Location = new System.Drawing.Point(120, 23);
            this.txtserialinput.Name = "txtserialinput";
            this.txtserialinput.Size = new System.Drawing.Size(200, 22);
            this.txtserialinput.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtserialinput);
            this.panel1.Controls.Add(this.lblSerial);
            this.panel1.Location = new System.Drawing.Point(33, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(350, 60);
            this.panel1.TabIndex = 0;
            // 
            // txtpro
            // 
            this.txtpro.Location = new System.Drawing.Point(186, 75);
            this.txtpro.Name = "txtpro";
            this.txtpro.Size = new System.Drawing.Size(250, 22);
            this.txtpro.TabIndex = 18;
            this.txtpro.TextChanged += new System.EventHandler(this.txtproducts_TextChanged);
            // 
            // txtBnames
            // 
            this.txtBnames.Location = new System.Drawing.Point(186, 27);
            this.txtBnames.Name = "txtBnames";
            this.txtBnames.Size = new System.Drawing.Size(250, 22);
            this.txtBnames.TabIndex = 19;
            // 
            // iconPictureBox1
            // 
            this.iconPictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.iconPictureBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.iconPictureBox1.IconColor = System.Drawing.SystemColors.Control;
            this.iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox1.Location = new System.Drawing.Point(456, 75);
            this.iconPictureBox1.Name = "iconPictureBox1";
            this.iconPictureBox1.Size = new System.Drawing.Size(49, 32);
            this.iconPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.iconPictureBox1.TabIndex = 153;
            this.iconPictureBox1.TabStop = false;
            this.iconPictureBox1.Click += new System.EventHandler(this.iconPictureBox1_Click);
            // 
            // AddbatchDetailsform
            // 
            this.ClientSize = new System.Drawing.Size(1285, 817);
            this.Controls.Add(this.iconPictureBox1);
            this.Controls.Add(this.txtBnames);
            this.Controls.Add(this.txtpro);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.txtquantity);
            this.Controls.Add(this.txtprice);
            this.Controls.Add(this.txtSprice);
            this.Controls.Add(this.lblBatch);
            this.Controls.Add(this.lblProducts);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.lblCostPrice);
            this.Controls.Add(this.lblSalePrice);
            this.Controls.Add(this.btnAdditem);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.checkBox1);
            this.MaximizeBox = false;
            this.Name = "AddbatchDetailsform";
            this.Text = "Add Batch Details";
            this.Load += new System.EventHandler(this.AddbatchDetailsform_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Button btnAdditem;
        private System.Windows.Forms.Label lblSalePrice;
        private System.Windows.Forms.Label lblCostPrice;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblBatch;
        private System.Windows.Forms.TextBox txtSprice;
        private System.Windows.Forms.TextBox txtprice;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblSerial;
        private System.Windows.Forms.TextBox txtserialinput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtpro;
        private System.Windows.Forms.TextBox txtBnames;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
    }
}
