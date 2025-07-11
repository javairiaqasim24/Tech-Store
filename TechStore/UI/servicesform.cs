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
        private string customerName;
        private string itemName;
        private string description;
        private string receivingDate;
        private string deliveryDate;

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
            //string type = combocustomer.SelectedItem?.ToString();
            string type = "Walk-in";

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
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.Title = "Save PDF Invoice";
                saveDialog.FileName = $"serviceInvoice_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        //invoices.CreateThermalReceiptPdf(dataGridVie  w1, saveDialog.FileName, txtcustomer.Text.Trim(), Convert.ToDecimal(finalpricetxt.Text), Convert.ToDecimal(txtfinalpaid.Text));
                        servicesinvoices.CreateServiceReceiptPdf(saveDialog.FileName, txtcustname.Text, txtnameofitem.Text, txtdescp.Text, recievingdate.Value, deliverydate.Value);

                        MessageBox.Show("PDF saved successfully!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating PDF:\n" + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            SavehthermalPdfInvoice();
        }
    }
}
