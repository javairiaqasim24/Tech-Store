namespace TechStore.UI
{
    partial class Customersale
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
            this.toplbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtserial = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.quantity = new System.Windows.Forms.TextBox();
            this.priceafterdisc = new System.Windows.Forms.TextBox();
            this.txtsaleprice = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.finaldiscounttxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.finalpricetxt = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtwarranty = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtfinalpaid = new System.Windows.Forms.TextBox();
            this.A4printer = new System.Windows.Forms.RadioButton();
            this.thermalprint = new System.Windows.Forms.RadioButton();
            this.onlypdf = new System.Windows.Forms.RadioButton();
            this.btnadcust = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button9 = new System.Windows.Forms.Button();
            this.manualserialtxt = new System.Windows.Forms.TextBox();
            this.combocustomer = new System.Windows.Forms.ComboBox();
            this.btnadd = new FontAwesome.Sharp.IconButton();
            this.btndelete = new FontAwesome.Sharp.IconButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel2.Controls.Add(this.toplbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1583, 89);
            this.panel2.TabIndex = 15;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // toplbl
            // 
            this.toplbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.toplbl.AutoSize = true;
            this.toplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toplbl.Location = new System.Drawing.Point(658, 32);
            this.toplbl.Name = "toplbl";
            this.toplbl.Size = new System.Drawing.Size(297, 46);
            this.toplbl.TabIndex = 6;
            this.toplbl.Text = "Customer Sale";
            this.toplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toplbl.Click += new System.EventHandler(this.toplbl_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtserial);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.quantity);
            this.panel1.Controls.Add(this.priceafterdisc);
            this.panel1.Controls.Add(this.txtsaleprice);
            this.panel1.Controls.Add(this.discount);
            this.panel1.Controls.Add(this.txtdescription);
            this.panel1.Controls.Add(this.txtproductname);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtwarranty);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.button9);
            this.panel1.Controls.Add(this.manualserialtxt);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 89);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1583, 953);
            this.panel1.TabIndex = 16;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint_1);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 29);
            this.label1.TabIndex = 163;
            this.label1.Text = "Barcode:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtserial
            // 
            this.txtserial.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtserial.Location = new System.Drawing.Point(15, 52);
            this.txtserial.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtserial.Multiline = true;
            this.txtserial.Name = "txtserial";
            this.txtserial.Size = new System.Drawing.Size(234, 34);
            this.txtserial.TabIndex = 162;
            this.txtserial.TextChanged += new System.EventHandler(this.txtserial_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(301, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 29);
            this.label9.TabIndex = 161;
            this.label9.Text = "Price:";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 295);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(142, 29);
            this.label8.TabIndex = 160;
            this.label8.Text = "Specification:";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(291, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(111, 29);
            this.label7.TabIndex = 159;
            this.label7.Text = "Unit Price:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(468, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 29);
            this.label6.TabIndex = 158;
            this.label6.Text = "Quantity:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 29);
            this.label5.TabIndex = 157;
            this.label5.Text = "Discount:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 29);
            this.label4.TabIndex = 156;
            this.label4.Text = "Product:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // quantity
            // 
            this.quantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quantity.Location = new System.Drawing.Point(473, 143);
            this.quantity.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.quantity.Multiline = true;
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(151, 38);
            this.quantity.TabIndex = 155;
            this.quantity.Text = "1";
            this.quantity.TextChanged += new System.EventHandler(this.quantity_TextChanged);
            // 
            // priceafterdisc
            // 
            this.priceafterdisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceafterdisc.Location = new System.Drawing.Point(296, 237);
            this.priceafterdisc.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceafterdisc.Multiline = true;
            this.priceafterdisc.Name = "priceafterdisc";
            this.priceafterdisc.Size = new System.Drawing.Size(151, 38);
            this.priceafterdisc.TabIndex = 154;
            this.priceafterdisc.TextChanged += new System.EventHandler(this.priceafterdisc_TextChanged);
            // 
            // txtsaleprice
            // 
            this.txtsaleprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtsaleprice.Location = new System.Drawing.Point(296, 143);
            this.txtsaleprice.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtsaleprice.Multiline = true;
            this.txtsaleprice.Name = "txtsaleprice";
            this.txtsaleprice.Size = new System.Drawing.Size(151, 38);
            this.txtsaleprice.TabIndex = 153;
            this.txtsaleprice.TextChanged += new System.EventHandler(this.txtsaleprice_TextChanged);
            // 
            // discount
            // 
            this.discount.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.discount.Location = new System.Drawing.Point(17, 237);
            this.discount.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.discount.Multiline = true;
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(232, 38);
            this.discount.TabIndex = 152;
            this.discount.TextChanged += new System.EventHandler(this.discount_TextChanged);
            // 
            // txtdescription
            // 
            this.txtdescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription.Location = new System.Drawing.Point(17, 333);
            this.txtdescription.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(234, 64);
            this.txtdescription.TabIndex = 151;
            this.txtdescription.TextChanged += new System.EventHandler(this.txtdescription_TextChanged);
            // 
            // txtproductname
            // 
            this.txtproductname.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproductname.Location = new System.Drawing.Point(17, 143);
            this.txtproductname.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtproductname.Multiline = true;
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(234, 38);
            this.txtproductname.TabIndex = 150;
            this.txtproductname.TextChanged += new System.EventHandler(this.txtproductname_TextChanged);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 26);
            this.label3.TabIndex = 149;
            this.label3.Text = "Discount:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // finaldiscounttxt
            // 
            this.finaldiscounttxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finaldiscounttxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finaldiscounttxt.Location = new System.Drawing.Point(108, 13);
            this.finaldiscounttxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finaldiscounttxt.Multiline = true;
            this.finaldiscounttxt.Name = "finaldiscounttxt";
            this.finaldiscounttxt.Size = new System.Drawing.Size(164, 33);
            this.finaldiscounttxt.TabIndex = 148;
            this.finaldiscounttxt.TextChanged += new System.EventHandler(this.finaldiscounttxt_TextChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(13, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 26);
            this.label2.TabIndex = 147;
            this.label2.Text = "Total:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // finalpricetxt
            // 
            this.finalpricetxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.finalpricetxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.finalpricetxt.Location = new System.Drawing.Point(108, 58);
            this.finalpricetxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.finalpricetxt.Multiline = true;
            this.finalpricetxt.Name = "finalpricetxt";
            this.finalpricetxt.Size = new System.Drawing.Size(164, 33);
            this.finalpricetxt.TabIndex = 146;
            this.finalpricetxt.TextChanged += new System.EventHandler(this.finalpricetxt_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(468, 206);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(107, 29);
            this.label12.TabIndex = 144;
            this.label12.Text = "Warranty:";
            this.label12.Click += new System.EventHandler(this.label12_Click);
            // 
            // txtwarranty
            // 
            this.txtwarranty.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtwarranty.Location = new System.Drawing.Point(473, 237);
            this.txtwarranty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtwarranty.Multiline = true;
            this.txtwarranty.Name = "txtwarranty";
            this.txtwarranty.Size = new System.Drawing.Size(151, 38);
            this.txtwarranty.TabIndex = 145;
            this.txtwarranty.TextChanged += new System.EventHandler(this.txtwarranty_TextChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label10.Location = new System.Drawing.Point(13, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 26);
            this.label10.TabIndex = 143;
            this.label10.Text = "Paid:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // txtfinalpaid
            // 
            this.txtfinalpaid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtfinalpaid.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfinalpaid.Location = new System.Drawing.Point(108, 106);
            this.txtfinalpaid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtfinalpaid.Multiline = true;
            this.txtfinalpaid.Name = "txtfinalpaid";
            this.txtfinalpaid.Size = new System.Drawing.Size(164, 33);
            this.txtfinalpaid.TabIndex = 142;
            this.txtfinalpaid.TextChanged += new System.EventHandler(this.txtfinalpaid_TextChanged);
            // 
            // A4printer
            // 
            this.A4printer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.A4printer.AutoSize = true;
            this.A4printer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.A4printer.Location = new System.Drawing.Point(103, 232);
            this.A4printer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.A4printer.Name = "A4printer";
            this.A4printer.Size = new System.Drawing.Size(59, 26);
            this.A4printer.TabIndex = 141;
            this.A4printer.TabStop = true;
            this.A4printer.Text = "A4";
            this.A4printer.UseVisualStyleBackColor = true;
            this.A4printer.CheckedChanged += new System.EventHandler(this.A4printer_CheckedChanged);
            // 
            // thermalprint
            // 
            this.thermalprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.thermalprint.AutoSize = true;
            this.thermalprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thermalprint.Location = new System.Drawing.Point(103, 169);
            this.thermalprint.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.thermalprint.Name = "thermalprint";
            this.thermalprint.Size = new System.Drawing.Size(108, 26);
            this.thermalprint.TabIndex = 140;
            this.thermalprint.TabStop = true;
            this.thermalprint.Text = "Thermal";
            this.thermalprint.UseVisualStyleBackColor = true;
            this.thermalprint.CheckedChanged += new System.EventHandler(this.thermalprint_CheckedChanged);
            // 
            // onlypdf
            // 
            this.onlypdf.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onlypdf.AutoSize = true;
            this.onlypdf.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onlypdf.Location = new System.Drawing.Point(103, 201);
            this.onlypdf.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.onlypdf.Name = "onlypdf";
            this.onlypdf.Size = new System.Drawing.Size(74, 26);
            this.onlypdf.TabIndex = 136;
            this.onlypdf.TabStop = true;
            this.onlypdf.Text = "PDF";
            this.onlypdf.UseVisualStyleBackColor = true;
            this.onlypdf.CheckedChanged += new System.EventHandler(this.onlypdf_CheckedChanged);
            // 
            // btnadcust
            // 
            this.btnadcust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnadcust.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnadcust.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadcust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadcust.ForeColor = System.Drawing.Color.White;
            this.btnadcust.Location = new System.Drawing.Point(43, 154);
            this.btnadcust.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnadcust.Name = "btnadcust";
            this.btnadcust.Size = new System.Drawing.Size(217, 47);
            this.btnadcust.TabIndex = 139;
            this.btnadcust.Text = "Add New Customer";
            this.btnadcust.UseVisualStyleBackColor = false;
            this.btnadcust.TextChanged += new System.EventHandler(this.btnadcust_Click);
            this.btnadcust.Click += new System.EventHandler(this.btnadcust_Click_1);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label11.Location = new System.Drawing.Point(19, 82);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 26);
            this.label11.TabIndex = 137;
            this.label11.Text = "Name:";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // txtcustomer
            // 
            this.txtcustomer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtcustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcustomer.Location = new System.Drawing.Point(22, 110);
            this.txtcustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtcustomer.Multiline = true;
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(250, 34);
            this.txtcustomer.TabIndex = 138;
            this.txtcustomer.TextChanged += new System.EventHandler(this.txtcustomer_TextChanged);
            // 
            // btnsave
            // 
            this.btnsave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnsave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsave.ForeColor = System.Drawing.Color.White;
            this.btnsave.Location = new System.Drawing.Point(70, 274);
            this.btnsave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(149, 46);
            this.btnsave.TabIndex = 135;
            this.btnsave.Text = "Save";
            this.btnsave.UseVisualStyleBackColor = false;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(30, 412);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1480, 506);
            this.dataGridView1.TabIndex = 134;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.button9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.button9.Location = new System.Drawing.Point(466, 44);
            this.button9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(120, 41);
            this.button9.TabIndex = 133;
            this.button9.Text = "Search";
            this.button9.UseVisualStyleBackColor = false;
            this.button9.Click += new System.EventHandler(this.btnsrch_Click);
            // 
            // manualserialtxt
            // 
            this.manualserialtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.manualserialtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.manualserialtxt.Location = new System.Drawing.Point(285, 52);
            this.manualserialtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.manualserialtxt.Multiline = true;
            this.manualserialtxt.Name = "manualserialtxt";
            this.manualserialtxt.Size = new System.Drawing.Size(151, 33);
            this.manualserialtxt.TabIndex = 119;
            this.manualserialtxt.TextChanged += new System.EventHandler(this.manualserialtxt_TextChanged);
            // 
            // combocustomer
            // 
            this.combocustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.combocustomer.FormattingEnabled = true;
            this.combocustomer.Items.AddRange(new object[] {
            "Walk-in",
            "Regular"});
            this.combocustomer.Location = new System.Drawing.Point(22, 28);
            this.combocustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.combocustomer.Name = "combocustomer";
            this.combocustomer.Size = new System.Drawing.Size(250, 40);
            this.combocustomer.TabIndex = 118;
            this.combocustomer.SelectedIndexChanged += new System.EventHandler(this.combocustomer_SelectedIndexChanged);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btnadd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnadd.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btnadd.FlatAppearance.BorderSize = 2;
            this.btnadd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btnadd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnadd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnadd.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnadd.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnadd.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            this.btnadd.IconColor = System.Drawing.Color.MediumTurquoise;
            this.btnadd.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnadd.IconSize = 35;
            this.btnadd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.Location = new System.Drawing.Point(295, 333);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(119, 50);
            this.btnadd.TabIndex = 108;
            this.btnadd.Text = "Add";
            this.btnadd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnadd.UseVisualStyleBackColor = false;
            this.btnadd.Click += new System.EventHandler(this.btnadd_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
            this.btndelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndelete.FlatAppearance.BorderColor = System.Drawing.Color.Indigo;
            this.btndelete.FlatAppearance.BorderSize = 2;
            this.btndelete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DodgerBlue;
            this.btndelete.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btndelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btndelete.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btndelete.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btndelete.IconChar = FontAwesome.Sharp.IconChar.Trash;
            this.btndelete.IconColor = System.Drawing.Color.Red;
            this.btndelete.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btndelete.IconSize = 35;
            this.btndelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.Location = new System.Drawing.Point(473, 333);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(131, 50);
            this.btndelete.TabIndex = 109;
            this.btndelete.Text = "Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.finaldiscounttxt);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.finalpricetxt);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnsave);
            this.groupBox1.Controls.Add(this.txtfinalpaid);
            this.groupBox1.Controls.Add(this.thermalprint);
            this.groupBox1.Controls.Add(this.onlypdf);
            this.groupBox1.Controls.Add(this.A4printer);
            this.groupBox1.Location = new System.Drawing.Point(1144, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(293, 355);
            this.groupBox1.TabIndex = 164;
            this.groupBox1.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial Narrow", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label13.Location = new System.Drawing.Point(17, 168);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 26);
            this.label13.TabIndex = 150;
            this.label13.Text = "Print:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.combocustomer);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtcustomer);
            this.groupBox2.Controls.Add(this.btnadcust);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(760, 107);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(293, 217);
            this.groupBox2.TabIndex = 165;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Details:";
            // 
            // Customersale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 1042);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Customersale";
            this.Text = "Customersale";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Customersale_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtserial;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.TextBox priceafterdisc;
        private System.Windows.Forms.TextBox txtsaleprice;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox finaldiscounttxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox finalpricetxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtwarranty;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtfinalpaid;
        private System.Windows.Forms.RadioButton A4printer;
        private System.Windows.Forms.RadioButton thermalprint;
        private System.Windows.Forms.RadioButton onlypdf;
        private System.Windows.Forms.Button btnadcust;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox manualserialtxt;
        private System.Windows.Forms.ComboBox combocustomer;
        private FontAwesome.Sharp.IconButton btnadd;
        private FontAwesome.Sharp.IconButton btndelete;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}