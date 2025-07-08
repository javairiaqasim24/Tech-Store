using KIMS;
using Microsoft.Extensions.DependencyInjection;
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

namespace TechStore.UI
{
    public partial class BatchDetailsform : Form
    {
        private readonly IBatchDetailsBL ibl;
        private readonly ISupplierBillBl ibr;
        private int selectedBatchDetailId = -1;

        public BatchDetailsform(IBatchDetailsBL ibl,ISupplierBillBl ibr)
        {
            InitializeComponent();
            paneledit.Visible = false;
            panelbill.Visible = false;
            this.ibl = ibl;
            this.ibr = ibr;
            UIHelper.ApplyButtonStyles(dataGridView2);
            UIHelper.StyleGridView(dataGridView2);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f=Program.ServiceProvider.GetRequiredService<AddbatchDetailsform>();
            f.ShowDialog(this);
        }
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var grid = dataGridView2;
                var selectedRow = grid.Rows[e.RowIndex];

                // Edit button
                if (grid.Columns[e.ColumnIndex].Name == "Edit")
                {
                    selectedBatchDetailId = Convert.ToInt32(selectedRow.Cells["batch_details_id"].Value);
                    txtBname.Text = selectedRow.Cells["batch_name"].Value.ToString();
                    txtproducts.Text = selectedRow.Cells["product_name"].Value.ToString();
                    txtquantity.Text = selectedRow.Cells["quantity"].Value.ToString();
                    txtprice.Text = selectedRow.Cells["price"].Value.ToString();
                    paneledit.Visible = true;
                    UIHelper.RoundPanelCorners(paneledit,20);
                    UIHelper.ShowCenteredPanel(this,paneledit);

                }
                // Delete button
                else if (grid.Columns[e.ColumnIndex].Name == "Delete")
                {
                    int batchDetailId = Convert.ToInt32(selectedRow.Cells["batch_details_id"].Value);
                    var confirm = MessageBox.Show("Are you sure you want to delete this batch detail?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (confirm == DialogResult.Yes)
                    {
                        var success = ibl.DeleteBatchDetails(batchDetailId);
                        if (success)
                        {
                            MessageBox.Show("Deleted successfully.");
                            load();
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete.");
                        }
                    }
                }
            }
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            if (selectedBatchDetailId <= 0)
            {
                MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string batchName = txtBname.Text.Trim();
            string productName = txtproducts.Text.Trim();
            if (!int.TryParse(txtquantity.Text.Trim(), out int quantity) || quantity < 0)
            {
                MessageBox.Show("Enter valid quantity.");
                return;
            }
            if (!decimal.TryParse(txtprice.Text.Trim(), out decimal price) || price < 0)
            {
                MessageBox.Show("Enter valid price.");
                return;
            }

            var updated = new Batchdetails(selectedBatchDetailId, 0, 0, productName, quantity, price, batchName);

            try
            {
                if (ibl.UpdateBatchDetails(updated))
                {
                    MessageBox.Show("Batch detail updated successfully.");
                    paneledit.Visible = false;
                    selectedBatchDetailId = -1;
                    load();
                }
                else
                {
                    MessageBox.Show("Update failed.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while Updating: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void iconButton1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;
        }

        private void BatchDetailsform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var list = ibl.GetBatchDetails();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["batch_details_id"].Visible=false;
            dataGridView2.Columns["batch_id"].Visible = false;

            dataGridView2.Columns["product_id"].Visible = false;
            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", 
                  
                "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");

            // Load products
            var productNames = ibl.GetProductNames("");
            txtproducts.Items.Clear();
            txtproducts.Items.AddRange(productNames.ToArray());
            txtproducts.SelectedIndex = -1;

            // Load batches
            var batchNames = ibl.GetBatches("");
            txtBname.Items.Clear();
            txtBname.Items.AddRange(batchNames.ToArray());
            txtBname.SelectedIndex = -1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
          string text= textBox1.Text;
            if (string.IsNullOrEmpty(text)) {


                load();
            }
            var list=ibl.GetBatchDetailsByName(text);
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;
            dataGridView2.Columns["batch_details_id"].Visible = false;
            dataGridView2.Columns["batch_id"].Visible = false;

            dataGridView2.Columns["product_id"].Visible = false;
            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
            UIHelper.AddButtonColumn(dataGridView2, "Delete", "Delete", "Delete");

        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            string batchName = textBox2.Text.Trim(); // Textbox where batch name is shown
            if (string.IsNullOrEmpty(batchName))
            {
                MessageBox.Show("Batch name is required.");
                return;
            }
            string supplier = txtSupplierName.Text.Trim();
            if (string.IsNullOrEmpty(supplier))
            {
                MessageBox.Show("Supplier Name is requires");
                return;
            }

            if (!decimal.TryParse(txtPaid.Text.Trim(), out decimal paidAmount) || paidAmount < 0)
            {
                MessageBox.Show("Enter a valid paid amount.");
                return;
            }

            decimal total = Convert.ToInt32(txtTotal.Text.Trim());
            try
            {
                Supplierbill s = new Supplierbill(batchName, paidAmount, supplier, total);
                bool success = ibr.updateamount(s);

                if (success)
                {
                    MessageBox.Show("Bill updated successfully.");
                    panelbill.Visible = false;
                    load(); // refresh datagridview
                }
                else
                {
                    MessageBox.Show("Update failed. Please try again.");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while generating bill: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Please select a row first.");
                return;
            }

            string batchName = dataGridView2.CurrentRow.Cells["batch_name"].Value.ToString();

            // Get bill info by batch name
            var billData = ibr.getbills(batchName); // Make sure this doesn't return null

            if (billData != null)
            {
                if (billData.total_price != 0 && billData.paid_price != 0)
                {
                    MessageBox.Show("Bill already generated. Go to Supplier Bills to add payment.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Fill the form if bill is editable
                txtSupplierName.Text = billData.supplier_name;
                textBox2.Text = billData.batch_name;
                txtTotal.Text = billData.total_price.ToString("0.00");
                txtDate.Text = billData.date.ToShortDateString();
                txtPaid.Text = billData.paid_price.ToString("0.00");

                txtSupplierName.ReadOnly = false;
                textBox2.ReadOnly = false;
                txtTotal.ReadOnly = false;
                txtPaid.ReadOnly = false;

                panelbill.Visible = true;
                UIHelper.RoundPanelCorners(panelbill, 20);
                UIHelper.ShowCenteredPanel(this, panelbill);
            }
            else
            {
                MessageBox.Show("No bill found for selected batch.");
            }
        }


        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panelbill.Visible = false;
        }
    }
}
