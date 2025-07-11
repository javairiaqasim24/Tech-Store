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
    public partial class Inventoryform : Form
    {
        private readonly IInventoryBl ibl;
        private int selectedProductId;
        public Inventoryform(IInventoryBl ibl)

        {
            InitializeComponent();
            this.ibl = ibl;
            paneledit.Visible = false;
            UIHelper.ApplyButtonStyles(dataGridView2);
            UIHelper.StyleGridView(dataGridView2);

        }
        private void load()
        {
            var list = ibl.getinventory();
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list.Select(e => new { e.ProductName, e.description, e.SalePrice, e.Stock, e.InventoryId, e.ProductId }).ToList();
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.Columns["ProductId"].Visible = false;
            dataGridView2.Columns["inventoryId"].Visible = false;

            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text=textBox1.Text;
            if (string.IsNullOrEmpty(text))
            {


                load();
            }
            var list = ibl.getAllinventory(text);
            dataGridView2.Columns.Clear();
            dataGridView2.DataSource = list;
            UIHelper.AddButtonColumn(dataGridView2, "Edit", "Edit", "Edit");
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            decimal price= Convert.ToDecimal(txtsale.Text);
            int quantity=Convert.ToInt32(txtstock.Text);
            try
            {
                var inventory = new Inventory(selectedProductId, price, quantity, 0, "","");
                bool result = ibl.update(inventory);
                if (result)
                {
                    MessageBox.Show("Inventory Updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtname1.Clear();
                    txtsale.Clear();
                    txtstock.Clear();
                    load();
                   }
                else
                {
                    MessageBox.Show("Failed to Update Inventory. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("An error occurred while updating batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        

        private void iconButton1_Click(object sender, EventArgs e)
        {
            paneledit.Visible = false;
        }

        private void Inventoryform_Load(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            var row = dataGridView2.Rows[e.RowIndex];
            selectedProductId = Convert.ToInt32(row.Cells["InventoryId"].Value);
            string columnName = dataGridView2.Columns[e.ColumnIndex].Name;

            if (columnName == "Edit")
            {
                txtname1.Text = row.Cells["ProductName"].Value?.ToString() ?? "";
                txtstock.Text = row.Cells["Stock"].Value?.ToString() ?? "";
                txtsale.Text = row.Cells["SalePrice"].Value?.ToString() ?? "";

                UIHelper.RoundPanelCorners(paneledit, 20);
                UIHelper.ShowCenteredPanel(this, paneledit);
            }
           
            }
        }
    }
