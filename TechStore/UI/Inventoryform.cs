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
using TechStore.BL.Models;
using TechStore.UI;
using TechStore.Interfaces.BLInterfaces;
namespace TechStore
{
    public partial class Inventoryform : Form
    {
        private readonly IproductBl _productBl;
        public Inventoryform(IproductBl ibl)
        {
            InitializeComponent();
            paneledit.Visible = false;
            paneladd.Visible = false;
            _productBl = ibl;
        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void load()
        {
            var list= _productBl.getproducts();
            dataGridView2.DataSource= list.Select(p => new
            {
                p.id,
                p.name,
                p.sku,
                p.description,
                p.category
            }).ToList();
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false; // Hide the ID column
            dataGridView2.Columns["name"].HeaderText = "Product Name";
            dataGridView2.Columns["sku"].HeaderText = "SKU";
            dataGridView2.Columns["description"].HeaderText = "Description";
            dataGridView2.Columns["category"].HeaderText = "Category";
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
            load();
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
            paneledit.Left = (this.ClientSize.Width - paneladd.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneladd.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }
        private void ShowaddPanel()
        {
            paneladd.Left = (this.ClientSize.Width - paneladd.Width) / 2;
            paneladd.Top = (this.ClientSize.Height - paneladd.Height) / 2;
            paneladd.BringToFront();
            paneladd.Visible = true;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {

            string name = txtname.Text.Trim();
            string sku = txtsku.Text.Trim();
            string description = txtdescp.Text.Trim();
            string category = txtcategory.Text.Trim();
            try
            {
                Products products = new Products(name, sku, description, category);
                bool result = _productBl.AddProduct(products);
                if (result)
                {
                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            paneladd.Visible = false;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            paneladd.Visible = true;
        }

        private void paneledit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsave1_Click(object sender, EventArgs e)
        {

        }
    }
}
