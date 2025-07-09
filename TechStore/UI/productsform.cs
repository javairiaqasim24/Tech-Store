using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
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
using TechStore.Interfaces.BLInterfaces;
using TechStore.UI;
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
            UIHelper.StyleGridView(dataGridView2);


        }



        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                var row = dataGridView2.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtname1.Text = row.Cells["name"].Value?.ToString();
                txtdescp1.Text = row.Cells["description"].Value?.ToString();
                txtcategory.Text = row.Cells["category"].Value?.ToString();
                UIHelper.RoundPanelCorners(paneledit, 20);
                UIHelper.ShowCenteredPanel(this, paneledit);
            }
            else if (columnName == "Delete")
            {
                var result = MessageBox.Show("Are you sure you want to delete this product?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int productId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["id"].Value);
                    if (_productBl.DeleteProduct(productId))
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
        }

        private void load()
        {
            var list = _productBl.getproducts();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list.Select(p => new
            {
                p.id,
                p.name,
                p.description,
                p.category,
            }).ToList();

            dataGridView2.Columns["id"].Visible = false;

            dataGridView2.Columns["name"].HeaderText = "Product Name";
            dataGridView2.Columns["description"].HeaderText = "Description";
            dataGridView2.Columns["category"].HeaderText = "Category";

            // Add buttons using helper
            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");

            // Apply styling
            UIHelper.ApplyButtonStyles(dataGridView2);
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Load categories
            var categories = _productBl.getcategories("");
            txtcategory.Items.Clear();
            txtcategory.Items.AddRange(categories.ToArray());
            txtcategory.DropDownStyle = ComboBoxStyle.DropDown;
        }

        //private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (dataGridView2.Columns[e.ColumnIndex].Name == "Edit")
        //    {
        //        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;
        //        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.Black;
        //    }
        //    else if (dataGridView2.Columns[e.ColumnIndex].Name == "Delete")
        //    {
        //        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.IndianRed;
        //        dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.ForeColor = Color.White;
        //    }
        //}

        private void btndashboard_Click(object sender, EventArgs e)
        {

        }

        private void btnproducts_Click(object sender, EventArgs e)
        {
            Dashboard.Instance.LoadFormIntoPanel(new Loadingform());
        }
     
        private void Inventoryform_Load(object sender, EventArgs e)
        {
            //dataGridView2.CellContentClick -= dataGridView2_CellContentClick;
            //dataGridView2.CellContentClick += dataGridView2_CellContentClick;

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
        

        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                var row = dataGridView2.SelectedRows[0];

                selectedProductId = Convert.ToInt32(row.Cells["id"].Value);
                txtname1.Text = row.Cells["name"].Value?.ToString() ?? "";
                txtdescp1.Text = row.Cells["description"].Value?.ToString() ?? "";
                txtcategory.Text = row.Cells["category"].Value?.ToString() ?? "";

                // Safely handle nullable price and quantity

                UIHelper.RoundPanelCorners(paneledit, 20);

                UIHelper.ShowCenteredPanel(this,paneledit);
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
       

  

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f= Program.ServiceProvider.GetRequiredService<addproductform>();
            f.ShowDialog(this);
        }


        private void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtname1.Text.Trim();
                string description = txtdescp1.Text.Trim();
                string category = txtcategory.Text.Trim();


                var updatedProduct = new Products
                (
                     selectedProductId,
                 name,
                     
                    description,
                   category
                     
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while Updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

      

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          
        }

        private void btnstate_Click(object sender, EventArgs e)
        {
            var f =Program.ServiceProvider.GetRequiredService<Customersale>();
            Dashboard.Instance.LoadFormIntoPanel(f);
        }

        private void btncategory_Click(object sender, EventArgs e)
        {
            var f= Program.ServiceProvider.GetRequiredService<Addcategoryform>();
            f.ShowDialog(this);
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            string text = textBox1.Text.Trim();
            var list = string.IsNullOrEmpty(text) ? _productBl.getproducts() : _productBl.searchproducts(text);

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list.Select(p => new
            {
                p.id,
                p.name,
                p.description,
                p.category,
            }).ToList();

            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["id"].Visible = false;

            dataGridView2.Columns["name"].HeaderText = "Product Name";
            dataGridView2.Columns["description"].HeaderText = "Description";
            dataGridView2.Columns["category"].HeaderText = "Category";

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");
            UIHelper.ApplyButtonStyles(dataGridView2);
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<Batchesform>();
            Dashboard.Instance.LoadFormIntoPanel(f);
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<BatchDetailsform>();
            Dashboard.Instance.LoadFormIntoPanel(f);
        }


    }
}
