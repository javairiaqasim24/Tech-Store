using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.DL;
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
            panel1.Visible = checkBox1.Checked;
            txtserailnumber.DoubleClick += txtserailnumber_DoubleClick;
            txtserailnumber.KeyDown += txtserailnumber_KeyDown;
            this.txtproducts.TextChanged += txtproducts_TextChanged;
            this.txtBname.TextChanged += txtBname_TextChanged;


        }
        private void txtserailnumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && txtserailnumber.SelectedItem != null)
            {
                txtserailnumber.Items.Remove(txtserailnumber.SelectedItem);
            }
        }

        private void AddbatchDetailsform_Load(object sender, EventArgs e)
        {
            load();
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            checkBox1_CheckedChanged(null, null); // Apply initial state

            var temp = BatchFormPersistence.Load();
            if (temp != null)
            {
                txtBname.Text = temp.BatchName;
                txtproducts.Text = temp.ProductName;
                txtquantity.Text = temp.Quantity.ToString();
                txtprice.Text = temp.CostPrice.ToString();
                txtSprice.Text = temp.SalePrice.ToString();

                txtserailnumber.Items.Clear();
                foreach (var s in temp.SerialNumbers)
                    txtserailnumber.Items.Add(s);

                selectedProductId = temp.ProductId;
            }
            this.txtproducts.SelectedIndexChanged += txtproducts_SelectedIndexChanged;
            this.dataGridView2.CellClick += dataGridView2_CellClick;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (!string.IsNullOrEmpty(txtquantity.Text) && !string.IsNullOrEmpty(txtprice.Text))
            {
                var dto = new TempBatchDetailDTO
                {
                    BatchName = txtBname.Text.Trim(),
                    ProductName = txtproducts.Text.Trim(),
                    ProductId = selectedProductId,
                    Quantity = int.TryParse(txtquantity.Text.Trim(), out int q) ? q : 0,
                    CostPrice = decimal.TryParse(txtprice.Text.Trim(), out decimal c) ? c : 0,
                    SalePrice = decimal.TryParse(txtSprice.Text.Trim(), out decimal s) ? s : 0,
                    SerialNumbers = txtserailnumber.Items.Cast<string>().ToList()
                };

                BatchFormPersistence.Save(dto);
            }
        }
        private void txtproducts_TextChanged(object sender, EventArgs e)
        {
            if (!txtproducts.DroppedDown)
            {
                txtproducts.DroppedDown = true;
                txtproducts.SelectionStart = txtproducts.Text.Length;
                txtproducts.SelectionLength = 0;
            }
        }
        private void txtBname_TextChanged(object sender, EventArgs e)
        {
            if (!txtBname.DroppedDown)
            {
                txtBname.DroppedDown = true;
                txtBname.SelectionStart = txtBname.Text.Length;
                txtBname.SelectionLength = 0;
            }
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
                txtproducts.AutoCompleteMode=AutoCompleteMode.Suggest;
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
                txtBname.AutoCompleteMode=AutoCompleteMode.Suggest;
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
                bool isSerialized = checkBox1.Checked;

                if (isSerialized && txtserailnumber.Items.Count != quantity)
                {
                    MessageBox.Show("Serial number count must match the quantity.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Batchdetails batchDetails = new Batchdetails(0, 0, selectedProductId.Value, "", quantity, costPrice, batchname);

                var result = batchDetailsBL.AddBatchDetailsWithSerial(batchDetails, serialNumbers, salePrice,isSerialized);
                if (result)
                {
                    MessageBox.Show("Batch and serial numbers added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    BatchFormPersistence.Clear();
                    this.Close();

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

            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while adding: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                txtserailnumber.Items.Insert(0, serial); // ⬅ Add at top
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

        private void iconPictureBox2_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddBatchform>();
            f.ShowDialog(this);
            load();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bool isVisible = checkBox1.Checked;
            panel1.Visible = isVisible;

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void txtserailnumber_DoubleClick(object sender, EventArgs e)
        {
            if (txtserailnumber.SelectedItem != null)
            {
                string selected = txtserailnumber.SelectedItem.ToString();
                txtserialinput.Text = selected;
                txtserailnumber.Items.Remove(selected); // Remove so they can re-add after editing
            }
        }

        private void iconPictureBox3_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<addproductform>();
            f.ShowDialog(this);
            load();
        }

        private void txtBname_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
