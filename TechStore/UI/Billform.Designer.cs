namespace TechStore.UI
{
    partial class Billform
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtpaid = new System.Windows.Forms.TextBox();
            this.txtBname = new System.Windows.Forms.ComboBox();
            this.txtsupplier = new System.Windows.Forms.ComboBox();
            this.txttotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(109, 312);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 30);
            this.label1.TabIndex = 171;
            this.label1.Text = "Paid Amount";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtpaid
            // 
            this.txtpaid.BackColor = System.Drawing.Color.Gainsboro;
            this.txtpaid.Location = new System.Drawing.Point(111, 345);
            this.txtpaid.Multiline = true;
            this.txtpaid.Name = "txtpaid";
            this.txtpaid.Size = new System.Drawing.Size(313, 37);
            this.txtpaid.TabIndex = 170;
            // 
            // txtBname
            // 
            this.txtBname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtBname.FormattingEnabled = true;
            this.txtBname.Location = new System.Drawing.Point(114, 131);
            this.txtBname.Name = "txtBname";
            this.txtBname.Size = new System.Drawing.Size(313, 24);
            this.txtBname.TabIndex = 169;
            // 
            // txtsupplier
            // 
            this.txtsupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtsupplier.FormattingEnabled = true;
            this.txtsupplier.Location = new System.Drawing.Point(111, 191);
            this.txtsupplier.Name = "txtsupplier";
            this.txtsupplier.Size = new System.Drawing.Size(313, 24);
            this.txtsupplier.TabIndex = 168;
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.Color.Gainsboro;
            this.txttotal.Location = new System.Drawing.Point(114, 272);
            this.txttotal.Multiline = true;
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(313, 37);
            this.txttotal.TabIndex = 167;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label7.Location = new System.Drawing.Point(106, 229);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 30);
            this.label7.TabIndex = 166;
            this.label7.Text = "Total Price";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label9.Location = new System.Drawing.Point(109, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 30);
            this.label9.TabIndex = 165;
            this.label9.Text = "Supllier Name";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label10.Location = new System.Drawing.Point(109, 86);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(133, 30);
            this.label10.TabIndex = 164;
            this.label10.Text = "Batch Name";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label2.Location = new System.Drawing.Point(139, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(218, 38);
            this.label2.TabIndex = 172;
            this.label2.Text = "Generate Bill";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label3.Location = new System.Drawing.Point(109, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 30);
            this.label3.TabIndex = 173;
            this.label3.Text = "Date";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtdate
            // 
            this.txtdate.Location = new System.Drawing.Point(114, 439);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(310, 22);
            this.txtdate.TabIndex = 174;
            // 
            // Billform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 638);
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtpaid);
            this.Controls.Add(this.txtBname);
            this.Controls.Add(this.txtsupplier);
            this.Controls.Add(this.txttotal);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Name = "Billform";
            this.Text = "Billform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtpaid;
        private System.Windows.Forms.ComboBox txtBname;
        private System.Windows.Forms.ComboBox txtsupplier;
        private System.Windows.Forms.TextBox txttotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker txtdate;
    }
}