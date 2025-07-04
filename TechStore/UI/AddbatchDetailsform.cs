using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class AddbatchDetailsform : Form
    {
        private readonly IBatchDetailsBL batchDetailsBL;
        private readonly IproductBl ibl;

        private int? selectedProductId;
        private string selectedProductName;
        private string selectedProductDescription;

        public AddbatchDetailsform(IBatchDetailsBL batchDetailsBL, IproductBl ibl)
        {
            InitializeComponent();
            this.batchDetailsBL = batchDetailsBL;
            this.ibl = ibl;
        }

        private void AddbatchDetailsform_Load(object sender, EventArgs e)
        {
            load();
            this.txtproducts.SelectedIndexChanged += txtproducts_SelectedIndexChanged;
            this.dataGridView2.CellClick += dataGridView2_CellClick;
        }

        private void load()
        {
            var productNames = batchDetailsBL.GetProductNames("");
            if (productNames != null && productNames.Count > 0)
            {
                txtproducts.Items.Clear();
                txtproducts.Items.AddRange(productNames.ToArray());

                var autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(productNames.ToArray());
                txtproducts.AutoCompleteCustomSource = autoSource;

                txtproducts.SelectedIndex = -1;
            }

            var batchNames = batchDetailsBL.GetBatches("");
            if (batchNames != null && batchNames.Count > 0)
            {
                txtBname.Items.Clear();
                txtBname.Items.AddRange(batchNames.ToArray());

                var autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(batchNames.ToArray());
                txtBname.AutoCompleteCustomSource = autoSource;

                txtBname.SelectedIndex = -1;
            }
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

                if (selectedProductId == null)
                {
                    MessageBox.Show("Please select a product from the grid.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                List<string> serialNumbers = txtserailnumber.Items.Cast<string>().ToList();
                if (serialNumbers.Count != quantity)
                {
                    MessageBox.Show("Serial number count must match the quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Batchdetails batchDetails = new Batchdetails(0, 0,selectedProductId.Value, "" ,quantity, costPrice, batchname);

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
                MessageBox.Show("Enter valid numeric values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dataGridView2.Rows.Clear();
            selectedProductId = null;
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            string serial = txtserialinput.Text.Trim();
            if (!string.IsNullOrEmpty(serial))
            {
                if (!int.TryParse(txtquantity.Text.Trim(), out int expectedCount))
                {
                    MessageBox.Show("Enter a valid quantity first.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (txtserailnumber.Items.Count >= expectedCount)
                {
                    MessageBox.Show("You’ve already added all required serials.", "Limit Reached", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (txtserailnumber.Items.Contains(serial))
                {
                    MessageBox.Show("This serial number is already added.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                txtserailnumber.Items.Add(serial);
                txtserialinput.Clear();
            }
        }

        private void txtproducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedProduct = txtproducts.Text.Trim();

            if (!string.IsNullOrEmpty(selectedProduct))
            {
                var productList = ibl.GetProductsByName(selectedProduct);
                if (productList != null && productList.Count > 0)
                {
                    dataGridView2.Rows.Clear();
                    dataGridView2.Columns.Clear();

                    dataGridView2.Columns.Add("ProductID", "Product ID");
                    dataGridView2.Columns["ProductID"].Visible = false;

                    dataGridView2.Columns.Add("Name", "Name");
                    dataGridView2.Columns.Add("Description", "Description");
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    foreach (var p in productList)
                    {
                        dataGridView2.Rows.Add(p.id, p.name, p.description);
                    }
                }
                else
                {
                    MessageBox.Show("No matching products found.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView2.Rows[e.RowIndex];
                selectedProductId = Convert.ToInt32(row.Cells["ProductID"].Value);
                selectedProductName = row.Cells["Name"].Value?.ToString();
                selectedProductDescription = row.Cells["Description"].Value?.ToString();

                txtproducts.Text = selectedProductName;

                // Optionally show confirmation
                MessageBox.Show($"Selected: ID={selectedProductId}, Name={selectedProductName}, Desc={selectedProductDescription}");
            }
        }
    }
}
