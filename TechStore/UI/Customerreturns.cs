using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.DAL;

namespace TechStore.UI
{
    public partial class Customerreturns : Form
    {
        public Customerreturns()
        {
            InitializeComponent();
            panelreturn.Visible = false;
            InitializeGrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void idsearchtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void InitializeGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Customer name",
                DataPropertyName = "CustomerName",
                Name = "CustomerName",
                Visible = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Product",
                DataPropertyName = "Product",
                Name = "Product",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "SKU",
                DataPropertyName = "sku",
                Name = "sku",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Qty Sold",
                DataPropertyName = "quantity",
                Name = "quantity",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Discount",
                DataPropertyName = "discount",
                Name = "discount",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Warranty",
                DataPropertyName = "warranty",
                Name = "warranty",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Warranty From",
                DataPropertyName = "warranty_from",
                Name = "warranty_from",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Warranty till",
                DataPropertyName = "warranty_till",
                Name = "warranty_till",
                ReadOnly = true
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Status",
                DataPropertyName = "status",
                Name = "status",
                ReadOnly = true
            });          

            // ✅ Make all columns fill available width
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btn_Click(object sender, EventArgs e)
        {
            if (int.TryParse(idsearchtxt.Text.Trim(), out int billId))
            {
                try
                {
                    InitializeGrid(); // Setup columns
                    DataTable billDetails = CustomerReturnDL.GetBillDetailsById(billId);
                    dataGridView1.DataSource = billDetails;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching bill data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid Bill ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

              

        private void panelreturn_Paint(object sender, PaintEventArgs e)
        {

        }       

        private void txtserialmanually_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtscamserial_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtproduct_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtquantity_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void txtreason_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtreturnedamount_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product row to return.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

            // Set values in the return panel
            txtproduct.Text = selectedRow.Cells["Product"].Value?.ToString();
            txtdescription.Text = selectedRow.Cells["sku"].Value?.ToString(); // SKU is used as Description for now
            txtquantity.Text = "";
            txtscamserial.Text = "";
            txtserialmanually.Text = "";
            txtreason.Text = "";
            txtreturnedamount.Text = "";

            // Optional: Store required data in Tag or variables for validation later
            panelreturn.Tag = new ReturnMetadata
            {
                ExpectedSKU = selectedRow.Cells["sku"].Value?.ToString(),
                MaxQuantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value)
            };

            panelreturn.Visible = true;
            txtscamserial.Focus();
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            var metadata = panelreturn.Tag as ReturnMetadata;
            if (metadata == null)
            {
                MessageBox.Show("Invalid return session.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 1. Quantity check
            if (!int.TryParse(txtquantity.Text.Trim(), out int returnQty) || returnQty <= 0)
            {
                MessageBox.Show("Enter a valid return quantity.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (returnQty > metadata.MaxQuantity)
            {
                MessageBox.Show("Return quantity exceeds sold quantity.", "Quantity Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Get combined serial input
            string enteredSerials = string.IsNullOrWhiteSpace(txtscamserial.Text)
                ? txtserialmanually.Text.Trim()
                : txtscamserial.Text.Trim();

            var enteredSerialList = enteredSerials
                .Split(',')
                .Select(s => s.Trim())
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .ToList();

            if (enteredSerialList.Count != returnQty)
            {
                MessageBox.Show($"You must enter exactly {returnQty} serial number(s).", "Serial Count Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Check for duplicates in entered serials
            if (enteredSerialList.Count != enteredSerialList.Distinct().Count())
            {
                MessageBox.Show("Duplicate serial numbers entered.", "Serial Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 4. Compare with expected SKUs
            var validSKUList = metadata.ExpectedSKU
                .Split(',')
                .Select(s => s.Trim())
                .ToList();

            var invalidSerials = enteredSerialList.Except(validSKUList).ToList();

            if (invalidSerials.Any())
            {
                MessageBox.Show("Some serial numbers are not part of the original sale:\n" + string.Join(", ", invalidSerials),
                    "Invalid Serials", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ All validation passed
            MessageBox.Show("Return validated successfully. Proceed with DB logic here.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            panelreturn.Visible = false;
            ClearReturnPanel();

        }

        private void ClearReturnPanel()
        {
            txtproduct.Text = "";
            txtdescription.Text = "";
            txtquantity.Text = "";
            txtscamserial.Text = "";
            txtserialmanually.Text = "";
            txtreason.Text = "";
            txtreturnedamount.Text = "";
            panelreturn.Tag = null;
        }

        private class ReturnMetadata
        {
            public string ExpectedSKU { get; set; }
            public int MaxQuantity { get; set; }
        }


        private void btncancle1_Click(object sender, EventArgs e)
        {
            panelreturn.Visible = false;
        }
    }
}
