using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Data;
using System.Drawing;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using TechStore.BL;
using TechStore.DL;
using TechStore.UI;

namespace TechStore
{
    public partial class CustomerBill_SpecificProducts : Form
    {
        private IconButton currentBtn;
        private readonly CustomerBill_SpecificProductsBL _billBL;
        private int _currentBillId;
        

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

        public CustomerBill_SpecificProducts(int billId)
        {
            InitializeComponent();
            _billBL = new CustomerBill_SpecificProductsBL();
            _currentBillId = billId;
            panelmenu.Visible = false;
            this.Load += CustomerBill_SpecificProducts_Load;
            btnBack.Click += BtnBack_Click;
        }

        private void CustomerBill_SpecificProducts_Load(object sender, EventArgs e)
        {
            activebutton(btnreport, sidebarColors[5]);
            LoadBillData();
            LoadPayments();
            StyleDataGridView();
        }
        private void LoadPayments()
        {
            var list = BillingRecordsOverviewDL.getrecord(_currentBillId);
            dataGridView1.DataSource = list;

            // Apply styles
            StylePaymentsGrid();

            // Hide internal columns if needed
            dataGridView1.Columns["name"].Visible = false;
            dataGridView1.Columns["suppid"].Visible = false;
            dataGridView1.Columns["bill_id"].Visible = false;
            dataGridView1.Columns["id"].Visible = false;
        }

        private void LoadBillData()
        {
            try
            {
                // Load bill summary
                DataTable billSummary = _billBL.GetBillSummary(_currentBillId);
                if (billSummary.Rows.Count > 0)
                {
                    DataRow row = billSummary.Rows[0];
                    lblCustomerName.Text = row["CustomerName"].ToString();

                    // Format amounts as PKR using BL method
                    lblTotalAmount.Text = _billBL.FormatCurrency(
                        Convert.ToDecimal(row["TotalAmount"]));
                    lblPaidAmount.Text = _billBL.FormatCurrency(
                        Convert.ToDecimal(row["PaidAmount"]));
                    lblPendingAmount.Text = _billBL.FormatCurrency(
                        Convert.ToDecimal(row["PendingAmount"]));
                }

                // Load bill details
                DataTable billDetails = _billBL.GetBillDetails(_currentBillId);
                dgvBillDetails.DataSource = billDetails;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bill data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void StyleDataGridView()
        {
            dgvBillDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBillDetails.RowHeadersVisible = false;
            dgvBillDetails.AllowUserToAddRows = false;
            dgvBillDetails.ReadOnly = true;
            dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBillDetails.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvBillDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvBillDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Format currency columns
            dgvBillDetails.CellFormatting += (sender, e) =>
            {
                if (e.Value == null) return;

                string[] currencyColumns = { "UnitPrice", "TotalPrice" };
                if (Array.Exists(currencyColumns, col => col == dgvBillDetails.Columns[e.ColumnIndex].Name))
                {
                    if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                    {
                        e.Value = _billBL.FormatCurrency(amount);
                        e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }
                }
            };
        }
        //private void StyleDataGridView()
        //{
        //    dgvBillDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvBillDetails.RowHeadersVisible = false;
        //    dgvBillDetails.AllowUserToAddRows = false;
        //    dgvBillDetails.ReadOnly = true;
        //    dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvBillDetails.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        //    dgvBillDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    dgvBillDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

        //    // Remove currency formatting from DataGridView since we're doing it in the DataTable
        //    // The values will already be formatted as strings with "Rs." prefix
        //}

        //private void StyleDataGridView()
        //{
        //    dgvBillDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvBillDetails.RowHeadersVisible = false;
        //    dgvBillDetails.AllowUserToAddRows = false;
        //    dgvBillDetails.ReadOnly = true;
        //    dgvBillDetails.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        //    dgvBillDetails.DefaultCellStyle.Font = new Font("Segoe UI", 10);
        //    dgvBillDetails.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //    dgvBillDetails.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

        //    // Format currency columns
        //    if (dgvBillDetails.Columns.Contains("UnitPrice"))
        //        dgvBillDetails.Columns["UnitPrice"].DefaultCellStyle.Format = "C";
        //    if (dgvBillDetails.Columns.Contains("TotalPrice"))
        //        dgvBillDetails.Columns["TotalPrice"].DefaultCellStyle.Format = "C";
        //}

        private void BtnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

        #region Navigation Methods
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

        private async Task FadeOutFormAsync(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                while (form.Opacity > 0)
                {
                    if (form.IsDisposed) return;
                    form.Opacity -= 0.05;
                    await Task.Delay(10);
                }
                form.Opacity = 0;
            }
            catch (ObjectDisposedException) { /* Safe exit */ }
        }

        private async Task FadeInFormAsync(Form form)
        {
            if (form == null || form.IsDisposed || !form.IsHandleCreated)
                return;

            try
            {
                while (form.Opacity < 1)
                {
                    if (form.IsDisposed) return;
                    form.Opacity += 0.05;
                    await Task.Delay(10);
                }
                form.Opacity = 1;
            }
            catch (ObjectDisposedException) { /* Safe exit */ }
        }
        private void StylePaymentsGrid()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView1.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView1.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(5, 51, 69);
            dataGridView1.EnableHeadersVisualStyles = false;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 126, 250);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        private void CustomerBill_SpecificProducts_Load_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}