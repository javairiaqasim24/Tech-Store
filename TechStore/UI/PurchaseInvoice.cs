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
using TechStore.DL;

namespace TechStore.UI
{
    public partial class PurchaseInvoice : Form
    {
        private DataGridView dgvProductSearch;
        private DataTable allProducts; // holds all products from DB or dummy
        DataTable suppliersTable = purchaseDL.GetSuppliers();
        public PurchaseInvoice()
        {
            InitializeComponent();
            ConfigureInvoiceGrid();
            SetupSearchGrid();
            LoadProductData(); // Fill allProducts
            dgvInvoice.AllowUserToAddRows = false;
            

            // Add placeholder row manually
            DataRow placeholder = suppliersTable.NewRow();
            placeholder["name"] = "Select Supplier...";
            suppliersTable.Rows.InsertAt(placeholder, 0);

            // Bind to ComboBox
            cmbSupplierName.DataSource = suppliersTable;
            cmbSupplierName.DisplayMember = "name";
            cmbSupplierName.SelectedIndex = 0; // Show placeholder initially

        }

        private void LoadProductData()
        {
            allProducts = purchaseDL.GetProducts();
           
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
                Width = txtProductName.Width + 100,
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

            dgvProductSearch.CellClick += DgvProductSearch_CellClick;
            this.Controls.Add(dgvProductSearch);
        }
        //private void cmbProducts_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (cmb.SelectedItem != null)
        //    {
        //        DataRowView row = (DataRowView)cmb.SelectedItem;
        //        txtProductName.Text = row["name"].ToString();
        //        txtdescription.Text = row["description"].ToString();
        //    }
        //}

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtProductName.Text) && !string.IsNullOrWhiteSpace(txtQuantity.Text))
            {
                dgvInvoice.Rows.Add(

                    txtProductName.Text,
                    txtdescription.Text,

                    txtQuantity.Text

                );

                // Clear fields
                txtProductName.Clear();
                txtdescription.Clear();
                txtQuantity.Clear();
            }
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            // 2. Get supplier name from ComboBox
            string supplierName = cmbSupplierName.SelectedIndex > 0
            ? cmbSupplierName.Text
            : "Unknown Supplier";

            // 3. Get today's date
            DateTime saleDate = DateTime.Now;

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
            saveFileDialog.Title = "Save Purchase Invoice";
            saveFileDialog.FileName = "PurchaseInvoice.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                purchaseDL.CreateSaleInvoicePdf(dgvInvoice, filePath, supplierName, DateTime.Now);
                MessageBox.Show("PDF Generated Successfully..");
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

        }
    }
}
