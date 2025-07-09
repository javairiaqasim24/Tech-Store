namespace TechStore.UI
{
    partial class Customerreturns
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelreturn = new System.Windows.Forms.Panel();
            this.cbActionTaken = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtreturnedamount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtreason = new System.Windows.Forms.TextBox();
            this.txtquantity = new System.Windows.Forms.TextBox();
            this.txtproduct = new System.Windows.Forms.TextBox();
            this.txtdescription = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btncancle1 = new FontAwesome.Sharp.IconButton();
            this.btnsave1 = new FontAwesome.Sharp.IconButton();
            this.label9 = new System.Windows.Forms.Label();
            this.txtscamserial = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.idsearchtxt = new System.Windows.Forms.TextBox();
            this.toplbl = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelreturn.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(242)))), ((int)(((byte)(253)))));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 148);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(1600, 437);
            this.dataGridView1.TabIndex = 134;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SeaShell;
            this.panel1.Controls.Add(this.panelreturn);
            this.panel1.Controls.Add(this.btn);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.idsearchtxt);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1656, 704);
            this.panel1.TabIndex = 18;
            // 
            // panelreturn
            // 
            this.panelreturn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(200)))), ((int)(((byte)(254)))));
            this.panelreturn.Controls.Add(this.cbActionTaken);
            this.panelreturn.Controls.Add(this.label6);
            this.panelreturn.Controls.Add(this.txtreturnedamount);
            this.panelreturn.Controls.Add(this.label5);
            this.panelreturn.Controls.Add(this.dateTimePicker1);
            this.panelreturn.Controls.Add(this.label4);
            this.panelreturn.Controls.Add(this.label3);
            this.panelreturn.Controls.Add(this.txtreason);
            this.panelreturn.Controls.Add(this.txtquantity);
            this.panelreturn.Controls.Add(this.txtproduct);
            this.panelreturn.Controls.Add(this.txtdescription);
            this.panelreturn.Controls.Add(this.label7);
            this.panelreturn.Controls.Add(this.btncancle1);
            this.panelreturn.Controls.Add(this.btnsave1);
            this.panelreturn.Controls.Add(this.label9);
            this.panelreturn.Controls.Add(this.txtscamserial);
            this.panelreturn.Controls.Add(this.label10);
            this.panelreturn.Controls.Add(this.label11);
            this.panelreturn.Location = new System.Drawing.Point(389, 6);
            this.panelreturn.Name = "panelreturn";
            this.panelreturn.Size = new System.Drawing.Size(660, 694);
            this.panelreturn.TabIndex = 139;
            this.panelreturn.Paint += new System.Windows.Forms.PaintEventHandler(this.panelreturn_Paint);
            // 
            // cbActionTaken
            // 
            this.cbActionTaken.FormattingEnabled = true;
            this.cbActionTaken.Location = new System.Drawing.Point(528, 238);
            this.cbActionTaken.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbActionTaken.Name = "cbActionTaken";
            this.cbActionTaken.Size = new System.Drawing.Size(108, 24);
            this.cbActionTaken.TabIndex = 162;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label6.Location = new System.Drawing.Point(167, 593);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(187, 30);
            this.label6.TabIndex = 161;
            this.label6.Text = "Amount returned";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtreturnedamount
            // 
            this.txtreturnedamount.BackColor = System.Drawing.Color.Gainsboro;
            this.txtreturnedamount.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreturnedamount.Location = new System.Drawing.Point(172, 625);
            this.txtreturnedamount.Multiline = true;
            this.txtreturnedamount.Name = "txtreturnedamount";
            this.txtreturnedamount.Size = new System.Drawing.Size(313, 35);
            this.txtreturnedamount.TabIndex = 160;
            this.txtreturnedamount.TextChanged += new System.EventHandler(this.txtreturnedamount_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label5.Location = new System.Drawing.Point(167, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 30);
            this.label5.TabIndex = 159;
            this.label5.Text = "Date";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(172, 558);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(313, 22);
            this.dateTimePicker1.TabIndex = 158;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label4.Location = new System.Drawing.Point(167, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 30);
            this.label4.TabIndex = 157;
            this.label4.Text = "Reason";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(167, 331);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 30);
            this.label3.TabIndex = 156;
            this.label3.Text = "quantity";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtreason
            // 
            this.txtreason.BackColor = System.Drawing.Color.Gainsboro;
            this.txtreason.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtreason.Location = new System.Drawing.Point(172, 442);
            this.txtreason.Multiline = true;
            this.txtreason.Name = "txtreason";
            this.txtreason.Size = new System.Drawing.Size(313, 73);
            this.txtreason.TabIndex = 155;
            this.txtreason.TextChanged += new System.EventHandler(this.txtreason_TextChanged);
            // 
            // txtquantity
            // 
            this.txtquantity.BackColor = System.Drawing.Color.Gainsboro;
            this.txtquantity.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtquantity.Location = new System.Drawing.Point(172, 363);
            this.txtquantity.Multiline = true;
            this.txtquantity.Name = "txtquantity";
            this.txtquantity.Size = new System.Drawing.Size(313, 35);
            this.txtquantity.TabIndex = 154;
            this.txtquantity.TextChanged += new System.EventHandler(this.txtquantity_TextChanged_1);
            // 
            // txtproduct
            // 
            this.txtproduct.BackColor = System.Drawing.Color.Gainsboro;
            this.txtproduct.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtproduct.Location = new System.Drawing.Point(172, 162);
            this.txtproduct.Multiline = true;
            this.txtproduct.Name = "txtproduct";
            this.txtproduct.ReadOnly = true;
            this.txtproduct.Size = new System.Drawing.Size(313, 35);
            this.txtproduct.TabIndex = 151;
            this.txtproduct.TextChanged += new System.EventHandler(this.txtproduct_TextChanged);
            // 
            // txtdescription
            // 
            this.txtdescription.BackColor = System.Drawing.Color.Gainsboro;
            this.txtdescription.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescription.Location = new System.Drawing.Point(172, 224);
            this.txtdescription.Multiline = true;
            this.txtdescription.Name = "txtdescription";
            this.txtdescription.Size = new System.Drawing.Size(313, 90);
            this.txtdescription.TabIndex = 139;
            this.txtdescription.TextChanged += new System.EventHandler(this.txtdescription_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label7.Location = new System.Drawing.Point(167, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(127, 30);
            this.label7.TabIndex = 138;
            this.label7.Text = "Description";
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
            this.btncancle1.Location = new System.Drawing.Point(497, 646);
            this.btncancle1.Name = "btncancle1";
            this.btncancle1.Size = new System.Drawing.Size(151, 42);
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
            this.btnsave1.Location = new System.Drawing.Point(8, 650);
            this.btnsave1.Name = "btnsave1";
            this.btnsave1.Size = new System.Drawing.Size(151, 42);
            this.btnsave1.TabIndex = 136;
            this.btnsave1.Text = "Save";
            this.btnsave1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnsave1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnsave1.UseVisualStyleBackColor = false;
            this.btnsave1.Click += new System.EventHandler(this.btnsave1_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label9.Location = new System.Drawing.Point(180, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(152, 30);
            this.label9.TabIndex = 132;
            this.label9.Text = "Product name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtscamserial
            // 
            this.txtscamserial.BackColor = System.Drawing.Color.Gainsboro;
            this.txtscamserial.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtscamserial.Location = new System.Drawing.Point(172, 92);
            this.txtscamserial.Multiline = true;
            this.txtscamserial.Name = "txtscamserial";
            this.txtscamserial.Size = new System.Drawing.Size(313, 35);
            this.txtscamserial.TabIndex = 131;
            this.txtscamserial.TextChanged += new System.EventHandler(this.txtscamserial_TextChanged_1);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label10.Location = new System.Drawing.Point(167, 56);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 30);
            this.label10.TabIndex = 130;
            this.label10.Text = "Sacn bar Code";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label11.Location = new System.Drawing.Point(240, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(192, 38);
            this.label11.TabIndex = 7;
            this.label11.Text = "Add Return";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn
            // 
            this.btn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn.Location = new System.Drawing.Point(1564, 34);
            this.btn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(67, 50);
            this.btn.TabIndex = 137;
            this.btn.Text = "button2";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.btn_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(31, 34);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 50);
            this.button1.TabIndex = 136;
            this.button1.Text = "Return";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1087, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 135;
            this.label1.Text = "Enter the bill ID";
            // 
            // idsearchtxt
            // 
            this.idsearchtxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.idsearchtxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.idsearchtxt.Location = new System.Drawing.Point(1310, 34);
            this.idsearchtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.idsearchtxt.Multiline = true;
            this.idsearchtxt.Name = "idsearchtxt";
            this.idsearchtxt.Size = new System.Drawing.Size(233, 55);
            this.idsearchtxt.TabIndex = 119;
            this.idsearchtxt.TextChanged += new System.EventHandler(this.idsearchtxt_TextChanged);
            // 
            // toplbl
            // 
            this.toplbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.toplbl.AutoSize = true;
            this.toplbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toplbl.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.toplbl.Location = new System.Drawing.Point(709, 26);
            this.toplbl.Name = "toplbl";
            this.toplbl.Size = new System.Drawing.Size(281, 38);
            this.toplbl.TabIndex = 6;
            this.toplbl.Text = "Customer Return";
            this.toplbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel2.Controls.Add(this.toplbl);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1656, 71);
            this.panel2.TabIndex = 17;
            // 
            // Customerreturns
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1656, 775);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Customerreturns";
            this.Text = "Customerreturns";
            this.Load += new System.EventHandler(this.Customerreturns_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelreturn.ResumeLayout(false);
            this.panelreturn.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox idsearchtxt;
        private System.Windows.Forms.Label toplbl;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn;
        private System.Windows.Forms.Panel panelreturn;
        private System.Windows.Forms.TextBox txtproduct;
        private System.Windows.Forms.TextBox txtdescription;
        private System.Windows.Forms.Label label7;
        private FontAwesome.Sharp.IconButton btncancle1;
        private FontAwesome.Sharp.IconButton btnsave1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtscamserial;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtreason;
        private System.Windows.Forms.TextBox txtquantity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtreturnedamount;
        private System.Windows.Forms.ComboBox cbActionTaken;
    }
}