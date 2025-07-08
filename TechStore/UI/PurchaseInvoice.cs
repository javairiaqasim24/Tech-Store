using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KIMS;
using Newtonsoft.Json;
using TechStore.BL.Models;
using TechStore.DL;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace TechStore.UI
{
    public partial class PurchaseInvoice : Form
    {
        private DataGridView dgvProductSearch;
        private DataTable allProducts; // holds all products from DB or dummy
        purchaseDL p = new purchaseDL();


        public PurchaseInvoice()
        {
            InitializeComponent();
            cmbSupplierName.DropDownStyle = ComboBoxStyle.DropDown;
            ConfigureInvoiceGrid();
            SetupSearchGrid();
            LoadProductData(); // Fill allProducts
            dgvInvoice.AllowUserToAddRows = false;
            this.VisibleChanged += PurchaseInvoice_VisibleChanged;

            string searchKeyword = cmbSupplierName.Text.Trim();

            List<string> suppliersList = DatabaseHelper.Instance.GetSuppliers(searchKeyword);

            cmbSupplierName.DataSource = null;
            cmbSupplierName.DataSource = suppliersList;


        }

        private void LoadProductData()
        {
            allProducts = p.GetProducts();

        }

        private void ConfigureInvoiceGrid()
        {
            dgvInvoice.Columns.Clear();

            dgvInvoice.Columns.Add("Name", "Product Name");
            dgvInvoice.Columns.Add("Description", "Description");
            dgvInvoice.Columns.Add("Quantity", "Quantity");

            dgvInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void SetupSearchGrid()
        {
            dgvProductSearch = new DataGridView
            {
                Location = new Point(txtProductName.Left, txtProductName.Bottom + 5),
                Width = txtProductName.Width + 1200,
                Height = 580,
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

            dgvProductSearch.CellClick += DgvProductSearch_CellClick;
            this.Controls.Add(dgvProductSearch);
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtQuantity.Text))
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

            if (editingRowIndex != null)
            {
                // Update existing row
                dgvInvoice.Rows[(int)editingRowIndex].SetValues(
                    txtProductName.Text,
                    txtdescription.Text,
                    txtQuantity.Text
                );

                editingRowIndex = null;
                MessageBox.Show("Row updated successfully!");
            }
            else
            {
                // Add new row
                dgvInvoice.Rows.Add(
                    txtProductName.Text,
                    txtdescription.Text,
                    txtQuantity.Text
                );
            }

            // Clear fields
            txtProductName.Clear();
            txtdescription.Clear();
            txtQuantity.Clear();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            string supplierName = cmbSupplierName.Text.Trim();

            if (string.IsNullOrWhiteSpace(supplierName))
            {
                DialogResult result = MessageBox.Show(
                    "Don't you want to select or enter a supplier?",
                    "Supplier Not Specified",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    supplierName = "";
                }
                else
                {
                    MessageBox.Show("Please type or select a supplier before continuing.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSupplierName.Focus();
                    return;
                }
            }

            // ✅ Move the actual logic outside the if
            DateTime saleDate = DateTime.Now;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save Purchase Invoice";
            saveFileDialog.FileName = "PurchaseInvoice.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                p.CreateSaleInvoicePdf(dgvInvoice, filePath, supplierName, saleDate);
                MessageBox.Show("PDF Generated Successfully.");
                ClearInvoiceForm();
            }
            else
            {
                MessageBox.Show("PDF generation was cancelled.");
            }
        }


        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            string search = txtProductName.Text.Trim().ToLower();
            if (allProducts == null || string.IsNullOrEmpty(search))
            {
                dgvProductSearch.Visible = false;
                return;
            }

            var filtered = allProducts.AsEnumerable()
                .Where(row => row.Field<string>("name").ToLower().Contains(search) ||
                              row.Field<string>("description").ToLower().Contains(search))
                .ToList();

            dgvProductSearch.Rows.Clear();

            if (filtered.Any())
            {
                foreach (var row in filtered)
                {
                    dgvProductSearch.Rows.Add(row["name"], row["description"]);
                }
                dgvProductSearch.Visible = true;
                dgvProductSearch.BringToFront();
            }
            else
            {
                dgvProductSearch.Visible = false;
            }
        }

        private void DgvProductSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string name = dgvProductSearch.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string desc = dgvProductSearch.Rows[e.RowIndex].Cells["Description"].Value.ToString();

                txtProductName.Text = name;
                txtdescription.Text = desc;

                dgvProductSearch.Visible = false;
                txtQuantity.Focus();
            }
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<Addsupplierform>();
            f.ShowDialog(this);
        }

        private void cmbSupplierName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private int? editingRowIndex = null;
        private void btnedit_Click(object sender, EventArgs e)
        {
            if (dgvInvoice.SelectedRows.Count > 0)
            {
                var row = dgvInvoice.SelectedRows[0];
                txtProductName.Text = row.Cells["Name"].Value?.ToString();
                txtdescription.Text = row.Cells["Description"].Value?.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value?.ToString();

                editingRowIndex = row.Index; 
            }
            else
            {
                MessageBox.Show("Please select a row to edit.");
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

        private void button1_Click(object sender, EventArgs e)
        {
            // Validate data
            if (dgvInvoice.Rows.Count == 0)
            {
                MessageBox.Show("No items to print in invoice.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string supplierName = cmbSupplierName.Text.Trim();

            if (string.IsNullOrWhiteSpace(supplierName))
            {
                DialogResult result = MessageBox.Show(
                    "Don't you want to select or enter a supplier?",
                    "Supplier Not Specified",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (result == DialogResult.Yes)
                {
                    supplierName = "";
                }
                else
                {
                    MessageBox.Show("Please type or select a supplier before continuing.", "Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbSupplierName.Focus();
                    return;
                }
            }
            DateTime purchaseDate = dtpPurchaseDate.Value;
            p.PrintPurchaseInvoiceDirectly(dgvInvoice, supplierName, purchaseDate);

            
            if (File.Exists("TempInvoice.json"))
            {
                File.Delete("TempInvoice.json");
            }

           
            ClearInvoiceForm();

            MessageBox.Show("Invoice printed", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SaveTempInvoice()
        {
            var data = new TempInvoiceData
            {
                SupplierName = cmbSupplierName.Text,
                PurchaseDate = dtpPurchaseDate.Value,
                Items = dgvInvoice.Rows
                    .Cast<DataGridViewRow>()
                    .Where(r => !r.IsNewRow)
                    .Select(r => new InvoiceItem
                    {
                        ProductName = r.Cells["Name"].Value?.ToString(),
                        Description = r.Cells["Description"].Value?.ToString(),
                        Quantity = int.TryParse(r.Cells["Quantity"].Value?.ToString(), out int q) ? q : 0
                    }).ToList()
            };

            string json = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("TempInvoice.json", json);
        }

        private void LoadTempInvoice()
        {
            if (!File.Exists("TempInvoice.json")) return;

            string json = File.ReadAllText("TempInvoice.json");
            var data = JsonConvert.DeserializeObject<TempInvoiceData>(json);

            cmbSupplierName.Text = data.SupplierName;
            dtpPurchaseDate.Value = data.PurchaseDate;

            dgvInvoice.Rows.Clear();
            foreach (var item in data.Items)
            {
                dgvInvoice.Rows.Add(item.ProductName, item.Description, item.Quantity);
            }
        }

        private void PurchaseInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTempInvoice();
        }

        private void PurchaseInvoice_Load(object sender, EventArgs e)
        {
            LoadTempInvoice();
        }
        private void PurchaseInvoice_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                SaveTempInvoice();
            }
        }

        private void ClearInvoiceForm()
        {
            cmbSupplierName.Text = "";
            dtpPurchaseDate.Value = DateTime.Today;
            dgvInvoice.Rows.Clear();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<addproductform>();
            f.ShowDialog(this);
        }

        private void dgvInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
