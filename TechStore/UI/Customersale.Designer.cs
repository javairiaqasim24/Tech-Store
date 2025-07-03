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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtserial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtproductname = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.discount = new System.Windows.Forms.TextBox();
            this.txtsaleprice = new System.Windows.Forms.TextBox();
            this.finalpricetxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.finaldiscounttxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.priceafterdisc = new System.Windows.Forms.TextBox();
            this.btnadd = new FontAwesome.Sharp.IconButton();
            this.btndelete = new FontAwesome.Sharp.IconButton();
            this.quantity = new System.Windows.Forms.TextBox();
            this.btnsrch = new System.Windows.Forms.Button();
            this.manualserialtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.combocustomer = new System.Windows.Forms.ComboBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.txtfinalpaid = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.guna2CustomGradientPanel1 = new Guna.UI2.WinForms.Guna2CustomGradientPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.thermalprint = new System.Windows.Forms.RadioButton();
            this.A4printer = new System.Windows.Forms.RadioButton();
            this.onlypdf = new System.Windows.Forms.RadioButton();
            this.btnadcust = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.txtwarranty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtcustomer = new System.Windows.Forms.TextBox();
            this.toplbl = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.guna2CustomGradientPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(3, 303);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1506, 527);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtserial
            // 
            this.txtserial.Location = new System.Drawing.Point(456, 108);
            this.txtserial.Multiline = true;
            this.txtserial.Name = "txtserial";
            this.txtserial.Size = new System.Drawing.Size(205, 34);
            this.txtserial.TabIndex = 16;
            this.txtserial.TextChanged += new System.EventHandler(this.txtserial_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(283, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 29);
            this.label1.TabIndex = 17;
            this.label1.Text = "Apply barcode";
            // 
            // txtproductname
            // 
            this.txtproductname.Location = new System.Drawing.Point(30, 182);
            this.txtproductname.Multiline = true;
            this.txtproductname.Name = "txtproductname";
            this.txtproductname.Size = new System.Drawing.Size(217, 32);
            this.txtproductname.TabIndex = 18;
            this.txtproductname.TextChanged += new System.EventHandler(this.txtproductname_TextChanged);
            // 
            // txtdescription
            // 
            this.txtdescription.Location = new System.Drawing.Point(309, 182);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(217, 98);
            this.txtdescription.TabIndex = 20;
            this.txtdescription.TextChanged += new System.EventHandler(this.txtdescription_TextChanged);
            // 
            // discount
            // 
            this.discount.Location = new System.Drawing.Point(1024, 182);
            this.discount.Multiline = true;
            this.discount.Name = "discount";
            this.discount.Size = new System.Drawing.Size(147, 32);
            this.discount.TabIndex = 21;
            this.discount.TextChanged += new System.EventHandler(this.discount_TextChanged);
            // 
            // txtsaleprice
            // 
            this.txtsaleprice.Location = new System.Drawing.Point(593, 182);
            this.txtsaleprice.Multiline = true;
            this.txtsaleprice.Name = "txtsaleprice";
            this.txtsaleprice.Size = new System.Drawing.Size(151, 32);
            this.txtsaleprice.TabIndex = 22;
            this.txtsaleprice.TextChanged += new System.EventHandler(this.txtsaleprice_TextChanged);
            // 
            // finalpricetxt
            // 
            this.finalpricetxt.Location = new System.Drawing.Point(1080, 879);
            this.finalpricetxt.Multiline = true;
            this.finalpricetxt.Name = "finalpricetxt";
            this.finalpricetxt.Size = new System.Drawing.Size(164, 44);
            this.finalpricetxt.TabIndex = 23;
            this.finalpricetxt.TextChanged += new System.EventHandler(this.finalpricetxt_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label2.Location = new System.Drawing.Point(1075, 847);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 29);
            this.label2.TabIndex = 24;
            this.label2.Text = "Total amount";
            // 
            // finaldiscounttxt
            // 
            this.finaldiscounttxt.Location = new System.Drawing.Point(759, 879);
            this.finaldiscounttxt.Multiline = true;
            this.finaldiscounttxt.Name = "finaldiscounttxt";
            this.finaldiscounttxt.Size = new System.Drawing.Size(164, 44);
            this.finaldiscounttxt.TabIndex = 25;
            this.finaldiscounttxt.TextChanged += new System.EventHandler(this.finaldiscounttxt_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label3.Location = new System.Drawing.Point(754, 847);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 29);
            this.label3.TabIndex = 26;
            this.label3.Text = "Total Discount";
            // 
            // priceafterdisc
            // 
            this.priceafterdisc.Location = new System.Drawing.Point(1227, 182);
            this.priceafterdisc.Multiline = true;
            this.priceafterdisc.Name = "priceafterdisc";
            this.priceafterdisc.Size = new System.Drawing.Size(152, 32);
            this.priceafterdisc.TabIndex = 27;
            this.priceafterdisc.TextChanged += new System.EventHandler(this.priceafterdisc_TextChanged);
            // 
            // btnadd
            // 
            this.btnadd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnadd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(38)))), ((int)(((byte)(64)))));
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
            this.btnadd.Location = new System.Drawing.Point(1401, 104);
            this.btnadd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnadd.Name = "btnadd";
            this.btnadd.Size = new System.Drawing.Size(170, 52);
            this.btnadd.TabIndex = 105;
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
            this.btndelete.Location = new System.Drawing.Point(1401, 238);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(170, 52);
            this.btndelete.TabIndex = 107;
            this.btndelete.Text = "Delete";
            this.btndelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btndelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btndelete.UseVisualStyleBackColor = false;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // quantity
            // 
            this.quantity.Location = new System.Drawing.Point(804, 182);
            this.quantity.Multiline = true;
            this.quantity.Name = "quantity";
            this.quantity.Size = new System.Drawing.Size(152, 32);
            this.quantity.TabIndex = 108;
            this.quantity.Text = "1";
            this.quantity.TextChanged += new System.EventHandler(this.quantity_TextChanged);
            // 
            // btnsrch
            // 
            this.btnsrch.Location = new System.Drawing.Point(1122, 108);
            this.btnsrch.Name = "btnsrch";
            this.btnsrch.Size = new System.Drawing.Size(75, 23);
            this.btnsrch.TabIndex = 109;
            this.btnsrch.Text = "search";
            this.btnsrch.UseVisualStyleBackColor = true;
            this.btnsrch.Click += new System.EventHandler(this.btnsrch_Click);
            // 
            // manualserialtxt
            // 
            this.manualserialtxt.Location = new System.Drawing.Point(875, 108);
            this.manualserialtxt.Multiline = true;
            this.manualserialtxt.Name = "manualserialtxt";
            this.manualserialtxt.Size = new System.Drawing.Size(205, 34);
            this.manualserialtxt.TabIndex = 110;
            this.manualserialtxt.TextChanged += new System.EventHandler(this.manualserialtxt_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 24);
            this.label4.TabIndex = 111;
            this.label4.Text = "Product name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(1020, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 24);
            this.label5.TabIndex = 112;
            this.label5.Text = "Discount";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(800, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 24);
            this.label6.TabIndex = 113;
            this.label6.Text = "Quantity";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(589, 155);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 24);
            this.label7.TabIndex = 114;
            this.label7.Text = "Unit Price";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(305, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 24);
            this.label8.TabIndex = 115;
            this.label8.Text = "Specification";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(1223, 155);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 24);
            this.label9.TabIndex = 116;
            this.label9.Text = "Total Price";
            // 
            // combocustomer
            // 
            this.combocustomer.FormattingEnabled = true;
            this.combocustomer.Items.AddRange(new object[] {
            "Walk-in",
            "Regular"});
            this.combocustomer.Location = new System.Drawing.Point(30, 106);
            this.combocustomer.Name = "combocustomer";
            this.combocustomer.Size = new System.Drawing.Size(217, 28);
            this.combocustomer.TabIndex = 117;
            this.combocustomer.SelectedIndexChanged += new System.EventHandler(this.combocustomer_SelectedIndexChanged);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(156, 871);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(75, 46);
            this.btnsave.TabIndex = 118;
            this.btnsave.Text = "save";
            this.btnsave.UseVisualStyleBackColor = true;
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // txtfinalpaid
            // 
            this.txtfinalpaid.Location = new System.Drawing.Point(1378, 879);
            this.txtfinalpaid.Multiline = true;
            this.txtfinalpaid.Name = "txtfinalpaid";
            this.txtfinalpaid.Size = new System.Drawing.Size(164, 44);
            this.txtfinalpaid.TabIndex = 119;
            this.txtfinalpaid.TextChanged += new System.EventHandler(this.txtfinalpaid_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label10.Location = new System.Drawing.Point(1373, 847);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 29);
            this.label10.TabIndex = 120;
            this.label10.Text = "Paid amount";
            // 
            // guna2CustomGradientPanel1
            // 
            this.guna2CustomGradientPanel1.Controls.Add(this.label10);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtfinalpaid);
            this.guna2CustomGradientPanel1.Controls.Add(this.combocustomer);
            this.guna2CustomGradientPanel1.Controls.Add(this.label9);
            this.guna2CustomGradientPanel1.Controls.Add(this.label8);
            this.guna2CustomGradientPanel1.Controls.Add(this.label7);
            this.guna2CustomGradientPanel1.Controls.Add(this.label6);
            this.guna2CustomGradientPanel1.Controls.Add(this.label5);
            this.guna2CustomGradientPanel1.Controls.Add(this.label4);
            this.guna2CustomGradientPanel1.Controls.Add(this.manualserialtxt);
            this.guna2CustomGradientPanel1.Controls.Add(this.btnsrch);
            this.guna2CustomGradientPanel1.Controls.Add(this.quantity);
            this.guna2CustomGradientPanel1.Controls.Add(this.priceafterdisc);
            this.guna2CustomGradientPanel1.Controls.Add(this.label3);
            this.guna2CustomGradientPanel1.Controls.Add(this.finaldiscounttxt);
            this.guna2CustomGradientPanel1.Controls.Add(this.label2);
            this.guna2CustomGradientPanel1.Controls.Add(this.finalpricetxt);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtsaleprice);
            this.guna2CustomGradientPanel1.Controls.Add(this.discount);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtdescription);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtproductname);
            this.guna2CustomGradientPanel1.Controls.Add(this.label1);
            this.guna2CustomGradientPanel1.Controls.Add(this.txtserial);
            this.guna2CustomGradientPanel1.Controls.Add(this.panel1);
            this.guna2CustomGradientPanel1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(72)))), ((int)(((byte)(99)))));
            this.guna2CustomGradientPanel1.FillColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(125)))), ((int)(((byte)(157)))));
            this.guna2CustomGradientPanel1.FillColor3 = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.guna2CustomGradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.guna2CustomGradientPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.guna2CustomGradientPanel1.Name = "guna2CustomGradientPanel1";
            this.guna2CustomGradientPanel1.Size = new System.Drawing.Size(1583, 952);
            this.guna2CustomGradientPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.thermalprint);
            this.panel1.Controls.Add(this.A4printer);
            this.panel1.Controls.Add(this.onlypdf);
            this.panel1.Controls.Add(this.btnadcust);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txtwarranty);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtcustomer);
            this.panel1.Controls.Add(this.toplbl);
            this.panel1.Controls.Add(this.btnsave);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.btnadd);
            this.panel1.Controls.Add(this.btndelete);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1583, 952);
            this.panel1.TabIndex = 14;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // thermalprint
            // 
            this.thermalprint.AutoSize = true;
            this.thermalprint.Location = new System.Drawing.Point(3, 847);
            this.thermalprint.Name = "thermalprint";
            this.thermalprint.Size = new System.Drawing.Size(145, 24);
            this.thermalprint.TabIndex = 124;
            this.thermalprint.TabStop = true;
            this.thermalprint.Text = "Print on thermal";
            this.thermalprint.UseVisualStyleBackColor = true;
            this.thermalprint.CheckedChanged += new System.EventHandler(this.thermalprint_CheckedChanged);
            // 
            // A4printer
            // 
            this.A4printer.AutoSize = true;
            this.A4printer.Location = new System.Drawing.Point(3, 910);
            this.A4printer.Name = "A4printer";
            this.A4printer.Size = new System.Drawing.Size(112, 24);
            this.A4printer.TabIndex = 123;
            this.A4printer.TabStop = true;
            this.A4printer.Text = "Print on A4";
            this.A4printer.UseVisualStyleBackColor = true;
            this.A4printer.CheckedChanged += new System.EventHandler(this.A4printer_CheckedChanged);
            // 
            // onlypdf
            // 
            this.onlypdf.AutoSize = true;
            this.onlypdf.Location = new System.Drawing.Point(3, 880);
            this.onlypdf.Name = "onlypdf";
            this.onlypdf.Size = new System.Drawing.Size(92, 24);
            this.onlypdf.TabIndex = 121;
            this.onlypdf.TabStop = true;
            this.onlypdf.Text = "Only pdf";
            this.onlypdf.UseVisualStyleBackColor = true;
            this.onlypdf.CheckedChanged += new System.EventHandler(this.onlypdf_CheckedChanged);
            // 
            // btnadcust
            // 
            this.btnadcust.Location = new System.Drawing.Point(486, 883);
            this.btnadcust.Name = "btnadcust";
            this.btnadcust.Size = new System.Drawing.Size(75, 40);
            this.btnadcust.TabIndex = 122;
            this.btnadcust.Text = "add";
            this.btnadcust.UseVisualStyleBackColor = true;
            this.btnadcust.Click += new System.EventHandler(this.btnadcust_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Narrow", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(581, 238);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(74, 24);
            this.label12.TabIndex = 121;
            this.label12.Text = "warranty";
            // 
            // txtwarranty
            // 
            this.txtwarranty.Location = new System.Drawing.Point(593, 265);
            this.txtwarranty.Multiline = true;
            this.txtwarranty.Name = "txtwarranty";
            this.txtwarranty.Size = new System.Drawing.Size(151, 32);
            this.txtwarranty.TabIndex = 121;
            this.txtwarranty.TextChanged += new System.EventHandler(this.txtwarranty_TextChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label11.Location = new System.Drawing.Point(265, 833);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(173, 29);
            this.label11.TabIndex = 121;
            this.label11.Text = "Name of customer";
            // 
            // txtcustomer
            // 
            this.txtcustomer.Location = new System.Drawing.Point(258, 881);
            this.txtcustomer.Multiline = true;
            this.txtcustomer.Name = "txtcustomer";
            this.txtcustomer.Size = new System.Drawing.Size(205, 34);
            this.txtcustomer.TabIndex = 121;
            this.txtcustomer.TextChanged += new System.EventHandler(this.txtcustomer_TextChanged);
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
            // 
            // Customersale
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1583, 1042);
            this.Controls.Add(this.guna2CustomGradientPanel1);
            this.Name = "Customersale";
            this.Text = "Customersale";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.guna2CustomGradientPanel1.ResumeLayout(false);
            this.guna2CustomGradientPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtserial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtproductname;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.TextBox discount;
        private System.Windows.Forms.TextBox txtsaleprice;
        private System.Windows.Forms.TextBox finalpricetxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox finaldiscounttxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox priceafterdisc;
        private FontAwesome.Sharp.IconButton btnadd;
        private FontAwesome.Sharp.IconButton btndelete;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.Button btnsrch;
        private System.Windows.Forms.TextBox manualserialtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox combocustomer;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.TextBox txtfinalpaid;
        private System.Windows.Forms.Label label10;
        private Guna.UI2.WinForms.Guna2CustomGradientPanel guna2CustomGradientPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtcustomer;
        private System.Windows.Forms.TextBox txtwarranty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnadcust;
        private System.Windows.Forms.RadioButton thermalprint;
        private System.Windows.Forms.RadioButton A4printer;
        private System.Windows.Forms.RadioButton onlypdf;
    }
}