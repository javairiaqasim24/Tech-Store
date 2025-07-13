namespace TechStore.UI
{
    partial class EditDeleteServices
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
            this.dvgservices = new System.Windows.Forms.DataGridView();
            this.cmbsearchcustomer = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dvgservices)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dvgservices
            // 
            this.dvgservices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dvgservices.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dvgservices.BackgroundColor = System.Drawing.Color.White;
            this.dvgservices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dvgservices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvgservices.Location = new System.Drawing.Point(27, 323);
            this.dvgservices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dvgservices.Name = "dvgservices";
            this.dvgservices.RowHeadersWidth = 62;
            this.dvgservices.RowTemplate.Height = 28;
            this.dvgservices.Size = new System.Drawing.Size(1614, 452);
            this.dvgservices.TabIndex = 0;
            this.dvgservices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dvgservices_CellClick);
            this.dvgservices.CurrentCellDirtyStateChanged += new System.EventHandler(this.dvgservices_CurrentCellDirtyStateChanged);
            // 
            // cmbsearchcustomer
            // 
            this.cmbsearchcustomer.FormattingEnabled = true;
            this.cmbsearchcustomer.Location = new System.Drawing.Point(74, 262);
            this.cmbsearchcustomer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbsearchcustomer.Name = "cmbsearchcustomer";
            this.cmbsearchcustomer.Size = new System.Drawing.Size(328, 24);
            this.cmbsearchcustomer.TabIndex = 1;
            this.cmbsearchcustomer.SelectedIndexChanged += new System.EventHandler(this.cmbsearchcustomer_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1669, 125);
            this.panel1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(692, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(271, 69);
            this.label2.TabIndex = 1;
            this.label2.Text = "Services";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(69, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Customer:";
            // 
            // EditDeleteServices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1669, 835);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cmbsearchcustomer);
            this.Controls.Add(this.dvgservices);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "EditDeleteServices";
            this.Text = "EditDeleteServices";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.EditDeleteServices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvgservices)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dvgservices;
        private System.Windows.Forms.ComboBox cmbsearchcustomer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}