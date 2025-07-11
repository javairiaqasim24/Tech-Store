using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;
using static QuestPDF.Helpers.Colors;

namespace TechStore.UI
{
    public partial class Customersale : Form
    {
        private readonly ICustomerSaleBL _saleBl;
        private DataGridView dgvProductSearch;
        private DataGridView dgvCustomerSearch = new DataGridView();
        private int _lastBillId;
        private string sku;

        public Customersale(ICustomerSaleBL saleBl)
        {
            _saleBl = saleBl;
            InitializeComponent();
            SetupSearchGrid();
            ConfigureCartGrid();
            SetupCustomerGrid();
        }

        private void SetupSearchGrid()
        {
            // Initialize product search results grid
            dgvProductSearch = new DataGridView
            {
                Location = new Point(txtproductname.Left, txtproductname.Bottom + 200),
                Size = new Size(dataGridView1.Width, 250), // Increased height for better visibility
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
            dgvCustomerSearch.Location = new Point(txtcustomer.Left, txtcustomer.Top - dgvCustomerSearch.Height + 80);
            dgvCustomerSearch.Size = new Size(dataGridView1.Width/2, 150);
            dgvCustomerSearch.BringToFront();

            dgvCustomerSearch.CellClick += DgvCustomerSearch_CellClick;
        }

        private void DgvCustomerSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtcustomer.Text = dgvCustomerSearch.Rows[e.RowIndex].Cells["name"].Value.ToString();
                dgvCustomerSearch.Visible = false;
            }
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
            dataGridView1.Columns.Add("Sku", "SKU"); // still showing last scanned serial
            dataGridView1.Columns.Add("Name", "Product Name");
            dataGridView1.Columns.Add("Description", "Description");
            dataGridView1.Columns.Add("Warranty", "Warranty (Months)");
            dataGridView1.Columns.Add("Price", "Unit Price");
            dataGridView1.Columns.Add("Quantity", "Quantity");
            dataGridView1.Columns.Add("Discount", "Discount");
            dataGridView1.Columns.Add("Total", "Total Price");


            dataGridView1.Columns["Price"].DefaultCellStyle.Format = "N0";
            dataGridView1.Columns["Total"].DefaultCellStyle.Format = "N0";
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
            sku = txtserial.Text;
            if (!Customersaledl.IsProductSold(sku))
            {
                // Proceed with operation (e.g., return, resell, etc.)
            }
            else
            {
                MessageBox.Show("Product already sold.");
                return;
            }



