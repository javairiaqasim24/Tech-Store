using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIMS;
using Microsoft.Extensions.DependencyInjection;
using Mysqlx.Crud;
using TechStore.BL;
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.DL;
using static TechStore.BL.Models.ServicesInvo;

namespace TechStore.UI
{
    public partial class Services : Form
    {
        private List<servicedevices> serviceDevices = new List<servicedevices>();
        private readonly ICustomer_serviceBl ibl;

        public Services(ICustomer_serviceBl ibl)
        {
            InitializeComponent();
           
            this.ibl = ibl;
            ConfigureGrid();
            loadcustomers();
        }

        private void LoadProductData()
        {
         

        }
        private void loadcustomers()
        {
            cmbCustomer.Items.Clear();
            var customers = DatabaseHelper.Instance.getAllCustomers();

            cmbCustomer.Items.AddRange(customers.ToArray());
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cmbCustomer.SelectedItem == null)
            {
                MessageBox.Show("Please select a customer.");
                return;
            }

            if (serviceDevices.Count == 0)
            {
                MessageBox.Show("Please add at least one device.");
                return;
            }

            var receipt = new customerservicerecipt
            {
                CustomerName = cmbCustomer.SelectedItem.ToString(),
                Remarks = txtremarks. Text.Trim(),
                Devices = serviceDevices
            };

            try
            {
                bool result =ibl.savereceipt (receipt);
                if (result)
                {
                    MessageBox.Show("Service receipt saved successfully.");
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to save receipt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving receipt: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtproductname.Clear();
            txtDescription.Clear();
            txtremarks.Clear();
            cmbCustomer.SelectedIndex = -1;
            serviceDevices.Clear();
            dataGridView2.Rows.Clear();
        }
        private void ConfigureGrid()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Add("DeviceName", "Device Name");
            dataGridView2.Columns.Add("Issue", "Issue");
            dataGridView2.Columns.Add("ExpectedDate", "Expected Return Date");
            dataGridView2.AutoSizeColumnsMode=DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ConfigureInvoiceGrid()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter both product name and issue.");
                return;
            }

            var device = new servicedevices
            {
                DeviceName = txtproductname.Text.Trim(),
                Issue = txtDescription.Text.Trim(),
                ReportDate = DateTime.Now,
                ExpectedDate = guna2DateTimePicker1.Value,
                Status = "Pending",
                ServiceCharge = 0
            };

            serviceDevices.Add(device);

            dataGridView2.Rows.Add(device.DeviceName, device.Issue, device.ExpectedDate.ToShortDateString());

            txtproductname.Clear();
            txtDescription.Clear();
        }


        private void ClearItemInputs()
        {
            txtproductname.Clear();
            txtDescription.Clear();
          
        }

        private void UpdateTotal()
        {
          
        }

        private void SetupSearchGrid()
        {
           
        }

        private void DgvProductSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void txtproductname_TextChanged(object sender, EventArgs e)
        {
         
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void Services_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<Customerform>();
            f.ShowDialog(this);
        }
    }
}
