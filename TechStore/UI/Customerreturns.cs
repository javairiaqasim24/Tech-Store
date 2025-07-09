using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.DL;

namespace TechStore.UI
{
    public partial class Customerreturns : Form
    {
        private int _currentBillId;

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
                HeaderText = "SKU",
                DataPropertyName = "SerialNumbers",   // Keep this as the column name from SQL
                Name = "serial_number",
                Visible = true // 👈 hides it from the user
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
                HeaderText = "Descripton",
                DataPropertyName = "description",
                Name = "description",
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
                    InitializeGrid(); // Always initialize before setting data

                    DataTable billDetails = CustomerReturnDL.GetBillDetailsById(billId);

                    if (billDetails == null || billDetails.Rows.Count == 0)
                    {
                        MessageBox.Show($"No records found for Bill ID: {billId}.", "No Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView1.DataSource = null;
                        _currentBillId = 0; // Reset if not found
                        return;
                    }

                    _currentBillId = billId;  // ✅ Save bill ID for later use
                    dataGridView1.DataSource = billDetails;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching bill data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid numeric Bill ID.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtdescription.Text = selectedRow.Cells["description"].Value?.ToString();
            txtquantity.Text = "";
            txtscamserial.Text = "";
            //txtserialmanually.Text = "";
            txtreason.Text = "";
            txtreturnedamount.Text = "";

            // Optional: Store required data in Tag or variables for validation later
            panelreturn.Tag = new ReturnMetadata
            {
                ExpectedSKU = selectedRow.Cells["serial_number"].Value?.ToString() ?? "",
                MaxQuantity = Convert.ToInt32(selectedRow.Cells["quantity"].Value),

                BillId = _currentBillId,  // ✅ Use class-level variable                                          // 💥 This was missing
                ProductId = CustomerReturnDL.GetProductIdByName(selectedRow.Cells["Product"].Value?.ToString()) // You must fetch this too
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

            // Only using scanned serials now
            string scannedSerial = txtscamserial.Text.Trim();

            string[] enteredSkus = Array.Empty<string>();

            if (metadata.HasSerials)
            {
                if (string.IsNullOrWhiteSpace(scannedSerial))
                {
                    MessageBox.Show("Please scan at least one serial number.", "Missing Serial", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                enteredSkus = scannedSerial.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                           .Select(s => s.Trim())
                                           .ToArray();

                string[] expectedSkus = metadata.ExpectedSKU.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                                                            .Select(s => s.Trim())
                                                            .ToArray();

                if (enteredSkus.Any(sku => !expectedSkus.Contains(sku)))
                {
                    MessageBox.Show("One or more entered serial numbers do not match the original sale.", "Serial Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }


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

            if (metadata.HasSerials && enteredSkus.Length != returnQty)
            {
                MessageBox.Show("Number of entered serials must match the return quantity.", "Serial Count Mismatch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            int? returnedAmount = null;
            if (!string.IsNullOrWhiteSpace(txtreturnedamount.Text) &&
                int.TryParse(txtreturnedamount.Text.Trim(), out int amt))
            {
                returnedAmount = amt;
            }

            string productName = txtproduct.Text.Trim();
            string productDesc = txtdescription.Text.Trim();

            int? productId = CustomerReturnDL.GetProductId(productName, productDesc);

            if (!productId.HasValue)
            {
                MessageBox.Show("Product ID not found. Cannot save return.", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int billDetailId;

            if (metadata.HasSerials)
            {
                billDetailId = CustomerReturnDL.GetBillDetailId(metadata.BillId, productId.Value, enteredSkus[0]);
            }
            else
            {
                billDetailId = CustomerReturnDL.GetBillDetailIdForNonSerial(metadata.BillId, productId.Value); // implement this new method
            }


            try
            {
                CustomerReturnDL.SaveReturnToDatabase(
                productId.Value,
                billDetailId,
                DateTime.Now.Date,
                txtreason.Text.Trim(),
                returnQty,
                cbActionTaken.SelectedItem?.ToString() ?? "Refunded",
                returnedAmount,
                string.Join(",", enteredSkus)
                );


                MessageBox.Show("Return saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                panelreturn.Visible = false;
                ClearReturnPanel();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save return: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void ClearReturnPanel()
        {
            txtproduct.Text = "";
            txtdescription.Text = "";
            txtquantity.Text = "";
            txtscamserial.Text = "";
            //txtserialmanually.Text = "";
            txtreason.Text = "";
            txtreturnedamount.Text = "";
            panelreturn.Tag = null;
        }

        public class ReturnMetadata
        {
            public int BillId { get; set; }
            public int ProductId { get; set; }
            public string ExpectedSKU { get; set; } // can be empty if no SKU
            public int MaxQuantity { get; set; }
            public bool HasSerials => !string.IsNullOrWhiteSpace(ExpectedSKU);
        }




        private void btncancle1_Click(object sender, EventArgs e)
        {
            panelreturn.Visible = false;
        }

        private void Customerreturns_Load(object sender, EventArgs e)
        {

        }
    }
}