            try
            {
                var product = _saleBl.GetProductBySku(txtserial.Text.Trim());
                if (product != null)
                {
                    txtproductname.Text = product.name;
                    txtdescription.Text = product.description;
                    txtsaleprice.Text = product.price.ToString() ?? "0.00";
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
            if (string.IsNullOrWhiteSpace(txtproductname.Text) )
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

        private void PopulateSearchGrid(List<BL.Models.Person.Customersale> products)
        {
            dgvProductSearch.Rows.Clear();

            foreach (var p in products)
            {
                dgvProductSearch.Rows.Add(
                    p.name,
                    p.description,
                    p.price ,
                    p.quantity 
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

                priceafterdisc.Text = total.ToString();
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
            string newSku = txtserial.Text.Trim(); // This is the new serial number (SKU)
            string productName = txtproductname.Text.Trim();

            if (!ValidateSaleProduct()) return;

            int addedQty = int.TryParse(quantity.Text.Trim(), out int parsedQty) ? parsedQty : 1;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string existingName = row.Cells["Name"].Value?.ToString();
                string existingSkus = row.Cells["Sku"].Value?.ToString() ?? "";

                if (existingName == productName)
                {
                    var existingSerialList = existingSkus.Split(',').Select(s => s.Trim()).ToList();
                    if (!existingSerialList.Contains(newSku))
                    {
                        existingSerialList.Add(newSku);
                        row.Cells["Sku"].Value = string.Join(", ", existingSerialList);
                    }

                    int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
                    row.Cells["Quantity"].Value = currentQty + addedQty;

                    decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
                    decimal discount = 0;
                    discount = Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);
                    decimal total = (unitPrice - discount) * (currentQty + addedQty);
                    row.Cells["Total"].Value = total.ToString();

                    UpdateFinalTotals();
                    ClearProductFields();
                    return;
                }
            }
            // New product row
            dataGridView1.Rows.Add(
            newSku,
            productName,
            txtdescription.Text.Trim(),
                txtwarranty.Text.Trim(),
                txtsaleprice.Text.Trim(),
                addedQty.ToString(),                            // ✅ use actual quantity
                discount.Text.Trim(),
                priceafterdisc.Text.Trim()
            );

            UpdateFinalTotals();
        ClearProductFields();
        txtserial.Focus();
        }

        //private void AddToSaleCart()
        //{
        //    string newSku = txtserial.Text.Trim();
        //    string productName = txtproductname.Text.Trim();

        //    if (!ValidateSaleProduct()) return;

        //    int addedQty = int.TryParse(quantity.Text.Trim(), out int parsedQty) ? parsedQty : 1;

        //    foreach (DataGridViewRow row in dataGridView1.Rows)
        //    {
        //        if (row.IsNewRow) continue;

        //        string existingName = row.Cells["Name"].Value?.ToString();
        //        string existingSkus = row.Cells["Sku"].Value?.ToString() ?? "";

        //        if (existingName == productName)
        //        {
        //            // Check if adding this quantity would exceed available stock
        //            int currentQty = Convert.ToInt32(row.Cells["Quantity"].Value);
        //            int totalQtyAfterAdd = currentQty + addedQty;

        //            // Get available stock (similar to validation)
        //            int availableStock = GetAvailableStock(productName, newSku);

        //            if (totalQtyAfterAdd > availableStock)
        //            {
        //                ShowMessage("Insufficient Stock",
        //                    $"Cannot add {addedQty} more. Only {availableStock - currentQty} available to add.");
        //                return;
        //            }

        //            var existingSerialList = existingSkus.Split(',').Select(s => s.Trim()).ToList();
        //            if (!existingSerialList.Contains(newSku))
        //            {
        //                existingSerialList.Add(newSku);
        //                row.Cells["Sku"].Value = string.Join(", ", existingSerialList);
        //            }

        //            row.Cells["Quantity"].Value = totalQtyAfterAdd;

        //            decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
        //            decimal discount = Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);
        //            decimal total = (unitPrice - discount) * totalQtyAfterAdd;
        //            row.Cells["Total"].Value = total.ToString();

        //            UpdateFinalTotals();
        //            ClearProductFields();
        //            return;
        //        }
        //    }

        //    // New product row
        //    dataGridView1.Rows.Add(
        //        newSku,
        //        productName,
        //        txtdescription.Text.Trim(),
        //        txtwarranty.Text.Trim(),
        //        txtsaleprice.Text.Trim(),
        //        addedQty.ToString(),                            // ✅ use actual quantity
        //        discount.Text.Trim(),
        //        priceafterdisc.Text.Trim()
        //    );

        //    UpdateFinalTotals();
        //    ClearProductFields();
        //    txtserial.Focus();
        //}

        private int GetAvailableStock(string productName, string sku)
        {
            if (!string.IsNullOrWhiteSpace(sku))
            {
                // For serialized products, check if serial exists and is available
                var product = _saleBl.GetProductBySku(sku);
                return product != null ? 1 : 0;
            }
            else
            {
                // For non-serialized products, get total stock
                var product = _saleBl.SearchProductsByName(productName).FirstOrDefault();
                return product?.quantity ?? 0;
            }
        }





        private void UpdateFinalTotals()
        {
            decimal totalPrice = 0;
            decimal totalDiscount = 0;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                decimal unitPrice = Convert.ToDecimal(row.Cells["Price"].Value ?? 0);
                decimal discountPerUnit = Convert.ToDecimal(row.Cells["Discount"].Value ?? 0);
                int quantity = Convert.ToInt32(row.Cells["Quantity"].Value ?? 0);
                decimal total = Convert.ToDecimal(row.Cells["Total"].Value ?? 0);

                totalPrice += total;
                totalDiscount += (discountPerUnit * quantity);
            }

            finalpricetxt.Text = totalPrice.ToString();
            finaldiscounttxt.Text = totalDiscount.ToString();
        }


        //private bool ValidateSaleProduct()
        //{
        //    if (string.IsNullOrWhiteSpace(txtproductname.Text))
        //    {
        //        ShowMessage("Product Required", "Please select a product first");
        //        return false;
        //    }

        //    if (!int.TryParse(quantity.Text, out int qty) || qty <= 0)
        //    {
        //        ShowMessage("Invalid Quantity", "Please enter a valid quantity");
        //        quantity.Focus();
        //        return false;
        //    }

        //    return true;
        //}

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

            // Get available stock
            int? availableStock = 0;
            if (!string.IsNullOrWhiteSpace(txtserial.Text))
            {
                // For serialized products, we assume 1 per serial (since they're unique)
                availableStock = 1;
            }
            else
            {
                // For non-serialized products, get stock from database
                //var product = _saleBl.GetProductBySku(txtproductname.Text); // Or however you get the product
                //availableStock = product?.quantity ?? 0;
                availableStock = Customersaledl.GetQuantityInStock(txtproductname.Text);
            }

            // Check if requested quantity exceeds available stock
            if (qty > availableStock)
            {
                ShowMessage("Insufficient Stock", $"Only {availableStock} items available in stock");
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
            txtwarranty.Clear();
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
            CalculateNetPrice();
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
            if (!Customersaledl.IsProductSold(manualSerial))
            {
                // Proceed with operation (e.g., return, resell, etc.)
            }
            else
            {
                MessageBox.Show("Product already sold.");
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
                    txtsaleprice.Text = product.price.ToString() ?? "0.00";
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void finalpricetxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void finaldiscounttxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void combocustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtfinalpaid_TextChanged(object sender, EventArgs e)
        {

        }

        private bool ValidatePayment()
        {
            if (combocustomer.SelectedItem?.ToString() == "Walk-in")
            {
                if (finalpricetxt.Text != txtfinalpaid.Text)
                {
                    ShowMessage("Full Payment Required", "Walk-in customers must pay the full amount.");
                    return false;
                }
            }
            return true;
        }

        private void clearallfields()
        {
            txtserial.Clear();
            txtproductname.Clear();
            txtdescription.Clear();
            txtsaleprice.Clear();
            txtwarranty.Clear();
            discount.Text = "0";
            priceafterdisc.Clear();
            dgvProductSearch.Visible = false;
            dataGridView1.Rows.Clear();
        }
       

        private void btnsave_Click(object sender, EventArgs e)
        {
            if(!thermalprint.Checked && !A4printer.Checked && !onlypdf.Checked)
            {
                MessageBox.Show("Please select the option whether you to print or pdf");
                return;
            }

            if (!ValidatePayment()) return;

            string customerType = combocustomer.SelectedItem?.ToString();
            string customerName = txtcustomer.Text.Trim();
            int customerId;
            
                // Search existing customer
                customerId = _saleBl.GetCustomerIdByNameAndType(customerName, customerType);

                // If not found and type is Walk-in, create
                if (customerId == -1 && customerType == "Walk-in")
                {
                    customerId = _saleBl.InsertNewWalkInCustomer(customerName);
                }
                else if (customerId == -1)
                {
                    ShowMessage("Customer Not Found", "Please select an existing Regular customer.");
                    return;
                }

                if (dataGridView1.Rows.Count == 0 || dataGridView1.Rows.Cast<DataGridViewRow>().All(r => r.IsNewRow))
                {
                    ShowMessage("Cart Empty", "Please add at least one product.");
                    return;
                }
                 // Clear form here
                 // Now proceed to save bill + items
                 _lastBillId = _saleBl.SaveCustomerBill(
                 customerId,
                DateTime.Now,
                 Convert.ToDecimal(finalpricetxt.Text),
                 Convert.ToDecimal(txtfinalpaid.Text),
                 dataGridView1 // Send whole cart
                 );
            if (_lastBillId > 0)
            {
                // 🔥 Check PDF print type
                if (onlypdf.Checked)
                    {
                        SavePdfInvoice();  // ← Generate and save PDF only
                        
                    }

                    else if (A4printer.Checked)
                    {
                        decimal total = long.Parse(finalpricetxt.Text);
                        decimal paid = long.Parse(txtfinalpaid.Text);
                        invoices.PrintInvoiceDirectly(dataGridView1, customerName, DateTime.Now, total, paid, _lastBillId);                       
                    }

                    else if (thermalprint.Checked)
                    {
                        decimal total = long.Parse(finalpricetxt.Text);
                        decimal paid = long.Parse(txtfinalpaid.Text);
                        //invoices.PrintThermalReceipt(dataGridView1, customerName, total, paid, _lastBillId);
                        SavehthermalPdfInvoice();
                         }

                    clearallfields();

                
                MessageBox.Show("Bill Printed");
                }

                else
                {
                    ShowMessage("Failure", "Error saving sale.");
                }
        }      

        private void SavePdfInvoice()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.Title = "Save PDF Invoice";
                saveDialog.FileName = $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        invoices.CreateSaleInvoicePdf(
                            dataGridView1,
                            saveDialog.FileName,
                            txtcustomer.Text.Trim(),
                            DateTime.Now,
                            Convert.ToDecimal(finalpricetxt.Text),
                            Convert.ToDecimal(txtfinalpaid.Text),
                            _lastBillId
                        );

                        MessageBox.Show("PDF saved successfully!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating PDF:\n" + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SavehthermalPdfInvoice()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveDialog.Title = "Save PDF Invoice";
                saveDialog.FileName = $"Invoice_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        invoices.CreateThermalReceiptPdf(dataGridView1, saveDialog.FileName, txtcustomer.Text.Trim(), Convert.ToDecimal(finalpricetxt.Text), Convert.ToDecimal(txtfinalpaid.Text));

                        MessageBox.Show("PDF saved successfully!", "PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error generating PDF:\n" + ex.Message, "PDF Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {
            if(combocustomer.Text == "")
            {
                MessageBox.Show("Please enter the customer type first.");
                return;
            }
            string keyword = txtcustomer.Text.Trim();
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


        private void txtwarranty_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnadcust_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddCustomerform>();
            f.ShowDialog(this);
        }

        private void thermalprint_CheckedChanged(object sender, EventArgs e)
        {
            if (thermalprint.Checked)
            {
                onlypdf.Checked = false;
                A4printer.Checked = false;
            }
        }

        private void onlypdf_CheckedChanged(object sender, EventArgs e)
        {
            if (onlypdf.Checked)
            {
                A4printer.Checked = false;
                thermalprint.Checked = false;
            }
        }

        private void A4printer_CheckedChanged(object sender, EventArgs e)
        {
            if (A4printer.Checked)
            {
                onlypdf.Checked = false;
                thermalprint.Checked = false;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toplbl_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void btnadcust_Click_1(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddCustomerform>();
            f.ShowDialog(this);
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }
    }
}