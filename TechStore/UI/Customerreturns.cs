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

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                HeaderText = "Return Qty",
                Name = "ReturnQty",
                ValueType = typeof(int)
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
    }
}
