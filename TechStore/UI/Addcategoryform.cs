using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Addcategoryform : Form
    {
        private readonly IproductBl _productBl;
        public Addcategoryform(IproductBl _productBl)
        {
            InitializeComponent();
            this._productBl = _productBl;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim(); try
            {
                bool result = _productBl.addcategory(name);
                if (result)
                {
                    MessageBox.Show("Category added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear(); // Clear the input field after successful addition

                }
                else
                {
                    MessageBox.Show("Failed to add category. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }
    }

