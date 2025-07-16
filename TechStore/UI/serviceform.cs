using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;

namespace TechStore.UI
{
    public partial class serviceform : Form
    {
        private List<service_parts> addedParts = new List<service_parts>();
        private readonly IServicePartBl ibl;
        private readonly IInventoryBl idl;
        private int SelectedDeviceId = -1;
        private int selectedproductid = -1;
        public serviceform(IServicePartBl ibl,IInventoryBl idl)
        {
            InitializeComponent();
            this.ibl = ibl;
            UIHelper.StyleGridView(dataGridView2);
            UIHelper.StyleGridView(dataGridView1);
            panelreturn.Visible = false;
            dataGridView2.CellClick += dataGridView2_CellClick;
            dgvproducts.Visible = false;
            dgvproducts.CellClick += dgvproducts_CellClick;
            //txtproduct.TextChanged += txtproduct_TextChanged;
            paneledit.Visible = false;
            this.idl = idl;
        }

        private void serviceform_Load(object sender, EventArgs e)
        {
            InitializeProductGrid();
        }



        private void button9_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int receiptId))
            {
                MessageBox.Show("Enter valid receipt ID.");
                return;
            }

            dataGridView2.DataSource = ibl.SearchDevices(receiptId);
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SelectedDeviceId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells["DeviceId"].Value);
                txtdevicename.Text = dataGridView2.Rows[e.RowIndex].Cells["DeviceName"].Value.ToString();
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (SelectedDeviceId == -1)
            {
                MessageBox.Show("Please select a device from the list.");
                return;
            }

            panelreturn.Visible = true;
            ClearInputs();
            txtdevicename.Text = dataGridView2.CurrentRow?.Cells["DeviceName"].Value?.ToString();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproduct.Text))
            {
                MessageBox.Show("Please select a product from search list.");
                return;
            }

            if (!int.TryParse(txtqty.Text, out int qty) || qty <= 0)
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            if (!decimal.TryParse(txtprice.Text, out decimal price) || price < 0)
            {
                MessageBox.Show("Invalid price.");
                return;
            }

            var part = new service_parts
            {
                device_id = SelectedDeviceId,
                product_id=selectedproductid,
                product_name=txtproduct.Text,
                quantity = qty,
                price = price
            };

            addedParts.Add(part);
            dataGridView1.Rows.Add(part.product_name, qty, price);
            ClearPartInputs();
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            if (SelectedDeviceId == -1)
            {
                MessageBox.Show("No device selected.");
                return;
            }
            if (selectedproductid == -1) {
                MessageBox.Show("No product  selected.");
            }
            if (!decimal.TryParse(txtlabor.Text, out decimal laborCharge))
            {
                MessageBox.Show("Invalid labor charge.");
                return;
            }

            if (addedParts.Count == 0)
            {
                MessageBox.Show("No parts added.");
                return;
            }

            bool success = ibl.AddPartsAndUpdateCharges(addedParts, laborCharge, out string message);
            if (success)
            {
                MessageBox.Show("Parts saved and charges updated.");
                panelreturn.Visible = false;
                addedParts.Clear();
                dataGridView1.Rows.Clear();
                ClearInputs();
            }
            else
            {
                MessageBox.Show("Failed: " + message);
            }
        }

        private void txtproduct_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtproduct.Text.Trim();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvproducts.Visible = false;
                return;
            }

            try
            {
                var products = idl.getAllinventory(keyword);
                foreach (var item in products)
                {
                    Console.WriteLine(string.Join(", ", item.GetType().GetProperties().Select(p => p.Name)));
                    break; // Only print once
                }


                if (products == null || products.Count == 0)
                {
                    dgvproducts.Visible = false;
                    return;
                }

                dgvproducts.Visible = true;
                dgvproducts.BringToFront();

                // Set up columns manually to ensure names
                dgvproducts.AutoGenerateColumns = true;
                dgvproducts.Columns.Clear();

                //dgvproducts.Columns.Add(new DataGridViewTextBoxColumn
                //{
                //    Name = "ProductId",
                //    HeaderText = "Product ID",
                //    DataPropertyName = "ProductId"
                //});

                //dgvproducts.Columns.Add(new DataGridViewTextBoxColumn
                //{
                //    Name = "ProductName",
                //    HeaderText = "Product Name",
                //    DataPropertyName = "ProductName"
                //});

                //dgvproducts.Columns.Add(new DataGridViewTextBoxColumn
                //{
                //    Name = "Description",
                //    HeaderText = "Description",
                //    DataPropertyName = "Description"
                //});

                //dgvproducts.Columns.Add(new DataGridViewTextBoxColumn
                //{
                //    Name = "SalePrice",
                //    HeaderText = "Sale Price",
                //    DataPropertyName = "SalePrice"
                //});

                //dgvproducts.Columns.Add(new DataGridViewTextBoxColumn
                //{
                //    Name = "Stock",
                //    HeaderText = "Stock",
                //    DataPropertyName = "Stock"
                //});

                dgvproducts.DataSource = products;
                dgvproducts.Columns["ProductId"].Visible = false;
                dgvproducts.Columns["InventoryId"].Visible=false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Search error: " + ex.Message);
            }
        }


        private void InitializeProductGrid()
        {
            dataGridView1.Columns.Clear(); // in case it's reloaded

            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Price", "Price");
        }


        private void dgvproducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
                var selectedInventory = dgvproducts.Rows[e.RowIndex].DataBoundItem as Inventory;
                if (selectedInventory == null)
                {
                    MessageBox.Show("Could not read selected product.");
                    return;
                }

                selectedproductid = selectedInventory.ProductId;
                txtproduct.Text = selectedInventory.ProductName;

                dgvproducts.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error selecting product: " + ex.Message);
            }
        }


        private void btncancle1_Click(object sender, EventArgs e)
        {
            panelreturn.Visible = false;
            addedParts.Clear();
            dataGridView1.Rows.Clear();
            ClearInputs();
        }

        private void ClearInputs()
        {
            txtproduct.Clear();
            txtproduct.Tag = null;
            txtqty.Clear();
            txtprice.Clear();
            txtlabor.Clear();
            txtdevicename.Clear();
            dgvproducts.Visible = false;
        }

        private void ClearPartInputs()
        {
            txtproduct.Clear();
            txtproduct.Tag = null;
            txtqty.Clear();
            txtprice.Clear();
            dgvproducts.Visible = false;
        }

        private void dgvproducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private decimal CalculateTotalBill(int receiptId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT COALESCE(SUM(service_charge + labor_charge), 0)
            FROM service_devices
            WHERE receipt_id = @receipt_id";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receipt_id", receiptId);
                    return Convert.ToDecimal(cmd.ExecuteScalar());
                }
            }
        }

        private void btnbill_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text.Trim(), out int receiptId))
            {
                MessageBox.Show("Please enter a valid receipt ID.");
                return;
            }

            try
            {
                // Manually calculate total from service_devices using your existing DL logic
                decimal totalAmount = CalculateTotalBill(receiptId); // helper method below

                // Fill form fields
                txtid.Text = receiptId.ToString();
                txttotal.Text = totalAmount.ToString("0.00");
                txtpayment.Clear();

                paneledit.Visible = true;
                txtpayment.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bill data: " + ex.Message);
            }
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtid.Text, out int receiptId))
            {
                MessageBox.Show("Invalid receipt ID.");
                return;
            }

            if (!decimal.TryParse(txtpayment.Text.Trim(), out decimal paidAmount) || paidAmount < 0)
            {
                MessageBox.Show("Invalid paid amount.");
                return;
            }

            if (ibl.FinalizeReceipt(receiptId, paidAmount, out string message))
            {
                MessageBox.Show("Bill finalized successfully.");
                paneledit.Visible = false;
                txtid.Clear();
                txttotal.Clear();
                txtpayment.Clear();
            }
            else
            {
                MessageBox.Show("Failed: " + message);
            }
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}