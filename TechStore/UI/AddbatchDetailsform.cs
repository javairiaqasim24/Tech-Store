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
using System.Xml.Linq;
using TechStore.BL.BL;
using TechStore.BL.Models;

namespace TechStore.UI
{
    public partial class AddbatchDetailsform : Form
    {
        private readonly  IBatchDetailsBL batchDetailsBL;
        public AddbatchDetailsform(IBatchDetailsBL batchDetailsBL)
        {
            InitializeComponent();
            this.batchDetailsBL = batchDetailsBL;
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string batchname = txtBname.Text.Trim();
            string productname = txtproducts.Text.Trim();
            int quantity = Convert.ToInt32( txtquantity.Text.Trim());
            decimal price = Convert.ToDecimal(txtprice.Text.Trim());
            try
            {
                Batchdetails b=new Batchdetails(0,0,0,productname, quantity, price, batchname);
                var result=batchDetailsBL.AddBatchDetails(b);
                if (result)
                {
                    MessageBox.Show("Batch added successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
                }
                else
                {
                    MessageBox.Show("Failed to add batch. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Database error occurred while adding batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show("Validation error: " + ex.Message, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while adding the batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void AddbatchDetailsform_Load(object sender, EventArgs e)
        {
            load();
        }
        private void load()
        {
            var supplierList = batchDetailsBL.GetProductNames("");
            if (supplierList != null && supplierList.Count > 0)
            {
                txtproducts.Items.Clear();
                txtproducts.Items.AddRange(supplierList.ToArray());

                // Set up autocomplete source
                AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(supplierList.ToArray());
                txtproducts.AutoCompleteCustomSource = autoSource;

                txtproducts.SelectedIndex = -1; // No pre-selection
            }
            else
            {
                MessageBox.Show("No suppliers found. Please add suppliers first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            var batch = batchDetailsBL.GetBatches("");
            if (batch != null && batch.Count > 0)
            {
                txtBname.Items.Clear();
                txtBname.Items.AddRange(batch.ToArray());

                // Set up autocomplete source
                AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
                autoSource.AddRange(batch.ToArray());
                txtBname.AutoCompleteCustomSource = autoSource;

                txtBname    .SelectedIndex = -1; // No pre-selection
            }
            else
            {
                MessageBox.Show("No suppliers found. Please add suppliers first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
