using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Drawing;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TechStore.BL;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.UI;

namespace TechStore
{
    public partial class BillingRecordsOverview : Form
    {
        private IconButton currentBtn;
        private readonly BillingRecordsOverviewBL _billingBL;

        private readonly Color[] sidebarColors = new Color[]
        {
            Color.FromArgb(0, 126, 250),   // Tech Blue
            Color.FromArgb(0, 207, 255),   // Sky Cyan
            Color.FromArgb(26, 188, 156),  // Lime Mint
            Color.FromArgb(255, 140, 66),  // Coral Orange
            Color.FromArgb(155, 89, 182),  // Soft Purple
            Color.FromArgb(46, 204, 113),  // Leaf Green
            Color.FromArgb(231, 76, 60)    // Rose Red
        };

        public BillingRecordsOverview()
        {
            InitializeComponent();
            _billingBL = new BillingRecordsOverviewBL();
            this.Load += BillingRecordsOverview_Load;
            panelmenu.Visible= false;
            paneledit.Visible= false;
        }

        private void BillingRecordsOverview_Load(object sender, EventArgs e)
        {
            activebutton(btnreport, sidebarColors[5]);
            LoadBillingRecords();
            StyleDataGridViews();
        }

        private void LoadBillingRecords(string searchTerm = "")
        {
            try
            {
                DataTable dt = _billingBL.GetBillingRecords(searchTerm);
                dgvBillingRecords.DataSource = dt;

                if (dt.Rows.Count > 0)
                {
                    dgvBillingRecords.ClearSelection();
                    AddDetailsButtonColumn();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading billing records: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddDetailsButtonColumn()
        {
            if (dgvBillingRecords.Columns.Contains("btnDetails"))
                dgvBillingRecords.Columns.Remove("btnDetails");
            if (dgvBillingRecords.Columns.Contains("btnPayment"))
                dgvBillingRecords.Columns.Remove("btnPayment");

            // View Details Button
            var btnDetails = new DataGridViewButtonColumn
            {
                Name = "btnDetails",
                Text = "View Details",
                UseColumnTextForButtonValue = true,
                HeaderText = "Actions",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(0, 126, 250),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }
            };

            // Payment Button
            var btnPayment = new DataGridViewButtonColumn
            {
                Name = "btnPayment",
                Text = "Payment",
                UseColumnTextForButtonValue = true,
                HeaderText = "",
                FlatStyle = FlatStyle.Flat,
                Width = 100,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    BackColor = Color.FromArgb(46, 204, 113),
                    ForeColor = Color.White,
                    Font = new Font("Segoe UI", 9, FontStyle.Bold)
                }
            };

            dgvBillingRecords.Columns.Add(btnDetails);
            dgvBillingRecords.Columns.Add(btnPayment);
        }


        private void dgvBillingRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    var clickedColumn = dgvBillingRecords.Columns[e.ColumnIndex];

                    if (clickedColumn.Name == "btnDetails")
                    {
                        var billIdCell = dgvBillingRecords.Rows[e.RowIndex].Cells["BillID"];
                        if (billIdCell.Value != null && int.TryParse(billIdCell.Value.ToString(), out int billId))
                            OpenBillDetailsForm(billId);
                    }
                    else if (clickedColumn.Name == "btnPayment")
                    {
                        var row = dgvBillingRecords.Rows[e.RowIndex];

                        // Fetch values
                        txtname1.Text = row.Cells["CustomerName"].Value?.ToString();
                        txtbill.Text = row.Cells["BillID"].Value?.ToString();
                        txtamount.Text = row.Cells["DueAmount"].Value?.ToString();
                        txtpayment.Clear();
                        txtremarks.Clear();
                        txtdate.Text = DateTime.Now.ToString();

                        paneledit.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OpenBillDetailsForm(int billId)
        {
            try
            {
                var billDetailsForm = new CustomerBill_SpecificProducts(billId);
                billDetailsForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening bill details: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadBillingRecords(txtSearch.Text);
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadBillingRecords();
        }

        private void StyleDataGridViews()
        {
            // Basic DataGridView styling
            dgvBillingRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillingRecords.RowHeadersVisible = false;
            dgvBillingRecords.AllowUserToAddRows = false;
            dgvBillingRecords.ReadOnly = true;
            dgvBillingRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillingRecords.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvBillingRecords.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBillingRecords.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Set column specific styles
            if (dgvBillingRecords.Columns.Contains("SaleDate"))
            {
                dgvBillingRecords.Columns["SaleDate"].DefaultCellStyle.Format = "dd-MM-yyyy hh:mm tt";
            }

            // Cell formatting handler
            dgvBillingRecords.CellFormatting += (sender, e) =>
            {
                if (e.Value == null || e.Value == DBNull.Value) return;

                // Format payment status column
                if (e.ColumnIndex == dgvBillingRecords.Columns["payment_status"].Index)
                {
                    if (e.Value.ToString() == "Due")
                    {
                        e.CellStyle.ForeColor = Color.Red;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    }
                    else
                    {
                        e.CellStyle.ForeColor = Color.Green;
                    }
                }

                // Format currency columns (PKR)
                string[] currencyColumns = { "TotalAmount", "PaidAmount", "DueAmount" };
                if (Array.Exists(currencyColumns, col => col == dgvBillingRecords.Columns[e.ColumnIndex].Name))
                {
                    try
                    {
                        decimal amount = 0;

                        // Handle different numeric types that might come from database
                        if (e.Value is int intValue)
                            amount = Convert.ToDecimal(intValue);
                        else if (e.Value is decimal decimalValue)
                            amount = decimalValue;
                        else
                            decimal.TryParse(e.Value.ToString(), out amount);

                        e.Value = $"Rs. {amount:N2}";
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                    catch
                    {
                        // Fallback in case of parsing error
                        e.Value = "Rs. 0.00";
                    }
                }

                // Right-align numeric columns
                if (e.Value is int || e.Value is decimal)
                {
                    e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }
            };

            // Handle column header tooltips
            dgvBillingRecords.CellToolTipTextNeeded += (sender, e) =>
            {
                if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
                {
                    string[] currencyColumns = { "TotalAmount", "PaidAmount", "DueAmount" };
                    if (Array.Exists(currencyColumns, col => col == dgvBillingRecords.Columns[e.ColumnIndex].Name))
                    {
                        e.ToolTipText = "Amount in Pakistani Rupees (PKR)";
                    }
                }
            };
        }
        #region Navigation Methods
        private void activebutton(object senderbtn, Color color)
        {
            disablebutton();
            currentBtn = (IconButton)senderbtn;
            currentBtn.BackColor = Color.FromArgb(5, 51, 69);
            currentBtn.ForeColor = color;
            currentBtn.TextAlign = ContentAlignment.MiddleCenter;
            currentBtn.IconColor = color;
            currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
            currentBtn.ImageAlign = ContentAlignment.MiddleRight;
        }

        private void disablebutton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.Transparent;
                currentBtn.ForeColor = Color.White;
                currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                currentBtn.IconColor = Color.White;
                currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
            }
        }

        private void btndashboard_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[0]);
            var f = Program.ServiceProvider.GetRequiredService<Dashboard>();
            f.Show();
            this.Close();
        }

