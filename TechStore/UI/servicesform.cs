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
    public partial class servicesform : Form
    {
        private DataGridView dgvCustomerSearch = new DataGridView();

        public servicesform()
        {
            InitializeComponent();
            SetupCustomerGrid();
        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtcustname_TextChanged(object sender, EventArgs e)
        {
            //if (combocustomer.Text == "")
            //{
            //    MessageBox.Show("Please enter the customer type first.");
            //    return;
            //}
            string keyword = txtcustname.Text.Trim();
            string type = combocustomer.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(keyword) || string.IsNullOrWhiteSpace(type))
            {
                dgvCustomerSearch.Visible = false;
                return;
            }

            DataTable customers = Customersaledl.GetCustomersByType(type); // ✅ Use your DL method

            dgvCustomerSearch.Rows.Clear();
            foreach (DataRow row in customers.Rows)
            {
                if (row["name"].ToString().ToLower().Contains(keyword.ToLower()))
                {
                    dgvCustomerSearch.Rows.Add(row["name"], row["address"]);
                }
            }

            dgvCustomerSearch.Visible = dgvCustomerSearch.Rows.Count > 0;
        }

        private void SetupCustomerGrid()
        {
            dgvCustomerSearch.Visible = false;
            dgvCustomerSearch.ReadOnly = true;
            dgvCustomerSearch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomerSearch.AllowUserToAddRows = false;
            dgvCustomerSearch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomerSearch.Columns.Add("name", "Customer Name");
            dgvCustomerSearch.Columns.Add("address", "Address");

            this.Controls.Add(dgvCustomerSearch);
            dgvCustomerSearch.Location = new Point(txtcustname.Left, txtcustname.Top - dgvCustomerSearch.Height + 80);
            dgvCustomerSearch.Size = new Size(txtcustname.Width * 2, 150);
            dgvCustomerSearch.BringToFront();

            dgvCustomerSearch.CellClick += DgvCustomerSearch_CellClick;
        }

        private void DgvCustomerSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtcustname.Text = dgvCustomerSearch.Rows[e.RowIndex].Cells["name"].Value.ToString();
                dgvCustomerSearch.Visible = false;
            }
        }


        private void txtnameofitem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtdescp_TextChanged(object sender, EventArgs e)
        {

        }

        private void recievingdate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void deliverydate_ValueChanged(object sender, EventArgs e)
        {

        }
        private void SavehthermalPdfInvoice()
        {
            string customerName = txtcustname.Text.Trim();
            string item = txtnameofitem.Text.Trim();
            string desc = txtdescp.Text.Trim();
            DateTime recDate = recievingdate.Value;
            DateTime delivDate = deliverydate.Value;

            int? customerId = servicesDL.GetCustomerIdByName(customerName);
            if (customerId == null)
            {
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                int serviceId = servicesinvoices.InsertServiceAndReturnId(customerId.Value, item, desc, recDate, delivDate);

                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                    saveDialog.Title = "Save Service Receipt PDF";
                    saveDialog.FileName = $"serviceReceipt_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        servicesinvoices.CreateServiceReceiptPdf(
                            saveDialog.FileName,
                            customerName,
                            item,
                            desc,
                            recDate,
                            delivDate,
                            serviceId // pass service ID as string
                        );

                        MessageBox.Show("Service saved and receipt generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save service entry:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            SaveServiceData();
            SavehthermalPdfInvoice();
            cleartextboxes();
        }

        private void SaveServiceData()
        {
            string customerName = txtcustname.Text.Trim();
            string item = txtnameofitem.Text.Trim();
            string desc = txtdescp.Text.Trim();
            DateTime recDate = recievingdate.Value;
            DateTime delivDate = deliverydate.Value;

            int? customerId = servicesDL.GetCustomerIdByName(customerName);
            if (customerId == null)
            {
                MessageBox.Show("Customer not found. Please select a valid customer.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool inserted = servicesDL.InsertService(customerId.Value, item, desc, recDate, delivDate);
            if (inserted)
            {
                MessageBox.Show("Service entry saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Failed to save service entry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cleartextboxes()
        {
            txtcustname.Text = "";
            txtnameofitem.Text = "";
            txtdescp.Text = "";


        }

    }
}
