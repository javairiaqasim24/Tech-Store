using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TechStore.DL
{
    public class invoices
    {
        public static void CreateSaleInvoicePdf(DataGridView cart, string filePath, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount)
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
                                col.Item().Image("logo.png", ImageScaling.FitWidth);
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

                        // Invoice info
                        content.Item().Text("Sales Invoice").FontSize(20).Bold().AlignCenter();
                        content.Item().Text($"Customer: {customerName}").FontSize(14);
                        content.Item().Text($"Date: {saleDate.ToShortDateString()}").FontSize(12);

                        content.Item().Element(e =>
                            e.PaddingVertical(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Cart table with row and column separators
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2); // SKU
                                columns.RelativeColumn(3); // Product Name
                                columns.RelativeColumn(4); // Description
                                columns.RelativeColumn(2); // Quantity
                                columns.RelativeColumn(2); // Unit Price
                                columns.RelativeColumn(2); // Discount
                                columns.RelativeColumn(2); // Total
                            });

                            // Header with bottom border and column separators
                            table.Header(header =>
                            {
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("SKU").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Product").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Description").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Qty").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Price").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Discount").Bold();
                                header.Cell().BorderBottom(1).BorderColor(Colors.Grey.Medium).Text("Total").Bold();
                            });

                            // Rows with borders between rows and columns
                            foreach (DataGridViewRow row in cart.Rows)
                            {
                                if (row.IsNewRow) continue;

                                // First 6 columns with right border
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(row.Cells["Sku"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(row.Cells["Name"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(row.Cells["Description"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(row.Cells["Quantity"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(row.Cells["Price"]?.Value?.ToString());
                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(row.Cells["Discount"]?.Value?.ToString());
                                // Last column without right border
                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignRight().Text(row.Cells["Total"]?.Value?.ToString());
                            }
                        });

                        content.Item().Element(e =>
                            e.PaddingTop(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Summary
                        content.Item().AlignRight().Column(summary =>
                        {
                            summary.Item().Text($"Total: Rs. {totalAmount:N2}").FontSize(14).Bold();
                            summary.Item().Text($"Paid: Rs. {paidAmount:N2}").FontSize(13);
                            summary.Item().Text($"Pending: Rs. {(totalAmount - paidAmount):N2}").FontSize(13).FontColor(Colors.Red.Medium);
                        });
                    });
                });
            }).GeneratePdf(filePath);
        }





        public static void PrintInvoiceDirectly(DataGridView cart, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount)
        {
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printers are installed on this system.", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                DrawInvoice(e, cart, customerName, saleDate, totalAmount, paidAmount);
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
                MessageBox.Show("Invoice sent to printer.", "Printed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private static void DrawInvoice(PrintPageEventArgs e, DataGridView cart, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 11);
            Pen borderPen = new Pen(System.Drawing.Color.Gray, 0.5f);
            Brush brush = Brushes.Black;

            float x = 50, y = 60;
            float pageWidth = e.PageBounds.Width - 100;

            // Logo (if exists)
            try
            {
                System.Drawing.Image logo = System.Drawing.Image.FromFile("logo.png");
                e.Graphics.DrawImage(logo, x, y, 100, 50);
            }
            catch { }

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

            // Invoice Details
            e.Graphics.DrawString("Sales Invoice", titleFont, brush, x + 250, y);
            y += 30;
            e.Graphics.DrawString($"Customer: {customerName}", regularFont, brush, x, y);
            y += 20;
            e.Graphics.DrawString($"Date: {saleDate.ToShortDateString()}", regularFont, brush, x, y);
            y += 25;

            // Table Header
            string[] headers = { "SKU", "Product", "Description", "Qty", "Price", "Discount", "Total" };
            float[] widths = { 70, 120, 140, 50, 70, 70, 80 };
            float tableX = x;
            float rowHeight = 25;

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
            row.Cells["Sku"]?.Value?.ToString(),
            row.Cells["Name"]?.Value?.ToString(),
            row.Cells["Description"]?.Value?.ToString(),
            row.Cells["Quantity"]?.Value?.ToString(),
            row.Cells["Price"]?.Value?.ToString(),
            row.Cells["Discount"]?.Value?.ToString(),
            row.Cells["Total"]?.Value?.ToString()
        };

                tableX = x;
                for (int i = 0; i < values.Length; i++)
                {
                    e.Graphics.DrawRectangle(borderPen, tableX, y, widths[i], rowHeight);
                    e.Graphics.DrawString(values[i], regularFont, brush, new RectangleF(tableX + 3, y + 5, widths[i] - 6, rowHeight - 6));
                    tableX += widths[i];
                }

                y += rowHeight;

                // Page break
                if (y + rowHeight > e.PageBounds.Height - 100)
                {
                    e.HasMorePages = true;
                    return;
                }
            }

            y += 10;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + pageWidth, y);
            y += 10;

            // Summary
            e.Graphics.DrawString($"Total: Rs. {totalAmount:N2}", headerFont, brush, x + 400, y);
            y += 20;
            e.Graphics.DrawString($"Paid: Rs. {paidAmount:N2}", regularFont, brush, x + 400, y);
            y += 20;
            e.Graphics.DrawString($"Pending: Rs. {(totalAmount - paidAmount):N2}", regularFont, Brushes.Red, x + 400, y);
        }

        public static void PrintThermalReceipt(DataGridView cart, string customerName, decimal total, decimal paid)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Receipt", 280, 600); // Width: ~80mm

            doc.PrintPage += (sender, e) =>
            {
                DrawThermalReceipt(e, cart, customerName, total, paid);
            };

            PrintDialog dialog = new PrintDialog
            {
                Document = doc,
                AllowSomePages = false,
                UseEXDialog = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private static void DrawThermalReceipt(PrintPageEventArgs e, DataGridView cart, string customerName, decimal total, decimal paid)
        {
            Font font = new Font("Consolas", 9);
            float y = 10;
            float lineHeight = font.GetHeight(e.Graphics) + 2;
            float leftMargin = 5;

            float maxWidth = e.PageBounds.Width - 10;

            float x = leftMargin;

            // Header
            e.Graphics.DrawString("------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Item        Qty  Price  Disc   Total", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;

            decimal totalDiscount = 0;

            foreach (DataGridViewRow row in cart.Rows)
            {
                if (row.IsNewRow) continue;

                string item = Truncate(row.Cells["Name"].Value?.ToString(), 10).PadRight(10);
                string qty = row.Cells["Quantity"].Value?.ToString().PadLeft(3);
                string price = row.Cells["Price"].Value?.ToString().PadLeft(6);
                string discount = row.Cells["Discount"].Value?.ToString().PadLeft(6);
                string totalPrice = row.Cells["Total"].Value?.ToString().PadLeft(6);

                decimal discVal = 0;
                decimal.TryParse(row.Cells["Discount"].Value?.ToString(), out discVal);
                totalDiscount += discVal * Convert.ToInt32(row.Cells["Quantity"].Value);

                string line = $"{item} {qty} {price} {discount} {totalPrice}";
                e.Graphics.DrawString(line, font, Brushes.Black, x, y); y += lineHeight;
            }

            e.Graphics.DrawString("------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;

            decimal due = total - paid;

            // Summary
            e.Graphics.DrawString($"Total Price    : Rs. {total:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Total Discount : Rs. {totalDiscount:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Paid           : Rs. {paid:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Due            : Rs. {due:N0}", font, Brushes.Black, x, y); y += lineHeight;

            e.Graphics.DrawString("------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("  Thank you for shopping with us!", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("------------------------------------------", font, Brushes.Black, x, y);
        }

        // Helper to truncate long product names
        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }


    }
}