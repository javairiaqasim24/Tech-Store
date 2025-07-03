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
using System.Xml.Linq;
using TechStore.BL.BL;
using TechStore.BL.Models;

namespace TechStore.UI
{
    public partial class AddbatchDetailsform : Form
    {
        private readonly  IBatchDetailsBL batchDetailsBL;
        public AddbatchDetailsform(IBatchDetailsBL batchDetailsBL)
        {
            InitializeComponent();
            this.batchDetailsBL = batchDetailsBL;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                string batchname = txtBname.Text.Trim();
                string productname = txtproducts.Text.Trim();
                int quantity = Convert.ToInt32(txtquantity.Text.Trim());
                decimal costPrice = Convert.ToDecimal(txtprice.Text.Trim());
                decimal salePrice = Convert.ToDecimal(txtSprice.Text.Trim());

                // Validate serial numbers
                List<string> serialNumbers = txtserailnumber.Items.Cast<string>().ToList();
                if (serialNumbers.Count != quantity)
                {
                    MessageBox.Show("The number of serial numbers must match the quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create batch details model
                Batchdetails batchDetails = new Batchdetails(0, 0, 0, productname, quantity, costPrice, batchname);

                // Save to DB
                var result = batchDetailsBL.AddBatchDetailsWithSerial(batchDetails, serialNumbers, salePrice);

                if (result)
                {
                    MessageBox.Show("Batch and serial numbers added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Failed to add batch details.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter valid numeric values for quantity, cost price, and sale price.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void AddbatchDetailsform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var supplierList = batchDetailsBL.GetProductNames("");
            if (supplierList != null && supplierList.Count > 0)
            {
                txtproducts.Items.Clear();
                txtproducts.Items.AddRange(supplierList.ToArray());

                // Set up autocomplete source
                AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(supplierList.ToArray());
                txtproducts.AutoCompleteCustomSource = autoSource;

                txtproducts.SelectedIndex = -1; // No pre-selection
            }
            else
            {
                MessageBox.Show("No suppliers found. Please add suppliers first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var batch = batchDetailsBL.GetBatches("");
            if (batch != null && batch.Count > 0)
            {
                txtBname.Items.Clear();
                txtBname.Items.AddRange(batch.ToArray());

                // Set up autocomplete source
                AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(batch.ToArray());
                txtBname.AutoCompleteCustomSource = autoSource;

                txtBname    .SelectedIndex = -1; // No pre-selection
            }
            else
            {
                MessageBox.Show("No suppliers found. Please add suppliers first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void ClearFields()
        {
            txtBname.SelectedIndex = -1;
            txtproducts.SelectedIndex = -1;
            txtquantity.Clear();
            txtprice.Clear();
            txtSprice.Clear();
            txtserailnumber.Items.Clear();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string serial = txtserialinput.Text.Trim(); // Use a separate input textbox
            if (!string.IsNullOrEmpty(serial))
            {
                if (!txtserailnumber.Items.Contains(serial))
                    txtserailnumber.Items.Add(serial);
                else
                    MessageBox.Show("This serial number is already added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtserialinput.Clear(); // ✅ Clear only the input field
            }
        }

    }
}
