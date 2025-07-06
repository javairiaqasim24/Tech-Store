using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

namespace TechStore
{
    public partial class SupplierBillingRecordsOverview : Form
    {
        public SupplierBillingRecordsOverview()
        {
            InitializeComponent();
            LoadSupplierBills();
        }

        private void BillingRecordsOverview_Load_1(object sender, EventArgs e)
        {
            LoadSupplierBills();
        }

        private void LoadSupplierBills(string searchTerm = "")
        {
            try
            {
                string query = @"
                    SELECT 
                        sb.supplier_Bill_ID,
                        s.name AS supplier_name,
                        sb.Date,
                        sb.total_price,
                        sb.paid_amount,
                        (sb.total_price - IFNULL(sb.paid_amount, 0)) AS pending_amount,
                        sb.payment_status
                    FROM supplierbills sb
                    JOIN suppliers s ON sb.supplier_id = s.supplier_id
                    WHERE s.name LIKE @searchTerm
                    ORDER BY sb.Date DESC";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@searchTerm", $"%{searchTerm}%")
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dgvSupplierBills.DataSource = dt;

                    // Add Details button column if it doesn't exist
                    if (!dgvSupplierBills.Columns.Contains("btnDetails"))
                    {
                        DataGridViewButtonColumn btnDetails = new DataGridViewButtonColumn();
                        btnDetails.Name = "btnDetails";
                        btnDetails.HeaderText = "Details";
                        btnDetails.Text = "View";
                        btnDetails.UseColumnTextForButtonValue = true;
                        dgvSupplierBills.Columns.Add(btnDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading supplier bills: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadSupplierBills(txtSearchSupplier.Text);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearchSupplier.Clear();
            LoadSupplierBills();
        }

        private void dgvBillingRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvSupplierBills.Columns["btnDetails"].Index && e.RowIndex >= 0)
            {
                // Get the bill ID and supplier information from the selected row
                int billId = Convert.ToInt32(dgvSupplierBills.Rows[e.RowIndex].Cells["supplier_Bill_ID"].Value);
                int supplierId = GetSupplierIdFromBill(billId);
                string supplierName = dgvSupplierBills.Rows[e.RowIndex].Cells["supplier_name"].Value.ToString();

                // Open the SupplierBillDetails form with the required parameters
                var billDetailsForm = new SupplierBillDetails(billId, supplierId, supplierName);
                billDetailsForm.ShowDialog();
            }
        }

        private int GetSupplierIdFromBill(int billId)
        {
            try
            {
                string query = "SELECT supplier_id FROM supplierbills WHERE supplier_Bill_ID = @billId";

                var parameters = new MySqlParameter[]
                {
            new MySqlParameter("@billId", billId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    if (reader.Read())
                    {
                        return Convert.ToInt32(reader["supplier_id"]);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting supplier ID: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return -1; // Return -1 if not found or error occurs
        }

        private void ShowBillDetails(int billId)
        {
            try
            {
                string query = @"
                    SELECT 
                        p.name AS product_name,
                        sbd.quantity,
                        (sbd.quantity * bd.cost_price) AS total_price
                    FROM supplier_bill_details sbd
                    JOIN products p ON sbd.product_id = p.product_id
                    JOIN batch_details bd ON bd.product_id = p.product_id
                    JOIN supplierbills sb ON sb.supplier_Bill_ID = sbd.supplier_Bill_ID
                    WHERE sbd.supplier_Bill_ID = @billId";

                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("@billId", billId)
                };

                using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    // Show details in a new form or message box
                    string details = $"Bill ID: {billId}\n\nProducts:\n";
                    foreach (DataRow row in dt.Rows)
                    {
                        details += $"{row["product_name"]} - Qty: {row["quantity"]} - Total: {row["total_price"]}\n";
                    }

                    MessageBox.Show(details, "Bill Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bill details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Navigation methods
        private void btndashboard_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btninventory_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btnrepair_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            // Navigation code
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            // Logout code
        }
    }
}