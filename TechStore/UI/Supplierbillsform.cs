﻿using MySql.Data.MySqlClient;
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
using TechStore.Interfaces;

namespace TechStore.UI
{
    public partial class Supplierbillsform : Form
    {
        private readonly ISupplierBillBl ibl;
        private readonly IsbilldetailsBl idl;
        public Supplierbillsform(ISupplierBillBl ibl,IsbilldetailsBl idl)
        {
            InitializeComponent();
            this.ibl = ibl;
            this.idl = idl;
            paneledit.Visible = false;
            UIHelper.StyleGridView(dataGridView2);

        }

        private void Supplierbillsform_Load(object sender, EventArgs e)
        {
            load();
        }

        private void load()
        {
            var list = ibl.getbill();

            // Filter out bills where total_price == 0
            var filteredList = list.Where(b => b.total_price != 0.00m).ToList();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = filteredList;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.Columns["supplier_id"].Visible = false;
            dataGridView2.Columns["batch_id"].Visible = false;

            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");
        }





        private void pictureBox10_Click(object sender, EventArgs e)
        {
            load();
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {
                load();
                return;
            }

            var list = ibl.getbillbyname(text);

            // Filter out bills where total_price == 0
            var filteredList = list.Where(b => b.total_price != 0.00m).ToList();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = filteredList;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["supplier_id"].Visible = false;
            dataGridView2.Columns["batch_id"].Visible = false;
            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int bill_id = Convert.ToInt32(textBox1.Text);
            var list = ibl.getbills(bill_id);

            // Filter out bills where total_price == 0
            var filteredList = list.Where(b => b.total_price != 0.00m).ToList();

            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = filteredList;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dataGridView2.Columns["supplier_id"].Visible = false;
            dataGridView2.Columns["batch_id"].Visible = false;

            UIHelper.AddButtonColumn(dataGridView2, "Details", "View Details", "Details");
            UIHelper.AddButtonColumn(dataGridView2, "Addpay", "Add payment", "payement");
            UIHelper.ApplyButtonStyles(dataGridView2);
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView2.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

                if (columnName == "Details")
                {
                    var selectedBill = dataGridView2.Rows[e.RowIndex].DataBoundItem as Supplierbill;

                    if (selectedBill != null)
                    {
                        // Open new form and pass selected bill ID
                        var detailsForm = new Sbilldetailform(selectedBill.bill_id);
                        detailsForm.ShowDialog();
                    }
                }
                if (columnName == "Addpay")
                {
                    var selectedBill = dataGridView2.Rows[e.RowIndex].DataBoundItem as Supplierbill;

                    if (selectedBill != null)
                    {
                        // Assign data to panel textboxes (ensure these exist on your form)
                        txtname1.Text = selectedBill.supplier_name;
                        txtamount.Text = selectedBill.pending.ToString("0.00");
                        txtbill.Text = selectedBill.bill_id.ToString();
                        txtdate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                        // Show the panel centered
                        UIHelper.RoundPanelCorners(paneledit, 20);
                        UIHelper.ShowCenteredPanel(this, paneledit);
                    }
                }

            }
        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            try
            {
                string supplierName = txtname1.Text.Trim();
                int billId = Convert.ToInt32(txtbill.Text.Trim());
                decimal payment = Convert.ToDecimal(txtpayment.Text.Trim());
                string remarks = txtremarks.Text.Trim();
                DateTime date = Convert.ToDateTime(txtdate.Text.Trim());

                // Optional input validation
                if (string.IsNullOrWhiteSpace(supplierName) || string.IsNullOrWhiteSpace(remarks))
                {
                    MessageBox.Show("Supplier name and remarks are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var record = new Spricerecord(0, supplierName, payment, date, billId, remarks);
                    bool success=idl.addrecord(record);
                if (success)
                {
                    MessageBox.Show("Payment saved successfully.");
                    paneledit.Visible = false;
                    load(); // Refresh main grid
                }
                else
                {
                    MessageBox.Show("Payment not saved.");
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

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }
    }
}
