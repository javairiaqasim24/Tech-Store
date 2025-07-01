using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Supplierform : Form
    {
        private int selectedProductId;

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private readonly ISupplierBL supplierBL;
        private readonly IPersonFactory ipf;
        public Supplierform(ISupplierBL supplierBL,IPersonFactory ipf)
        {
            InitializeComponent();
            this.supplierBL = supplierBL;
            this.ipf = ipf;
            paneledit.Visible = false;
        }
        public void ShowEditPanel()
        {
            paneledit.Left = (this.ClientSize.Width - paneledit.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneledit.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count>0) {
                var row = dataGridView2.SelectedRows[0];

                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtname1.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtaddress.Text = row.Cells["address"].Value?.ToString() ?? "";
                txtemail.Text = row.Cells["email"].Value?.ToString() ?? "";
                txtcontact.Text = row.Cells["contact"].Value?.ToString() ?? "";

                RoundPanelCorners(paneledit, 20);
                ShowEditPanel();
            }

        }
        public void RoundPanelCorners(Panel panel, int radius)
        {
            var bounds = new Rectangle(0, 0, panel.Width, panel.Height);
            int diameter = radius * 2;

            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddArc(bounds.Right - diameter, bounds.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            panel.Region = new Region(path);
        }
        private void Supplierform_Load(object sender, EventArgs e)
        {

        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            
        }

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<Addsupplierform>();
            f.ShowDialog(this);
        }
    }
}
