using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
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
        private int printReceiptId;
        private decimal printTotalAmount;
        private decimal printPaidAmount;
        private List<(string deviceName, decimal serviceCharge, decimal laborCharge)> printDevices;

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
            paneledit.Visible = false;
            this.idl = idl;
            printDocument1.PrintPage += printDocument1_PrintPage;

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

            decimal unitPrice = DatabaseHelper.Instance.getsaleprice(selectedproductid);
            if (unitPrice == -1)
            {
                MessageBox.Show("Sale price not found for selected product.");
                return;
            }

            // Default calculated price
            decimal calculatedTotal = unitPrice * qty;

            // Try to parse user's custom price from txtprice
            decimal finalPrice;
            if (!string.IsNullOrWhiteSpace(txtprice.Text) && decimal.TryParse(txtprice.Text, out decimal userPrice))
            {
                finalPrice = userPrice;
            }
            else
            {
                finalPrice = calculatedTotal;
                txtprice.Text = finalPrice.ToString("0.##"); // show it
            }

            var part = new service_parts
            {
                device_id = SelectedDeviceId,
                product_id = selectedproductid,
                product_name = txtproduct.Text,
                quantity = qty,
                price = finalPrice
            };

            addedParts.Add(part);
            dataGridView1.Rows.Add(part.product_name, qty, finalPrice); // or show unitPrice separately if needed
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
            try
            {
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
        private void LoadBillDataForPrinting(int receiptId)
        {
            printReceiptId = receiptId;
            printDevices = new List<(string, decimal, decimal)>();

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = @"
            SELECT device_name, service_charge, labor_charge
            FROM service_devices
            WHERE receipt_id = @receiptId";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receiptId", receiptId);
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string name = reader.GetString("device_name");
                            decimal service = reader.GetDecimal("service_charge");
                            decimal labor = reader.GetDecimal("labor_charge");
                            printDevices.Add((name, service, labor));
                        }
                    }
                }

                // Get total and paid amount
                string totalQuery = @"
            SELECT COALESCE(SUM(service_charge + labor_charge), 0)
            FROM service_devices
            WHERE receipt_id = @receiptId";

                using (var totalCmd = new MySqlCommand(totalQuery, conn))
                {
                    totalCmd.Parameters.AddWithValue("@receiptId", receiptId);
                    printTotalAmount = Convert.ToDecimal(totalCmd.ExecuteScalar());
                }

                string paidQuery = @"
            SELECT amount_paid
            FROM service_receipts
            WHERE receipt_id = @receiptId";

                using (var paidCmd = new MySqlCommand(paidQuery, conn))
                {
                    paidCmd.Parameters.AddWithValue("@receiptId", receiptId);
                    object result = paidCmd.ExecuteScalar();
                    printPaidAmount = result != null ? Convert.ToDecimal(result) : 0;
                }
            }
        }
        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font titleFont = new Font("Arial", 16, FontStyle.Bold);
            Font headerFont = new Font("Arial", 11, FontStyle.Bold);
            Font bodyFont = new Font("Arial", 10);
            Brush brush = Brushes.Black;
            float x = 50;
            float y = 50;

            // Header
            e.Graphics.DrawString("TECH STORE", titleFont, brush, x + 250, y);
            y += 30;
            e.Graphics.DrawString("123 Market Road, Lahore", bodyFont, brush, x + 250, y);
            y += 20;
            e.Graphics.DrawString("Phone: +92-300-1234567", bodyFont, brush, x + 250, y);
            y += 20;
            e.Graphics.DrawString("Email: support@techstore.com", bodyFont, brush, x + 250, y);
            y += 30;

            e.Graphics.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 20;

            // Receipt Info
            e.Graphics.DrawString($"Receipt ID: {printReceiptId}", headerFont, brush, x, y);
            y += 25;

            // Table Header
            e.Graphics.DrawString("Device Name", headerFont, brush, x, y);
            e.Graphics.DrawString("Service Charge", headerFont, brush, x + 250, y);
            e.Graphics.DrawString("Labor Charge", headerFont, brush, x + 450, y);
            y += 20;

            e.Graphics.DrawLine(Pens.Gray, x, y, e.PageBounds.Width - x, y);
            y += 10;

            // Devices
            foreach (var d in printDevices)
            {
                e.Graphics.DrawString(d.deviceName, bodyFont, brush, x, y);
                e.Graphics.DrawString(d.serviceCharge.ToString("0.00"), bodyFont, brush, x + 250, y);
                e.Graphics.DrawString(d.laborCharge.ToString("0.00"), bodyFont, brush, x + 450, y);
                y += 25;

                if (y > e.PageBounds.Height - 100)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            y += 20;
            e.Graphics.DrawLine(Pens.Black, x, y, e.PageBounds.Width - x, y);
            y += 15;

            // Totals
            e.Graphics.DrawString($"Total Amount: Rs. {printTotalAmount:0.00}", headerFont, brush, x, y);
            y += 25;
            e.Graphics.DrawString($"Paid Amount: Rs. {printPaidAmount:0.00}", headerFont, brush, x, y);
            y += 30;

            // Footer
            e.Graphics.DrawString("Thank you for choosing Tech Store!", bodyFont, brush, x + 150, y);

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
            string input = textBox1.Text.Trim();
            if (!int.TryParse(input, out int receiptId))
            {
                MessageBox.Show("Invalid receipt ID.");
                return;
            }

            try
            {
                decimal totalAmount = CalculateTotalBill(receiptId);

                if (totalAmount == 0)
                {
                    MessageBox.Show("No service or labor charges found for this receipt ID.");
                    return;
                }

                // ✅ Check if bill already generated
                if (IsBillAlreadyFinalized(receiptId))
                {
                    MessageBox.Show("Bill has already been finalized for this receipt.");
                    return;
                }

                txtid.Text = receiptId.ToString();
                txttotal.Text = totalAmount.ToString("0.00");
                txtpayment.Clear();

                paneledit.Visible = true;
                paneledit.BringToFront();
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

            decimal totalAmount;
            if (!decimal.TryParse(txttotal.Text, out totalAmount))
            {
                MessageBox.Show("Total amount is invalid.");
                return;
            }

            if (paidAmount < totalAmount)
            {
                MessageBox.Show("Paid amount cannot be less than the total bill amount.");
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
        private bool IsBillAlreadyFinalized(int receiptId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                string query = "SELECT amount_paid FROM service_receipts WHERE receipt_id = @receiptId LIMIT 1";

                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@receiptId", receiptId);
                    object result = cmd.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal paidAmount = Convert.ToDecimal(result);
                        return paidAmount > 0;
                    }
                }
            }
            return false;
        }

        private void iconButton1_Click_1(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtqty_TextChanged(object sender, EventArgs e)
        {
            if (selectedproductid == -1)
                return;

            if (int.TryParse(txtqty.Text, out int qty) && qty > 0)
            {
                decimal price = DatabaseHelper.Instance.getsaleprice(selectedproductid);
                if (price != -1)
                {
                    decimal total = price * qty;
                    txtprice.Text = total.ToString("0.##");
                }
            }
            else
            {
                txtprice.Clear();
            }
        }

        private void paneledit_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton3_Click(object sender, EventArgs e)
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

            if (!decimal.TryParse(txttotal.Text.Trim(), out decimal totalAmount))
            {
                MessageBox.Show("Total amount is invalid.");
                return;
            }

            if (paidAmount < totalAmount)
            {
                MessageBox.Show("Paid amount cannot be less than total bill.");
                return;
            }

            bool isAlreadyFinalized = IsBillAlreadyFinalized(receiptId);

            if (!isAlreadyFinalized)
            {
                if (!ibl.FinalizeReceipt(receiptId, paidAmount, out string message))
                {
                    MessageBox.Show("Failed to save bill: " + message);
                    return;
                }
                MessageBox.Show("Bill saved and now printing...");
            }
            else
            {
                MessageBox.Show("Bill already finalized. Printing only...");
            }

            // Load data and print
            LoadBillDataForPrinting(receiptId);
            printDocument1.Print();

            // Clear UI
            paneledit.Visible = false;
            txtid.Clear();
            txttotal.Clear();
            txtpayment.Clear();
        }

        private void printDocument1_PrintPage_1(object sender, PrintPageEventArgs e)
        {

        }
    }
}