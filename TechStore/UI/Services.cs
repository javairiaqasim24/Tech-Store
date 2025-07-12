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
using Mysqlx.Crud;
using TechStore.BL.BL;
using TechStore.DL;
using static TechStore.BL.Models.ServicesInvo;

namespace TechStore.UI
{
    public partial class Services : Form
    {
        private ServiceInvoice currentInvoice = new ServiceInvoice();
        ServiceDL ser=new ServiceDL();
        int invoiceId;
        private DataGridView dgvProductSearch;
        private DataTable allProducts;
        public Services()
        {
            InitializeComponent();
            cmbCustomer.DropDownStyle = ComboBoxStyle.DropDown;
            ConfigureInvoiceGrid();
            LoadProductData();
            SetupSearchGrid();
            dgvInvoice.AllowUserToAddRows = false;
            cmbCustomer.DataSource = ser.GetCustomers();
            cmbCustomer.DisplayMember = "name";
            cmbCustomer.ValueMember = "first_name"; 
            cmbCustomer.SelectedIndex = -1;

        }

        private void LoadProductData()
        {
            allProducts = ser.GetProducts();

        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            currentInvoice.CustomerName = cmbCustomer.Text;
            currentInvoice.ServiceName = Service.Text;
            currentInvoice.InvoiceDate = dtpDate.Value;

            
            invoiceId = ser.SaveInvoice(currentInvoice);

            MessageBox.Show($"Invoice #{invoiceId} saved successfully.");
        }

        private void ConfigureInvoiceGrid()
        {
            dgvInvoice.Columns.Clear();

            dgvInvoice.Columns.Add("Name", "Product Name");
            dgvInvoice.Columns.Add("Description", "Description");
            dgvInvoice.Columns.Add("Quantity", "Quantity");
            dgvInvoice.Columns.Add("CostPrice", "CostPrice");
            dgvInvoice.Columns.Add("Total", "Total");

            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                MessageBox.Show("Please fill in product name and quantity.");
                return;
            }

            if (!int.TryParse(txtQuantity.Text.Trim(), out int quantity))
            {
                MessageBox.Show("Quantity should be in digits only.", "Invalid Quantity", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantity.Focus();
                return;
            }

            if (!int.TryParse(txtCostprice.Text.Trim(), out int costPrice))
            {
                MessageBox.Show("Cost Price should be a valid number.");
                txtCostprice.Focus();
                return;
            }

            // 🟩 Create item
            var item = new ServiceInvoiceItem
            {
                InvoiceId = invoiceId,
                ProductId = 0, // optional
                Description = txtDescription.Text,
                Quantity = quantity,
                CostPrice = costPrice

            };

            // 🟩 Insert into DB
            
            ser.InsertInvoiceItems(new List<ServiceInvoiceItem> { item });

            // 🟩 Show in DataGridView
            dgvInvoice.Rows.Add(
                txtproductname.Text,
                item.Description,
                item.Quantity,
                item.CostPrice,
                item.TotalPrice  // ← this uses your computed property
            );

            // 🟩 Clear
            ClearItemInputs();
            UpdateTotal();
            txtproductname.Focus();
        }

        private void ClearItemInputs()
        {
            txtproductname.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
            txtCostprice.Clear();
        }

        private void UpdateTotal()
        {
            decimal total = currentInvoice.Items.Sum(i => i.TotalPrice);
            txtTotal.Text = $"Rs. {total:N2}";
        }

        private void SetupSearchGrid()
        {
            dgvProductSearch = new DataGridView
            {
                Location = new Point(txtproductname.Left, txtproductname.Bottom + 5),
                Width = txtproductname.Width + 100,
                Height = 180,
                Visible = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AllowUserToAddRows = false,
                MultiSelect = false,
                BackgroundColor = SystemColors.Window,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                BorderStyle = BorderStyle.Fixed3D
            };

            dgvProductSearch.Columns.Add("Name", "Product Name");
            dgvProductSearch.Columns.Add("Description", "Description");
            dgvProductSearch.Columns.Add("CostPrice", "CostPrice");

            dgvProductSearch.CellClick += DgvProductSearch_CellClick;
            this.Controls.Add(dgvProductSearch);
        }

        private void DgvProductSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = dgvProductSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string desc = dgvProductSearch.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                string cost = dgvProductSearch.Rows[e.RowIndex].Cells["CostPrice"].Value.ToString();

                txtproductname.Text = name;
                txtDescription.Text = desc;
                txtCostprice.Text = cost;   

                dgvProductSearch.Visible = false;
                txtQuantity.Focus();
            }
        }

        private void txtproductname_TextChanged(object sender, EventArgs e)
        {
            string search = txtproductname.Text.Trim().ToLower();
            if (allProducts == null || string.IsNullOrEmpty(search))
            {
                dgvProductSearch.Visible = false;
                return;
            }

                var filtered = allProducts.AsEnumerable()
             .Where(row =>
                row.Field<string>("name").ToLower().Contains(search) ||
                row.Field<string>("description").ToLower().Contains(search) ||
                row.Field<int>("sale_price").ToString().ToLower().Contains(search)
             )
                .ToList();

            dgvProductSearch.Rows.Clear();

            if (filtered.Any())
            {
                foreach (var row in filtered)
                {
                    dgvProductSearch.Rows.Add(row["name"], row["description"], row["sale_price"]);
                }
                dgvProductSearch.Visible = true;
                dgvProductSearch.BringToFront();
            }
            else
            {
                dgvProductSearch.Visible = false;
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count > 0)
            {
                dgvInvoice.Rows.RemoveAt(dgvInvoice.SelectedRows[0].Index);
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
    }
}
