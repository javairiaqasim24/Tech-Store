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
using TechStore.UI;

namespace TechStore
{
    public partial class Inventoryform : Form
    {
        public Inventoryform()
        {
            InitializeComponent();

            paneledit.Visible = false;

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btndashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            Dashboard.Instance.LoadFormIntoPanel(new Loadingform());
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }
        private void Inventoryform_Load(object sender, EventArgs e)
        {

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

        private void btnedit_Click(object sender, EventArgs e)
        {
            ShowEditPanel();
            RoundPanelCorners(paneledit, 20);
        }
        private void ShowEditPanel()
        {
            paneledit.Left = (this.ClientSize.Width - paneledit.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneledit.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;

        }
    }
}
