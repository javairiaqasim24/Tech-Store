using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KIMS;
using MySql.Data.MySqlClient;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

using System.Xml.Linq;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.DL
{
    internal class purchaseDL : IPurchaseDl
    {
        public DataTable GetProducts()
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                string query = "SELECT product_id, name, description FROM products";
                using (var cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }


        public void CreateSaleInvoicePdf(DataGridView cart, string filePath, string Name, DateTime saleDate)
        {

            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Content().Column(content =>
                    {
                        // Header with logo and info
                        content.Item().Row(row =>
                        {
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().Image("logo.jpg", ImageScaling.FitWidth);
                            });

                            row.RelativeItem(3).Column(col =>
                            {
                                col.Item().AlignRight().Text("Tech Store").FontSize(22).Bold();
                                col.Item().AlignRight().Text("123 Market Road, CityName").FontSize(10);
                                col.Item().AlignRight().Text("Phone: +92-300-1234567").FontSize(10);
                                col.Item().AlignRight().Text("Email: support@techstore.com").FontSize(10);
                            });
                        });


                        content.Item().Element(e =>
                            e.PaddingVertical(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Invoice title and supplier info
                        content.Item().Text("Purchase Invoice").FontSize(20).Bold().AlignCenter();
                        content.Item().Text($"Supplier Name: {Name}").FontSize(14);
                        content.Item().Text($"Date: {saleDate.ToShortDateString()}").FontSize(12);

                        content.Item().Element(e =>
                            e.PaddingVertical(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Table of items
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(4); // Product Name
                                columns.RelativeColumn(6); // Description
                                columns.RelativeColumn(2); // Quantity
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Product").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Description").Bold();
                                header.Cell().BorderBottom(1).BorderColor(Colors.Grey.Medium).Text("Quantity").Bold();
                            });

                            // Data Rows
                            foreach (DataGridViewRow row in cart.Rows)
                            {
                                if (row.IsNewRow) continue;

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(row.Cells["Name"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(row.Cells["Description"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(row.Cells["Quantity"]?.Value?.ToString());
                            }
                        });

                        // ✅ Add this footer
                        page.Footer().AlignCenter().Column(col =>
                        {
                            col.Item().LineHorizontal(1).LineColor(Colors.Grey.Lighten2);
                            col.Item().Text("Developed By : Tech Store ").FontSize(12).Italic();
                        });
                    });
                });
            }).GeneratePdf(filePath);
        }

        public void PrintPurchaseInvoiceDirectly(DataGridView cart, string supplierName, DateTime purchaseDate)
        {
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printers are installed on this system.", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                DrawPurchaseInvoice(e, cart, supplierName, purchaseDate);
            };

            PrintDialog dialog = new PrintDialog
            {
                Document = printDoc,
                AllowSomePages = false,
                UseEXDialog = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                printDoc.Print();
                MessageBox.Show("Purchase Invoice sent to printer.", "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public void DrawPurchaseInvoice(PrintPageEventArgs e, DataGridView cart, string supplierName, DateTime purchaseDate)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 11);
            Pen borderPen = new Pen(System.Drawing.Color.Gray, 0.5f);
            Brush brush = Brushes.Black;

            float x = 50, y = 60;
            float pageWidth = e.PageBounds.Width - 100;

            // Logo (optional)
            
                try
                {
                    string imagePath = "Resources/mns.png";
                    if (!File.Exists(imagePath))
                    {
                        MessageBox.Show("Logo not found at: " + Path.GetFullPath(imagePath));
                    }
                    else
                    {
                    System.Drawing.Image logo = System.Drawing.Image.FromFile(imagePath);

                    e.Graphics.DrawImage(logo, 50, 50, 200, 100);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Image load error: " + ex.Message);
                }
            
           

            // Company Info
            e.Graphics.DrawString("Tech Store", titleFont, brush, x + 400, y);
            y += 25;
            e.Graphics.DrawString("123 Market Road, CityName", regularFont, brush, x + 400, y);
            y += 18;
            e.Graphics.DrawString("Phone: +92-300-1234567", regularFont, brush, x + 400, y);
            y += 18;
            e.Graphics.DrawString("Email: support@techstore.com", regularFont, brush, x + 400, y);

            y += 40;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + pageWidth, y);
            y += 10;

            // Invoice Header
            e.Graphics.DrawString("Purchase Invoice", titleFont, brush, x + 250, y);
            y += 30;
            e.Graphics.DrawString($"Supplier: {supplierName}", regularFont, brush, x, y);
            y += 20;
            e.Graphics.DrawString($"Date: {purchaseDate.ToShortDateString()}", regularFont, brush, x, y);
            y += 25;

            // Table Headers
            string[] headers = { "Product Name", "Description", "Qty" };
            float[] widths = { 300, 450, 50 };
            float tableX = x;
            float rowHeight = 30;

            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, tableX, y, widths[i], rowHeight);
                e.Graphics.DrawRectangle(borderPen, tableX, y, widths[i], rowHeight);
                e.Graphics.DrawString(headers[i], headerFont, brush, tableX + 3, y + 5);
                tableX += widths[i];
            }

            y += rowHeight;

            // Table Rows
            foreach (DataGridViewRow row in cart.Rows)
            {
                if (row.IsNewRow) continue;

                string[] values =
                {
            row.Cells["Name"]?.Value?.ToString(),
            row.Cells["Description"]?.Value?.ToString(),
            row.Cells["Quantity"]?.Value?.ToString()
        };

                tableX = x;
                for (int i = 0; i < values.Length; i++)
                {
                    e.Graphics.DrawRectangle(borderPen, tableX, y, widths[i], rowHeight);
                    e.Graphics.DrawString(values[i], regularFont, brush, new RectangleF(tableX + 3, y + 5, widths[i] - 6, rowHeight - 6));
                    tableX += widths[i];
                }

                y += rowHeight;

                // Page break logic
                if (y + rowHeight > e.PageBounds.Height - 100)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + pageWidth, y);

            // --- Footer at bottom ---
            float footerY = e.PageBounds.Height - 60;
            e.Graphics.DrawLine(Pens.Gray, x, footerY, x + pageWidth, footerY);
            e.Graphics.DrawString("Developed By : Tech Store ", new Font("Italic", 10, FontStyle.Italic), brush, x + pageWidth / 2 - 80, footerY + 5);


        }


    }
}
