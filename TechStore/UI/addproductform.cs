using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class addproductform : Form
    {
        private readonly IproductBl _productBl;
        public addproductform(IproductBl ibl)
        {
            InitializeComponent();
            _productBl = ibl;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string description = txtdescp.Text.Trim();
            string category = txtcategory.Text.Trim();
           
            try
            {
                Products products = new Products(name,  description, category);
                bool result = _productBl.AddProduct(products);
                if (result)
                {
                    MessageBox.Show("Product added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear();
                    txtdescp.Clear();
                    txtcategory.SelectedIndex = -1; // Clear the selected category
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
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while adding product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addproductform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var list = _productBl.getcategories(""); // Pass empty string to get all
            txtcategory.Items.Clear();
            txtcategory.Items.AddRange(list.ToArray());
            txtcategory.DropDownStyle = ComboBoxStyle.DropDown;
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

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            var f= Program.ServiceProvider.GetRequiredService<Addcategoryform>();
            f.ShowDialog(this);
            load();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
