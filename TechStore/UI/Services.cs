using KIMS;
using Microsoft.Extensions.DependencyInjection;
using QuestPDF.Fluent;
using System;
using System.Collections.Generic;
using System.ComponentModel;

//using System.ComponentModel;
using System.Data;
using System.Drawing; // Required for Print
//using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TechStore.BL;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.UI
{
    public partial class Services : Form
    {
        private List<servicedevices> serviceDevices = new List<servicedevices>();
        private readonly ICustomer_serviceBl ibl;
        private int lastSavedReceiptId;
        private string lastSavedCustomerName;
        private string lastSavedRemarks;
        private List<servicedevices> lastSavedDevices;
        private DataGridView dgvCustomerSearch = new DataGridView();


        private bool IsInDesignMode()
        {
            return LicenseManager.UsageMode == LicenseUsageMode.Designtime ||
                   System.Diagnostics.Process.GetCurrentProcess().ProcessName == "devenv";
        }
        public Services(ICustomer_serviceBl ibl)
        {
            InitializeComponent();

            if (!IsInDesignMode())
            {
                this.ibl = ibl;
                ConfigureGrid();
                loadcustomers();
                SetupCustomerGrid();
            }
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
            dgvCustomerSearch.Size = new System.Drawing.Size(dataGridView2.Width / 2, 150);
            dgvCustomerSearch.BringToFront();

            dgvCustomerSearch.CellClick += DgvCustomerSearch_CellClick;
        }

        private void LoadProductData()
        {


        }
        private void loadcustomers()
        {
            //cmbCustomer.Items.Clear();
            //var customers = DatabaseHelper.Instance.getAllCustomers();

            //cmbCustomer.Items.AddRange(customers.ToArray());
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (serviceDevices.Count == 0)
            {
                MessageBox.Show("Please add at least one device.");
                return;
            }

            string customerName = txtcustomer.Text.Trim();
            if (string.IsNullOrWhiteSpace(customerName))
            {
                MessageBox.Show("Please enter a customer name.");
                return;
            }

            int customerId = servicesDL.GetCustomerIdByName(customerName);

            // If not found, create as walk-in
            if (customerId == -1)
            {
                customerId = servicesDL.InsertNewWalkInCustomer(customerName);
                if (customerId == -1)
                {
                    MessageBox.Show("Failed to create new customer record.", "Error");
                    return;
                }
            }

            var receipt = new customerservicerecipt
            {
                CustomerId = customerId,
                CustomerName = customerName,
                Remarks = txtremarks.Text.Trim(),
                Devices = serviceDevices
            };

            try
            {
                int receiptId = ibl.savereceipt(receipt);

                if (receiptId > 0)
                {
                    lastSavedReceiptId = receiptId;
                    lastSavedCustomerName = receipt.CustomerName;
                    lastSavedRemarks = receipt.Remarks;
                    lastSavedDevices = new List<servicedevices>(receipt.Devices);

                    MessageBox.Show("Service receipt saved successfully. Receipt ID: " + receiptId);
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Failed to save receipt.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving receipt: " + ex.Message);
            }
        }

        private void PrintServiceReceipt(int receiptId, string customerName, string remarks, List<servicedevices> devices)
        {
            System.Drawing.Printing.PrintDocument printDoc = new System.Drawing.Printing.PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                var titleFont = new System.Drawing.Font("Arial", 18, System.Drawing.FontStyle.Bold);
                var regularFont = new System.Drawing.Font("Arial", 11);
                var boldFont = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
                var pen = new System.Drawing.Pen(System.Drawing.Color.Gray);
                var brush = System.Drawing.Brushes.Black;

                float x = 50, y = 50;
                float width = e.PageBounds.Width - 100;

                // Optional logo
                try
                {
                    string logoPath = "Resources/mns.png";
                    if (System.IO.File.Exists(logoPath))
                    {
                        using (var logo = System.Drawing.Image.FromFile(logoPath))
                        {
                            e.Graphics.DrawImage(logo, x, y, 100, 100);
                        }
                    }
                }
                catch { }

                // Header
                e.Graphics.DrawString("Tech Store", titleFont, brush, x + 300, y);
                y += 30;
                e.Graphics.DrawString("123 Market Road, CityName", regularFont, brush, x + 300, y);
                y += 20;
                e.Graphics.DrawString("Phone: +92-300-1234567", regularFont, brush, x + 300, y);
                y += 20;
                e.Graphics.DrawString("Email: support@techstore.com", regularFont, brush, x + 300, y);
                y += 40;

                e.Graphics.DrawLine(pen, x, y, x + width, y);
                y += 15;

                e.Graphics.DrawString("Service Receipt", titleFont, brush, x + 200, y);
                y += 35;

                e.Graphics.DrawString($"Receipt #: {receiptId}", boldFont, brush, x, y);
                y += 25;
                e.Graphics.DrawString($"Customer: {customerName}", boldFont, brush, x, y);
                y += 25;
                e.Graphics.DrawString($"Date: {DateTime.Now.ToShortDateString()}", boldFont, brush, x, y);
                y += 25;

                // Remarks
                if (!string.IsNullOrWhiteSpace(remarks))
                {
                    e.Graphics.DrawString("Remarks:", boldFont, brush, x, y);
                    y += 20;
                    e.Graphics.DrawString(remarks, regularFont, brush, new System.Drawing.RectangleF(x, y, width, 60));
                    y += 60;
                }

                e.Graphics.DrawLine(pen, x, y, x + width, y);
                y += 10;

                // Table headers
                e.Graphics.DrawString("Device", boldFont, brush, x, y);
                e.Graphics.DrawString("Issue", boldFont, brush, x + 250, y);
                e.Graphics.DrawString("Return Date", boldFont, brush, x + 600, y);
                y += 25;
                e.Graphics.DrawLine(pen, x, y, x + width, y);
                y += 10;

                // Device list
                foreach (var device in devices)
                {
                    e.Graphics.DrawString(device.DeviceName, regularFont, brush, x, y);
                    e.Graphics.DrawString(device.Issue, regularFont, brush, x + 250, y);
                    e.Graphics.DrawString(device.ExpectedDate.ToShortDateString(), regularFont, brush, x + 600, y);
                    y += 25;

                    if (y > e.PageBounds.Height - 100)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                y += 10;
                e.Graphics.DrawLine(pen, x, y, x + width, y);
                y = e.PageBounds.Height - 50;
                e.Graphics.DrawString("Developed by Tech Store", new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Italic), brush, x + 250, y);
            };

            var dlg = new PrintDialog();
            dlg.Document = printDoc;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
            }
        }



        private void ClearForm()
        {
            txtproductname.Clear();
            txtDescription.Clear();
            txtremarks.Clear();
            //cmbCustomer.SelectedIndex = -1;
            serviceDevices.Clear();
            dataGridView2.Rows.Clear();
        }
        private void ConfigureGrid()
        {
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.Columns.Add("DeviceName", "Device Name");
            dataGridView2.Columns.Add("Issue", "Issue");
            dataGridView2.Columns.Add("ExpectedDate", "Expected Return Date");
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void ConfigureInvoiceGrid()
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtproductname.Text) || string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Please enter both product name and issue.");
                return;
            }

            var device = new servicedevices
            {
                DeviceName = txtproductname.Text.Trim(),
                Issue = txtDescription.Text.Trim(),
                ReportDate = DateTime.Now,
                ExpectedDate = guna2DateTimePicker1.Value,
                Status = "Pending",
                ServiceCharge = 0
            };

            serviceDevices.Add(device);

            dataGridView2.Rows.Add(device.DeviceName, device.Issue, device.ExpectedDate.ToShortDateString());

            txtproductname.Clear();
            txtDescription.Clear();
        }


        private void ClearItemInputs()
        {
            txtproductname.Clear();
            txtDescription.Clear();

        }

        private void UpdateTotal()
        {

        }

        private void SetupSearchGrid()
        {

        }

        private void DgvProductSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtproductname_TextChanged(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count > 0)
            {
                dataGridView2.Rows.RemoveAt(dataGridView2.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }
        }

        private void Services_Load(object sender, EventArgs e)
        {
            guna2DateTimePicker1.Value = DateTime.Now;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {
            var f = Program.ServiceProvider.GetRequiredService<AddCustomerform>();
            f.ShowDialog(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lastSavedReceiptId > 0)
            {
                PrintServiceReceipt(lastSavedReceiptId, lastSavedCustomerName, lastSavedRemarks, lastSavedDevices);
            }
            else
            {
                MessageBox.Show("Please save the receipt before printing.");
            }
        }


        private void GenerateServiceReceiptPdf(int receiptId, string customerName, string remarks, List<servicedevices> devices, string filePath)
        {
            QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            QuestPDF.Fluent.Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(595, 842);
                    page.Margin(20);
                    page.PageColor(QuestPDF.Helpers.Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Header().Row(row =>
                    {
                        row.RelativeColumn().Height(80).Column(column =>
                        {
                            string imagePath = "Resources/mns.png";
                            if (File.Exists(imagePath))
                                column.Item().Image(imagePath, QuestPDF.Infrastructure.ImageScaling.FitHeight);
                        });

                        row.RelativeColumn().Column(column =>
                        {
                            column.Item().AlignRight().Text("Tech Store").FontSize(20).Bold();
                            column.Item().AlignRight().Text("123 Market Road, CityName").FontSize(10);
                            column.Item().AlignRight().Text("Phone: +92-300-1234567").FontSize(10);
                            column.Item().AlignRight().Text("Email: support@techstore.com").FontSize(10);
                        });
                    });

                    page.Content().PaddingVertical(10).Column(content =>
                    {
                        content.Item().Text("Service Receipt").FontSize(18).Bold().AlignCenter();
                        content.Item().Text($"Receipt #: {receiptId}").FontSize(12);
                        content.Item().Text($"Customer: {customerName}").FontSize(12);
                        content.Item().Text($"Date: {DateTime.Now:dd/MM/yyyy}").FontSize(12);

                        if (!string.IsNullOrWhiteSpace(remarks))
                        {
                            content.Item().PaddingTop(10).Text("Remarks:").Bold();
                            content.Item().Text(remarks).WrapAnywhere();
                        }

                        content.Item().PaddingVertical(10).LineHorizontal(1).LineColor(QuestPDF.Helpers.Colors.Grey.Lighten2);

                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4); // Device
                                columns.RelativeColumn(5); // Issue
                                columns.RelativeColumn(3); // Return Date
                            });

                            // Table header
                            table.Header(header =>
                            {
                                header.Cell().Element(CellStyle).Text("Device").Bold();
                                header.Cell().Element(CellStyle).Text("Issue").Bold();
                                header.Cell().Element(CellStyle).Text("Return Date").Bold();
                            });

                            // Table data
                            foreach (var device in devices)
                            {
                                table.Cell().Element(CellStyle).Text(device.DeviceName);
                                table.Cell().Element(CellStyle).Text(device.Issue);
                                table.Cell().Element(CellStyle).Text(device.ExpectedDate.ToShortDateString());
                            }

                            // Cell style
                            QuestPDF.Infrastructure.IContainer CellStyle(QuestPDF.Infrastructure.IContainer cell)
                            {
                                return cell
                                    .BorderBottom(1)
                                    .BorderColor(QuestPDF.Helpers.Colors.Grey.Lighten2)
                                    .PaddingVertical(5);
                            }
                        });

                        content.Item().PaddingTop(20).AlignCenter().Text("Developed by Tech Store").Italic().FontSize(10);
                    });
                });
            }).GeneratePdf(filePath);
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if (lastSavedReceiptId > 0)
            {
                string savePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), $"ServiceReceipt_{lastSavedReceiptId}.pdf");
                GenerateServiceReceiptPdf(lastSavedReceiptId, lastSavedCustomerName, lastSavedRemarks, lastSavedDevices, savePath);
                MessageBox.Show("PDF generated on Desktop.");
            }
            else
            {
                MessageBox.Show("Please save the receipt before generating PDF.");
            }
        }

        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtcustomer_TextChanged(object sender, EventArgs e)
        {

            string keyword = txtcustomer.Text.Trim();
            //string type = combocustomer.SelectedItem?.ToString();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                dgvCustomerSearch.Visible = false;
                return;
            }

            DataTable customers = servicesDL.GetAllCustomers(); // ✅ Use your DL method

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

        private void DgvCustomerSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtcustomer.Text = dgvCustomerSearch.Rows[e.RowIndex].Cells["name"].Value.ToString();
                dgvCustomerSearch.Visible = false;
            }
        }

    }
}
