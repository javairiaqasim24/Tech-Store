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

        }

        private void Batchesform_Load(object sender, EventArgs e)
        {
            load();

        }
        private void load()
        {
            var list = ibl.getbatches();
            dataGridView2.DataSource = list;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["batch_id"].Visible = false;
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

            // Get batch_name from the selected row
            string batchName = dataGridView2.CurrentRow.Cells["batch_name"].Value.ToString();

            // Get bill info by batch name
            var billData = ibr.getbills(batchName); // implement this method in BL/DL

            if (billData != null)
            {
                txtSupplierName.Text = billData.supplier_name;
                textBox2.Text = billData.batch_name;
                txtTotal.Text = billData.total_price.ToString("0.00");
                txtDate.Text = billData.date.ToShortDateString();

                // Optional: set textBox3 (paid amount) if needed
                textBox3.Text = billData.paid_price.ToString("0.00");

                // If both total and paid are non-zero, make textboxes readonly
                bool makeReadOnly = billData.total_price != 0 && billData.paid_price != 0;

                txtSupplierName.ReadOnly = makeReadOnly;
                textBox2.ReadOnly = makeReadOnly;
                txtTotal.ReadOnly = makeReadOnly;
                //txtDate.ReadOnly = makeReadOnly;
                textBox3.ReadOnly = makeReadOnly;

                // Optional: disable the update button if you want to block editing completely
                iconButton5.Enabled = !makeReadOnly;

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
    }
}
