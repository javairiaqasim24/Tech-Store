using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace TechStore
{
    public partial class SupplierBillDetails : Form
    {
        private int _supplierBillId;
        private int _supplierId;
        private string _supplierName;

        public SupplierBillDetails(int supplierBillId, int supplierId, string supplierName)
        {
            InitializeComponent();
            _supplierBillId = supplierBillId;
            _supplierId = supplierId;
            _supplierName = supplierName;
        }

        private void BillingRecordsOverview_Load_1(object sender, EventArgs e)
        {
            try
            {
                // Display supplier information
                lblSupplierName.Text = $"Supplier: {_supplierName}";

                // Load bill products
                LoadBillProducts();

                // Load payment history
                LoadPaymentHistory();

                // Calculate and display amounts
                CalculateAmounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bill details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBillProducts()
        {
            try
            {
                var products = SupplierBillDetailsBL.GetBillProducts(_supplierBillId);
                dgvBillProducts.DataSource = products;

                // Format columns if needed
                if (dgvBillProducts.Columns.Count > 0)
                {
                    dgvBillProducts.Columns[0].HeaderText = "Product ID";
                    dgvBillProducts.Columns[1].HeaderText = "Product Name";
                    dgvBillProducts.Columns[2].HeaderText = "Quantity";
                    // Add more column formatting as needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPaymentHistory()
        {
            try
            {
                var payments = SupplierBillDetailsBL.GetPaymentHistory(_supplierBillId);
                dgvPaymentHistory.DataSource = payments;

                // Format columns if needed
                if (dgvPaymentHistory.Columns.Count > 0)
                {
                    dgvPaymentHistory.Columns[0].HeaderText = "Date";
                    dgvPaymentHistory.Columns[1].HeaderText = "Amount";
                    dgvPaymentHistory.Columns[2].HeaderText = "Remarks";
                    // Add more column formatting as needed
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment history: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculateAmounts()
        {
            try
            {
                var billInfo = SupplierBillDetailsBL.GetBillAmounts(_supplierBillId);

                lblTotalAmount.Text = $"Total Amount: {billInfo.TotalAmount}";
                lblPaidAmount.Text = $"Paid Amount: {billInfo.PaidAmount}";
                lblPendingAmount.Text = $"Pending Amount: {billInfo.PendingAmount}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error calculating amounts: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            try
            {
                // Open add payment form
                //var addPaymentForm = new AddSupplierPayment(_supplierBillId, _supplierId);
                //addPaymentForm.ShowDialog();

                // Refresh data after payment is added
                LoadPaymentHistory();
                CalculateAmounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding payment: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvBillingRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell click if needed
        }
    }
}