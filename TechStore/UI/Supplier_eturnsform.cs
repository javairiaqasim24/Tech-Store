using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Supplier_eturnsform : Form
    {
        private List<string> scannedSkus = new List<string>();
        private int requiredQuantity = 0;
        private int maxQuantityFromBill = 0;
        private bool isSerialized = true;
        private int scannedCount = 0;

        private List<Supplierreturn> supplierReturnList = new List<Supplierreturn>();
        private int selectedBillDetailId = -1;
        private readonly IsreturnBl ibl;
        private int selectedProductId = -1;

        public Supplier_eturnsform(IsreturnBl ibl)
        {
            InitializeComponent();
            this.ibl = ibl;
            panelreturn.Visible = false;
            UIHelper.StyleGridView(dataGridView1);
            listBox1.DoubleClick += txtserailnumber_DoubleClick;

            txtreturnedamount.Enabled = false;
            btnsave1.Enabled = false;
            txtscamserial.Enabled = false;
            btnadd.Enabled = false;
            btnSkip.Enabled = false;
            txtreturnqty.Enabled = false;
        }

        private void Supplier_eturnsform_Load(object sender, EventArgs e) { }

        private void button9_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(idsearchtxt.Text.Trim(), out int billId))
            {
                MessageBox.Show("Please enter a valid Bill ID.");
                return;
            }

            var billDetails = ibl.GetBillDetailsByBillId(billId);
            if (billDetails == null || billDetails.Count == 0)
            {
                MessageBox.Show("No bill details found.");
                return;
            }

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("BillDetailId", "Bill Detail ID");
            dataGridView1.Columns.Add("ProductId", "Product ID");
            dataGridView1.Columns.Add("ProductName", "Product Name");
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            //dataGridView1.Columns.Add("Sku", "sku");
            dataGridView1.Columns["ProductId"].Visible = false;

            foreach (var item in billDetails)
            {
                dataGridView1.Rows.Add(item.bill_detail_id, item.p.id, item.p.name, item.p.description, item.quantity, item.sku);
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a bill detail row.");
                return;
            }

            var row = dataGridView1.SelectedRows[0];

            if (!int.TryParse(row.Cells["BillDetailId"].Value?.ToString(), out selectedBillDetailId) ||
                !int.TryParse(row.Cells["ProductId"].Value?.ToString(), out selectedProductId))
            {
                MessageBox.Show("Invalid row data.");
                return;
            }

            txtproduct.Text = row.Cells["ProductName"].Value.ToString();
            txtdescription.Text = row.Cells["Description"].Value.ToString();

            if (!int.TryParse(row.Cells["Quantity"].Value.ToString(), out maxQuantityFromBill))
            {
                MessageBox.Show("Invalid quantity.");
                return;
            }

            string sampleSku = SreturnsDl.GetSampleSkuForProduct(selectedProductId);
            isSerialized = !string.IsNullOrEmpty(sampleSku);

            scannedSkus.Clear();
            scannedCount = 0;
            listBox1.Items.Clear();
            supplierReturnList.Clear();

            txtreturnedamount.Clear();
            txtscamserial.Clear();
            txtreturnqty.Clear();

            txtreturnedamount.Enabled = false;
            btnsave1.Enabled = false;
            txtscamserial.Enabled = false;
            btnadd.Enabled = false;
            btnSkip.Enabled = false;
            txtreturnqty.Enabled = true;

            cbActionTaken.SelectedIndex = 0;
            UIHelper.ShowCenteredPanel(this, panelreturn);
            UIHelper.RoundPanelCorners(panelreturn, 20);


            if (!isSerialized)
            {
                MessageBox.Show("This product is not serialized. You can use skip.");
            }
        }

        private void btnConfirmQty_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtreturnqty.Text.Trim(), out requiredQuantity) || requiredQuantity <= 0)
            {
                MessageBox.Show("Please enter a valid return quantity.");
                return;
            }

            if (requiredQuantity > maxQuantityFromBill)
            {
                MessageBox.Show("Return quantity cannot exceed quantity from bill.");
                return;
            }

            scannedCount = 0;
            supplierReturnList.Clear();
            listBox1.Items.Clear();
            txtscamserial.Enabled = true;
            btnadd.Enabled = true;
            btnSkip.Enabled = true;
            txtreturnqty.Enabled = false;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (scannedCount >= requiredQuantity)
            {
                MessageBox.Show("All SKUs already scanned.");
                return;
            }

            string sku = txtscamserial.Text.Trim();
            string actionTaken = cbActionTaken.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(actionTaken))
            {
                MessageBox.Show("Please select an action.");
                return;
            }

            if (selectedBillDetailId == -1 || selectedProductId == -1)
            {
                MessageBox.Show("Select a product row first.");
                return;
            }

            Products product = null;

            if (!string.IsNullOrWhiteSpace(sku))
            {
                product = ibl.GetProductBySku(sku);
                if (product == null)
                {
                    MessageBox.Show("Invalid SKU.");
                    return;
                }

                if (product.id != selectedProductId)
                {
                    MessageBox.Show("Scanned SKU does not match selected product.");
                    return;
                }

                txtproduct.Text = product.name;
                txtdescription.Text = product.description;
            }
            else
            {
                if (isSerialized)
                {
                    MessageBox.Show("You must scan a SKU for serialized product.");
                    return;
                }

                product = new Products(selectedProductId, txtproduct.Text.Trim(), txtdescription.Text.Trim());
            }

            string displaySku = string.IsNullOrWhiteSpace(sku) ? "No-SKU | " + product.name : sku;
            listBox1.Items.Add(displaySku);
            txtscamserial.Clear();

            var returnObj = new Supplierreturn(
                bill_detail_id: selectedBillDetailId,
                return_date: dateTimePicker1.Value,
                action_taken: actionTaken,
                sku: string.IsNullOrWhiteSpace(sku) ? null : sku,
                name: product.name,
                description: product.description,
                amount: 0,
                quantity: 1,
                id: product.id
            );

            supplierReturnList.Add(returnObj);
            scannedCount++;

            if (scannedCount == requiredQuantity)
            {
                txtreturnedamount.Enabled = true;
                btnsave1.Enabled = true;
            }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            string actionTaken = cbActionTaken.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(actionTaken))
            {
                MessageBox.Show("Please select an action.");
                return;
            }

            if (requiredQuantity <= 0)
            {
                MessageBox.Show("Please confirm return quantity first.");
                return;
            }

            // Confirm if skipping SKUs for serialized product
            if (isSerialized)
            {
                var result = MessageBox.Show(
                    "This product has serial numbers. Are you sure you want to skip scanning and continue without them?",
                    "Skip Serial Numbers?",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result != DialogResult.Yes)
                    return;
            }

            // Add only one record with total quantity
            var returnObj = new Supplierreturn(
                bill_detail_id: selectedBillDetailId,
                return_date: dateTimePicker1.Value,
                action_taken: actionTaken,
                sku: null,
                name: txtproduct.Text,
                description: txtdescription.Text,
                amount: 0,
                quantity: requiredQuantity,
                id: selectedProductId
            );

            supplierReturnList.Clear(); // Clear previous items if any
            supplierReturnList.Add(returnObj);

            listBox1.Items.Clear();
            listBox1.Items.Add($"No-SKU | {txtproduct.Text} | Qty: {requiredQuantity}");

            scannedCount = requiredQuantity;
            txtreturnedamount.Enabled = true;
            btnsave1.Enabled = true;

            // Disable further input
            btnadd.Enabled = false;
            btnSkip.Enabled = false;
            txtscamserial.Enabled = false;
            txtreturnqty.Enabled = false;
        }



        private void btnsave1_Click(object sender, EventArgs e)
        {
            if (supplierReturnList.Count == 0)
            {
                MessageBox.Show("No returns to save.");
                return;
            }

            decimal amount = 0;
            string actionTaken = cbActionTaken.SelectedItem?.ToString();

            if (actionTaken.ToLower() == "refunded")
            {
                if (string.IsNullOrWhiteSpace(txtreturnedamount.Text) ||
                    !decimal.TryParse(txtreturnedamount.Text.Trim(), out amount))
                {
                    MessageBox.Show("Please enter a valid refund amount.");
                    return;
                }

                foreach (var r in supplierReturnList)
                {
                    r.amount = amount;
                }
            }
            try {
                var success = ibl.AddSupplierReturns(supplierReturnList);
                if (success)
                {
                    MessageBox.Show("Returns processed successfully.");
                    supplierReturnList.Clear();
                    listBox1.Items.Clear();
                    txtreturnedamount.Clear();
                    txtscamserial.Clear();
                    txtproduct.Clear();
                    txtdescription.Clear();
                    txtreturnqty.Clear();
                    txtreturnedamount.Enabled = false;
                    txtreturnqty.Enabled = false;
                    panelreturn.Visible = false;
                }
                else
                {
                    MessageBox.Show("Failed to process returns.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Sku Already returned: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error returning product: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     

        private void btncancle1_Click(object sender, EventArgs e)
        {
            panelreturn.Visible=false;
        }
        private void txtserailnumber_DoubleClick(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                string selected = listBox1.SelectedItem.ToString();
                txtscamserial.Text = selected;
                listBox1.Items.Remove(selected); // Remove so they can re-add after editing
            }
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
