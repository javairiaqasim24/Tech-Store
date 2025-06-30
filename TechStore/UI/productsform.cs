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
    public partial class productsform : Form
    {
        private readonly IproductBl _productBl;
        private int selectedProductId;

        public productsform(IproductBl ibl)
        {
            InitializeComponent();
            paneledit.Visible = false;
            //paneladd.Visible = false;
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
                p.category,
                p.price,
                p.quantity
            }).ToList();
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false; // Hide the ID column
            dataGridView2.Columns["name"].HeaderText = "Product Name";
            dataGridView2.Columns["sku"].HeaderText = "SKU";
            dataGridView2.Columns["description"].HeaderText = "Description";
            dataGridView2.Columns["category"].HeaderText = "Category";
            dataGridView2.Columns["price"].HeaderText = "Unit Price";
            dataGridView2.Columns["quantity"].HeaderText = "Quantity in Stock";
            var lists = _productBl.getcategories(""); 
            txtcategory.Items.Clear();
            txtcategory.Items.AddRange(lists.ToArray());
            txtcategory.DropDownStyle = ComboBoxStyle.DropDown;
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
        private void txtcategory_TextChanged(object sender, EventArgs e)
        {
            string text = txtcategory.Text.Trim();
            var list = _productBl.getcategories(text);

            if (list.Count > 0)
            {
                txtcategory.Items.Clear();
                txtcategory.Items.AddRange(list.ToArray());
                txtcategory.DroppedDown = true;
                txtcategory.SelectionStart = txtcategory.Text.Length;
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

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var row = dataGridView2.SelectedRows[0];

                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtname1.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtsku1.Text = row.Cells["sku"].Value?.ToString() ?? "";
                txtdescp1.Text = row.Cells["description"].Value?.ToString() ?? "";
                txtcategory.Text = row.Cells["category"].Value?.ToString() ?? "";

                // Safely handle nullable price and quantity
                txtquantity.Text = row.Cells["quantity"].Value != null ? row.Cells["quantity"].Value.ToString() : "0";
                txtprice.Text = row.Cells["price"].Value != null ? row.Cells["price"].Value.ToString() : "0.00";

                ShowEditPanel();
                RoundPanelCorners(paneledit, 20);
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        private void ShowEditPanel()
        {
            paneledit.Left = (this.ClientSize.Width - paneledit.Width) / 2;
            paneledit.Top = (this.ClientSize.Height - paneledit.Height) / 2;
            paneledit.BringToFront();
            paneledit.Visible = true;
        }
        //private void ShowaddPanel()
        //{
        //    paneladd.Left = (this.ClientSize.Width - paneladd.Width) / 2;
        //    paneladd.Top = (this.ClientSize.Height - paneladd.Height) / 2;
        //    paneladd.BringToFront();
        //    paneladd.Visible = true;
        //}

        private void btnsave_Click(object sender, EventArgs e)
        {

            //string name = txtname.Text.Trim();
            //string sku = txtsku.Text.Trim();
            //string description = txtdescp.Text.Trim();
            //string category = txtcategory.Text.Trim();
            //try
            //{
            //    Products products = new Products(name, sku, description, category);
            //    bool result = _productBl.AddProduct(products);
            //    if (result)
            //    {
            //        MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("Failed to add product. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //}
            //catch (ArgumentNullException ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //catch (ArgumentException ex)
            //{
            //    MessageBox.Show("Error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            //paneladd.Visible = false;

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f= Program.ServiceProvider.GetRequiredService<addproductform>();
            f.ShowDialog(this);
        }

        private void paneledit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname1.Text.Trim();
                string sku = txtsku1.Text.Trim();
                string description = txtdescp1.Text.Trim();
                string category = txtcategory.Text.Trim();
                int quantity = Convert.ToInt32(txtquantity.Text.Trim());
                double price = Convert.ToDouble(txtprice.Text.Trim());


                var updatedProduct = new Products
                (
                     selectedProductId,
                 name,
                     sku,
                    description,
                   category,
                     quantity,
                     price
                );

                bool result = _productBl.UpdateProduct(updatedProduct);

                if (result)
                {
                    MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    load();
                    paneledit.Visible = false;
                }
                else
                {
                    MessageBox.Show("Update failed. Try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Error updating product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var confirm = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (confirm == DialogResult.Yes)
                {
                    int productId = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["id"].Value);
                    bool result = _productBl.DeleteProduct(productId);

                    if (result)
                    {
                        MessageBox.Show("Product deleted successfully.", "Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        load();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text= textBox1.Text.Trim();
            var list = _productBl.searchproducts(text);
            if (list.Count > 0)
            {
                dataGridView2.DataSource = list.Select(p => new
                {
                    p.id,
                    p.name,
                    p.sku,
                    p.description,
                    p.category,
                    p.price,
                    p.quantity
                }).ToList();
            }
            else
            {
                dataGridView2.DataSource = _productBl.getproducts(); // Clear the DataGridView if no results found
            }
        }

        private void paneledit_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}
