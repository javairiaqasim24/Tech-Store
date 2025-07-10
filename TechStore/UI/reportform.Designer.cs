namespace TechStore.UI
{
    partial class reportform
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
            this.btnmonth = new FontAwesome.Sharp.IconButton();
            this.btnyear = new FontAwesome.Sharp.IconButton();
            this.dtpdate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnmonth
            // 
            this.btnmonth.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnmonth.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btnmonth.FlatAppearance.BorderSize = 2;
            this.btnmonth.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnmonth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnmonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmonth.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnmonth.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnmonth.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnmonth.IconColor = System.Drawing.Color.White;
            this.btnmonth.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnmonth.IconSize = 40;
            this.btnmonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmonth.Location = new System.Drawing.Point(39, 80);
            this.btnmonth.Name = "btnmonth";
            this.btnmonth.Size = new System.Drawing.Size(340, 60);
            this.btnmonth.TabIndex = 2;
            this.btnmonth.Text = "By Month";
            this.btnmonth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnmonth.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnmonth.UseVisualStyleBackColor = false;
            this.btnmonth.Click += new System.EventHandler(this.btnmonth_Click);
            // 
            // btnyear
            // 
            this.btnyear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.btnyear.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.btnyear.FlatAppearance.BorderSize = 2;
            this.btnyear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnyear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(51)))), ((int)(((byte)(69)))));
            this.btnyear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnyear.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnyear.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnyear.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnyear.IconColor = System.Drawing.Color.White;
            this.btnyear.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnyear.IconSize = 40;
            this.btnyear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyear.Location = new System.Drawing.Point(39, 181);
            this.btnyear.Name = "btnyear";
            this.btnyear.Size = new System.Drawing.Size(340, 60);
            this.btnyear.TabIndex = 3;
            this.btnyear.Text = "By Year";
            this.btnyear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnyear.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnyear.UseVisualStyleBackColor = false;
            this.btnyear.Click += new System.EventHandler(this.btnyear_Click);
            // 
            // dtpdate
            // 
            this.dtpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.dtpdate.Checked = true;
            this.dtpdate.FillColor = System.Drawing.Color.White;
            this.dtpdate.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpdate.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            this.dtpdate.Location = new System.Drawing.Point(39, 323);
            this.dtpdate.MaxDate = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.dtpdate.MinDate = new System.DateTime(1753, 1, 1, 0, 0, 0, 0);
            this.dtpdate.Name = "dtpdate";
            this.dtpdate.Size = new System.Drawing.Size(336, 36);
            this.dtpdate.TabIndex = 165;
            this.dtpdate.Value = new System.DateTime(2025, 7, 10, 0, 0, 0, 0);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(61)))), ((int)(((byte)(147)))));
            this.label7.Location = new System.Drawing.Point(42, 265);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label7.Size = new System.Drawing.Size(249, 44);
            this.label7.TabIndex = 166;
            this.label7.Text = "Pick Month/Year";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(52)))), ((int)(((byte)(88)))));
            this.label1.Location = new System.Drawing.Point(70, 20);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
            this.label1.Size = new System.Drawing.Size(284, 47);
            this.label1.TabIndex = 167;
            this.label1.Text = "Generate Report";
            // 
            // reportform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 516);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpdate);
            this.Controls.Add(this.btnyear);
            this.Controls.Add(this.btnmonth);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "reportform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "reportform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnmonth;
        private FontAwesome.Sharp.IconButton btnyear;
        private Guna.UI2.WinForms.Guna2DateTimePicker dtpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}