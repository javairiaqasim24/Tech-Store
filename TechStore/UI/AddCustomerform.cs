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
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.Interfaces;

namespace TechStore.UI
{
    public partial class AddCustomerform : Form
    {
        private readonly ICustomerBL _customerbl;
        public AddCustomerform(ICustomerBL customerBL )
        {
            InitializeComponent();
            _customerbl = customerBL;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string name = txtname.Text.Trim();
            string email = txtemail.Text.Trim();
            string address = txtaddress.Text.Trim();
            string type = comboBox1.Text.Trim(); // Walk_in or Regular
            string lastname = txtlname.Text.Trim();
            string phone = txtcontact.Text.Trim();

            try
            {
                // Common validation
                if (string.IsNullOrWhiteSpace(name))
                    throw new ArgumentException("First name is required.");

                if (string.IsNullOrWhiteSpace(lastname))
                    throw new ArgumentException("Last name is required.");

                //if (string.IsNullOrWhiteSpace(phone))
                //    throw new ArgumentException("Contact number is required.");

                if (string.IsNullOrWhiteSpace(type))
                    throw new ArgumentException("Customer type must be selected.");

                // Additional validation for Regular customers
                if (type.Equals("Regular", StringComparison.OrdinalIgnoreCase))
                {
                    if (string.IsNullOrWhiteSpace(email))
                        throw new ArgumentException("Email is required for Regular customers.");

                    if (string.IsNullOrWhiteSpace(address))
                        throw new ArgumentException("Address is required for Regular customers.");
                }
                //else if (!type.Equals("Walk_in", StringComparison.OrdinalIgnoreCase))
                //{
                //    throw new ArgumentException("Invalid customer type. Must be 'Walk_in' or 'Regular'.");
                //}

                Ipersons p = new Customer(0, email, address, name, lastname, type, phone);
 

                bool result = _customerbl.AddCustomer(p);
                if (result)
                {
                    MessageBox.Show("Customer added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname.Clear();
                    txtemail.Clear();
                    txtaddress.Clear();
                    txtcontact.Clear();
                    txtlname.Clear();
                    comboBox1.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("Failed to add customer. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An unexpected error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddCustomerform_Load(object sender, EventArgs e)
        {
            lblEmail.Visible = false;
            txtemail.Visible = false;

            lblAddress.Visible = false;
            txtaddress.Visible = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Regular")
            {
                lblEmail.Visible = true;
                txtemail.Visible = true;

                lblAddress.Visible = true;
                txtaddress.Visible = true;
            }
            else if (comboBox1.Text == "Walk_in")
            {
                lblEmail.Visible = false;
                txtemail.Visible = false;
                txtemail.Text = string.Empty;

                lblAddress.Visible = false;
                txtaddress.Visible = false;
                txtaddress.Text = string.Empty;
            }
        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }
    }
}