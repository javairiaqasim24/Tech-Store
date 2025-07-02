using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;

namespace TechStore.UI
{
    public partial class Customersale : Form
    {
        private readonly ICustomerSaleBL _saleBl;
        private DataGridView dgvProductSearch;

        public Customersale(ICustomerSaleBL saleBl)
        {
            _saleBl = saleBl;
            InitializeComponent();
            SetupSearchGrid();
            ConfigureCartGrid();
        }

        private void SetupSearchGrid()
        {
            // Initialize product search results grid
            dgvProductSearch = new DataGridView
            {
                Location = new Point(txtproductname.Left, txtproductname.Bottom + 5),
                Size = new Size(dataGridView1.Width, 250),
                Visible = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                Name = "dgvProductSearch",
                AllowUserToAddRows = false,
                MultiSelect = false,
                BackgroundColor = SystemColors.Window,
                BorderStyle = BorderStyle.Fixed3D,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Add columns to search grid
            dgvProductSearch.Columns.Add("Name", "Product Name");
            dgvProductSearch.Columns.Add("description", "description");
            dgvProductSearch.Columns.Add("Price", "Price");
            dgvProductSearch.Columns.Add("Stock", "In Stock");
            dgvProductSearch.Columns["Price"].DefaultCellStyle.Format = "N2";

            // Handle selection in search grid
            dgvProductSearch.CellClick += DgvProductSearch_CellClick;

            // Add to form controls
            Controls.Add(dgvProductSearch);
            dgvProductSearch.BringToFront();
        }

        private void DgvProductSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                LoadProductFromSearch(e.RowIndex);
            }
        }

        private void ConfigureCartGrid()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Sku", "SKU");
            dataGridView1.Columns.Add("Name", "Product Name");
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns.Add("Price", "Unit Price");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Discount", "Discount");
            dataGridView1.Columns.Add("Total", "Total Price");

            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "N2";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "N2";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            discount.Text = "0";
        }


        private void txtserial_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtserial.Text))
            {
                ClearProductFields();
                return;
            }

            try
            {
                var product = _saleBl.GetProductBySku(txtserial.Text.Trim());
                if (product != null)
                {
                    txtproductname.Text = product.name;
                    txtdescription.Text = product.description;
                    //txtsaleprice.Text = product.price?.ToString("N2") ?? "0.00";
                    discount.Text = "0";
                    dgvProductSearch.Visible = false;
                    CalculateNetPrice();
                }
                else
                {
                    ShowMessage("Product Not Found", "No product found with this SKU");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error", ex.Message);
            }
        }

        private void txtproductname_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                dgvProductSearch.Visible = false;
                return;
            }

            try
            {
                var products = _saleBl.SearchProductsByName(txtproductname.Text.Trim());
                PopulateSearchGrid(products);
            }
            catch (Exception ex)
            {
                ShowMessage("Search Error", ex.Message);
            }
        }

        private void PopulateSearchGrid(List<Products> products)
        {
            dgvProductSearch.Rows.Clear();

            foreach (var p in products)
            {
                dgvProductSearch.Rows.Add(
                    p.name,
                    p.description
                    //p.price ?? 0,
                    //p.quantity ?? 0
                );
            }

            dgvProductSearch.Visible = products.Count > 0;
        }

        private void LoadProductFromSearch(int rowIndex)
        {
            var row = dgvProductSearch.Rows[rowIndex];
            txtproductname.Text = row.Cells[0].Value?.ToString();       // Name
            txtdescription.Text = row.Cells[1].Value?.ToString();       // Description
            txtsaleprice.Text = row.Cells[2].Value?.ToString() ?? "0.00"; // Price
            discount.Text = "0";
            txtserial.Clear(); // Clear serial for non-serialized products
            dgvProductSearch.Visible = false;
            CalculateNetPrice();
        }


        private void discount_TextChanged(object sender, EventArgs e)
        {
            CalculateNetPrice();
        }

        private void CalculateNetPrice()
        {
            if (decimal.TryParse(txtsaleprice.Text, out decimal unitPrice) &&
                decimal.TryParse(discount.Text, out decimal discountAmount) &&
                int.TryParse(quantity.Text, out int qty))
            {
                if (discountAmount < 0 || discountAmount > unitPrice)
                {
                    ShowMessage("Invalid Discount", "Discount cannot be negative or greater than price.");
                    discount.Text = "0";
                    return;
                }

                decimal discountedPricePerUnit = unitPrice - discountAmount;
                decimal total = discountedPricePerUnit * qty;

                priceafterdisc.Text = total.ToString("N2");
            }
            else
            {
                priceafterdisc.Text = "0.00";
            }
        }



        private void btnadd_Click(object sender, EventArgs e)
        {
            AddToSaleCart();
        }

        private void AddToSaleCart()
        {
            if (!ValidateSaleProduct()) return;

            dataGridView1.Rows.Add(
                txtserial.Text.Trim(),
                txtproductname.Text.Trim(),
                txtdescription.Text.Trim(),
                txtsaleprice.Text.Trim(),
                quantity.Text.Trim(),
                discount.Text.Trim(),
                priceafterdisc.Text.Trim()
            );

            ClearProductFields();
            txtserial.Focus();
        }


        private bool ValidateSaleProduct()
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text))
            {
                ShowMessage("Product Required", "Please select a product first");
                return false;
            }

            if (!int.TryParse(quantity.Text, out int qty) || qty <= 0)
            {
                ShowMessage("Invalid Quantity", "Please enter a valid quantity");
                quantity.Focus();
                return false;
            }

            return true;
        }

        private void ClearProductFields()
        {
            txtserial.Clear();
            txtproductname.Clear();
            txtdescription.Clear();
            txtsaleprice.Clear();
            discount.Text = "0";
            priceafterdisc.Clear();
            dgvProductSearch.Visible = false;
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.Remove(row);
                }
            }
            else
            {
                ShowMessage("Selection Required", "Please select items to remove");
            }
        }

        private void quantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;

            if (e.KeyChar == (char)Keys.Enter)
            {
                AddToSaleCart();
                e.Handled = true;
            }
        }

        private void txtserial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrWhiteSpace(txtserial.Text))
            {
                txtserial_TextChanged(sender, e);
                e.Handled = true;
            }
        }

        private void Customersale_Load(object sender, EventArgs e)
        {
            txtserial.Focus();
        }

        private void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK,
                title.Contains("Error") ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtdescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtsaleprice_TextChanged(object sender, EventArgs e)
        {

        }

        private void quantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void priceafterdisc_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnsrch_Click(object sender, EventArgs e)
        {
            string manualSerial = manualserialtxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(manualSerial))
            {
                ShowMessage("Input Required", "Please enter a serial number.");
                return;
            }

            try
            {
                var product = _saleBl.GetProductBySku(manualSerial);
                if (product != null)
                {
                    txtserial.Text = manualSerial;
                    txtproductname.Text = product.name;
                    txtdescription.Text = product.description;
                    //txtsaleprice.Text = product.price?.ToString("N2") ?? "0.00";
                    discount.Text = "0";
                    dgvProductSearch.Visible = false;
                    CalculateNetPrice();
                }
                else
                {
                    ShowMessage("Product Not Found", "No product found with this serial number.");
                }
            }
            catch (Exception ex)
            {
                ShowMessage("Error", ex.Message);
            }
        }


        private void manualserialtxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void Customersale_Load_1(object sender, EventArgs e)
        {

        }
    }
}