        private void btninventory_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[1]);
            var f = Program.ServiceProvider.GetRequiredService<productsform>();
            f.Show();
            this.Close();
        }

        private void btnsales_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[4]);
            //var f = Program.ServiceProvider.GetRequiredService<Sales>();
            //f.Show();
            this.Close();
        }

        private void btnrepair_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[6]);
            //var f = Program.ServiceProvider.GetRequiredService<Repairform>();
            //f.Show();
            this.Close();
        }

        private void btncustomers_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[2]);
            var f = Program.ServiceProvider.GetRequiredService<Customerform>();
            f.Show();
            this.Close();
        }

        private void btnsupplier_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[3]);
            var f = Program.ServiceProvider.GetRequiredService<Supplierform>();
            f.Show();
            this.Close();
        }

        private void btnreport_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[5]);
            //var f = Program.ServiceProvider.GetRequiredService<Reportform>();
            //f.Show();
            this.Close();
        }

        private void btnlogout_Click(object sender, EventArgs e)
        {
            activebutton(sender, sidebarColors[6]);
            if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //var login = Program.ServiceProvider.GetRequiredService<Login>();
                this.Hide();
                //login.Show();
            }
        }
        #endregion

        private void BillingRecordsOverview_Load_1(object sender, EventArgs e)
        {

        }

        private void btnsave1_Click(object sender, EventArgs e)
        {
            // Validate payment input
            if (!decimal.TryParse(txtpayment.Text, out decimal payment) || payment <= 0)
            {
                MessageBox.Show("Enter a valid payment amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Extract other fields
            string customerName = txtname1.Text.Trim();
            if (!int.TryParse(txtbill.Text, out int billId))
            {
                MessageBox.Show("Invalid Bill ID.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string remarks = txtremarks.Text.Trim();

            if (!DateTime.TryParse(txtdate.Text, out DateTime date))
            {
                MessageBox.Show("Enter a valid date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Create record object
                var record = new Customerrecord
                (0,
                    customerName,
                                        payment,
                    date,

                    billId,
                    remarks
                );

                // Call DL method
                bool result = BillingRecordsOverviewDL.AddRecord(record);

                if (result)
                {
                    MessageBox.Show("Payment recorded successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBillingRecords(); // Reload updated data
                }
                else
                {
                    MessageBox.Show("Failed to record payment.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payment: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void dgvBillingRecords_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Addpayment_Click(object sender, EventArgs e)
        {

        }

        private void btncancle1_Click(object sender, EventArgs e)
        {
            paneledit.Visible=false;
        }
    }
}