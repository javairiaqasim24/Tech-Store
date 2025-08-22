using Microsoft.Extensions.DependencyInjection;
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
    public partial class Batchesform : Form
    {
        private readonly IBatchesBl ibl;
        private readonly ISupplierBillBl ibr;
        public Batchesform(IBatchesBl ibl, ISupplierBillBl ibr)
        {
            InitializeComponent();
            panelbill.Visible = false;
            this.ibl = ibl;
            this.ibr = ibr;
            UIHelper.StyleGridView(dataGridView2);
            this.KeyPreview = true;
            this.KeyDown += Batchesform_KeyDown;

        }
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                if (dataGridView2.Rows.Count > 0)
                    dataGridView2.Focus();
            }
        }

        private void Batchesform_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.F) // Ctrl + F = focus search
            {
                textBox1.Focus();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Enter && dataGridView2.Focused) // Select row
            {
                iconButton8.PerformClick(); // Open bill panel
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.Escape && panelbill.Visible) // ESC to close panel
            {
                iconButton4.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.Control && e.KeyCode == Keys.S && panelbill.Visible) // Ctrl + S to Save
            {
                iconButton5.PerformClick();
                e.SuppressKeyPress = true;
            }
            else if (e.KeyCode == Keys.F2) // F2 = open Add Batch form
            {
                btnadd.PerformClick();
                e.SuppressKeyPress = true;
            }
        }

        private void Batchesform_Load(object sender, EventArgs e)
        {
            load();
            dataGridView2.Focus();

        }
        private void OpenBatchDetailsForm()
        {
            if (dataGridView2.CurrentRow != null)
            {
                var batchName = dataGridView2.CurrentRow.Cells["batch_name"].Value?.ToString();

                if (!string.IsNullOrEmpty(batchName))
                {
                    var form = Program.ServiceProvider.GetRequiredService<AddbatchDetailsform>();
                    form.InitialBatchName = batchName; // ✅ Inject batch name via property
                    form.ShowDialog(this);
                }
                else
                {
                    MessageBox.Show("No batch name found in selected row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private void load()
        {
            var list = ibl.getbatches();
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["batch_id"].Visible = false;
            UIHelper.AddButtonColumn(dataGridView2, "Details", "Details", "Details");

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddBatchform>();
            f.ShowDialog(this);
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
                textBox3.Text = billData.paid_price.ToString("0.00");

                txtSupplierName.ReadOnly = false;
                textBox2.ReadOnly = false;
                txtTotal.ReadOnly = false;
                textBox3.ReadOnly = false;

                panelbill.Visible = true;
                UIHelper.RoundPanelCorners(panelbill, 20);
                UIHelper.ShowCenteredPanel(this, panelbill);
            }
            else
            {
                MessageBox.Show("No bill found for selected batch.");
            }
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            panelbill.Visible = false;
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

           
            decimal total= Convert.ToDecimal( txtTotal.Text.Trim());
            decimal payment = Convert.ToDecimal(textBox3.Text.Trim());
            try
            {
                Supplierbill s = new Supplierbill(batchName,payment, supplier,total);
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
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text= textBox1.Text.Trim();
            if (string.IsNullOrEmpty(text))
            {
                load();
            }
            var list=ibl.getbatchesbyname(text);
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["batch_id"].Visible = false;
            UIHelper.AddButtonColumn(dataGridView2, "Details", "Details", "Details");

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            OpenBatchDetailsForm();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            var columnName = dataGridView2.Columns[e.ColumnIndex].Name;
            var row = dataGridView2.Rows[e.RowIndex];
            if (columnName == "Details")
            {
                var selectedBatch = dataGridView2.Rows[e.RowIndex].DataBoundItem as Batches;
                if (selectedBatch != null)
                {
                    var detailsForm = Program.ServiceProvider.GetRequiredService<BatchDetailsform>();
                    detailsForm.BatchId= selectedBatch.batch_id; // <-- Inject batch ID
                    detailsForm.ShowDialog(this);
                }
            }
        }
    }
}
