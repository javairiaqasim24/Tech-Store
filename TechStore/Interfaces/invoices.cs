
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web.UI.WebControls.WebParts;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TechStore.DL
{
    public class invoices
    {

        public static Stream GetLogoImageStream()
        {
            var image = Properties.Resources.logo; // This is a System.Drawing.Image


            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0; // Reset stream position
            return ms;
        }


        public static void CreateSaleInvoicePdf(DataGridView cart, string filePath, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount, int billid)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12).FontFamily("Consolas"));

                    page.Content().Column(content =>
                    {
                        // Header with logo and info
                        content.Item().Row(row =>
                        {
                            row.RelativeItem(1).Column(col =>
                            {
                                col.Item().Image(GetLogoImageStream(), ImageScaling.FitWidth);
                            });

                            row.RelativeItem(3).Column(col =>
                            {
                                col.Item().AlignRight().Text("Tech Store").FontSize(22).Bold();
                                col.Item().AlignRight().Text("123 Market Road, CityName").FontSize(10);
                                col.Item().AlignRight().Text("Phone: +92-300-1234567").FontSize(10);
                                col.Item().AlignRight().Text("Email: support@techstore.com").FontSize(10);
                            });
                        });

                        content.Item().PaddingTop(5).AlignRight().Text($"Bill ID: {billid}").FontSize(12).FontColor(Colors.Blue.Medium);

                        content.Item().Element(e =>
                            e.PaddingVertical(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Invoice info
                        content.Item().AlignCenter().Text("Sales Invoice").FontSize(20).Bold();
                        content.Item().Text($"Customer: {customerName}").FontSize(14);
                        content.Item().Text($"Date: {saleDate.ToShortDateString()}").FontSize(12);

                        content.Item().Element(e =>
                            e.PaddingVertical(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        // Cart table
                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2); // SKU
                                columns.RelativeColumn(3); // Product Name
                                columns.RelativeColumn(2); // Warranty
                                columns.RelativeColumn(3); // Description
                                columns.RelativeColumn(2); // Quantity
                                columns.RelativeColumn(2); // Unit Price
                                columns.RelativeColumn(2); // Discount
                                columns.RelativeColumn(2); // Total
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("SKU").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Product").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Warranty").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Description").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Qty").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Price").Bold();
                                header.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Medium).Text("Discount").Bold();
                                header.Cell().BorderBottom(1).BorderColor(Colors.Grey.Medium).Text("Total").Bold();
                            });

                            foreach (DataGridViewRow row in cart.Rows)
                            {
                                if (row.IsNewRow) continue;

                                string sku = row.Cells["Sku"]?.Value?.ToString() ?? "";
                                string name = row.Cells["Name"]?.Value?.ToString() ?? "";
                                string warranty = row.Cells["Warranty"]?.Value?.ToString() ?? "N/A";
                                string description = row.Cells["Description"]?.Value?.ToString() ?? "";
                                string qty = row.Cells["Quantity"]?.Value?.ToString() ?? "0";
                                string price = row.Cells["Price"]?.Value?.ToString() ?? "0";
                                string discount = row.Cells["Discount"]?.Value?.ToString() ?? "0";
                                string total = row.Cells["Total"]?.Value?.ToString() ?? "0";

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(sku).WrapAnywhere().FontSize(10); // wrapped inside the cell

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(name).WrapAnywhere().FontSize(10); // wrapped inside the cell

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(warranty);

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .Text(description).WrapAnywhere().FontSize(11);

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(qty);

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(price);

                                table.Cell().BorderBottom(1).BorderRight(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignCenter().Text(discount);

                                table.Cell().BorderBottom(1).BorderColor(Colors.Grey.Lighten2)
                                    .AlignRight().Text(total);
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

        // Helper method
        public static IEnumerable<string> WrapText(string text, int maxChars)
        {
            for (int i = 0; i < text.Length; i += maxChars)
                yield return text.Substring(i, Math.Min(maxChars, text.Length - i));
        }





        public static void PrintInvoiceDirectly(DataGridView cart, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount, int billid)
        {
            if (PrinterSettings.InstalledPrinters.Count == 0)
            {
                MessageBox.Show("No printers are installed on this system.", "Printer Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            PrintDocument printDoc = new PrintDocument();
            printDoc.PrintPage += (sender, e) =>
            {
                DrawInvoice(e, cart, customerName, saleDate, totalAmount, paidAmount,billid);
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


        private static void DrawInvoice(PrintPageEventArgs e, DataGridView cart, string customerName, DateTime saleDate, decimal totalAmount, decimal paidAmount, int billid)
        {
            Font titleFont = new Font("Arial", 18, FontStyle.Bold);
            Font headerFont = new Font("Arial", 12, FontStyle.Bold);
            Font regularFont = new Font("Arial", 11);
            Pen borderPen = new Pen(System.Drawing.Color.Gray, 0.5f);
            Brush brush = Brushes.Black;

            float x = 50, y = 60;
            float pageWidth = e.PageBounds.Width - 100;

            StringFormat wrapFormat = new StringFormat
            {
                FormatFlags = StringFormatFlags.LineLimit,
                Trimming = StringTrimming.Word
            };

            // Draw logo from resources
            System.Drawing.Image logo = Properties.Resources.logoo;
            e.Graphics.DrawImage(logo, x, y, 100, 50);

            // Company Info
            e.Graphics.DrawString("MNS Computers", titleFont, brush, x + 400, y);
            y += 25;
            e.Graphics.DrawString("123 Market Road, CityName", regularFont, brush, x + 400, y);
            y += 18;
            e.Graphics.DrawString("Phone: +92-300-1234567", regularFont, brush, x + 400, y);
            y += 18;
            e.Graphics.DrawString("Email: support@techstore.com", regularFont, brush, x + 400, y);

            y += 40;
            e.Graphics.DrawLine(Pens.Gray, x, y, x + pageWidth, y);
            y += 10;

            // Invoice Info
            e.Graphics.DrawString("Sales Invoice", titleFont, brush, x + 250, y);
            y += 30;
            e.Graphics.DrawString($"Bill ID: {billid}", regularFont, brush, x, y);
            y += 20;
            e.Graphics.DrawString($"Customer: {customerName}", regularFont, brush, x, y);
            y += 20;
            e.Graphics.DrawString($"Date: {saleDate.ToShortDateString()}", regularFont, brush, x, y);
            y += 25;

            // Table Header
            string[] headers = { "SKU", "Product", "Description", "Qty", "Price", "Discount", "Warranty", "Total" };
            float[] widths = { 100, 130, 170, 40, 65, 65, 45, 70 }; // Adjust widths for 8 columns
            float tableX = x;
            float rowHeight = 25;

            for (int i = 0; i < headers.Length; i++)
            {
                e.Graphics.FillRectangle(Brushes.LightGray, tableX, y, widths[i], rowHeight);
                e.Graphics.DrawRectangle(borderPen, tableX, y, widths[i], rowHeight);
                e.Graphics.DrawString(headers[i], headerFont, brush, new RectangleF(tableX + 3, y + 5, widths[i] - 6, rowHeight - 6), wrapFormat);
                tableX += widths[i];
            }

            y += rowHeight;

            // Table Rows
            foreach (DataGridViewRow row in cart.Rows)
            {
                if (row.IsNewRow) continue;

                string[] values =
                {
            row.Cells["Sku"]?.Value?.ToString() ?? "",
            row.Cells["Name"]?.Value?.ToString() ?? "",
            row.Cells["Description"]?.Value?.ToString() ?? "",
            row.Cells["Quantity"]?.Value?.ToString() ?? "",
            row.Cells["Price"]?.Value?.ToString() ?? "",
            row.Cells["Discount"]?.Value?.ToString() ?? "",
            row.Cells["Warranty"]?.Value?.ToString() ?? "",
            row.Cells["Total"]?.Value?.ToString() ?? ""
        };

                tableX = x;
                float maxRowHeight = rowHeight;

                // Calculate required row height based on wrapped content
                for (int i = 0; i < values.Length; i++)
                {
                    SizeF size = e.Graphics.MeasureString(values[i], regularFont, (int)widths[i], wrapFormat);
                    float neededHeight = size.Height + 10;
                    if (neededHeight > maxRowHeight)
                        maxRowHeight = neededHeight;
                }

                // Draw wrapped cells
                for (int i = 0; i < values.Length; i++)
                {
                    e.Graphics.DrawRectangle(borderPen, tableX, y, widths[i], maxRowHeight);
                    e.Graphics.DrawString(values[i], regularFont, brush, new RectangleF(tableX + 3, y + 5, widths[i] - 6, maxRowHeight - 6), wrapFormat);
                    tableX += widths[i];
                }

                y += maxRowHeight;

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



        public static void PrintThermalReceipt(DataGridView cart, string customerName, decimal total, decimal paid, int billid)
        {
            PrintDocument doc = new PrintDocument();
            doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Receipt", 280, 600); // Width: ~80mm

            doc.PrintPage += (sender, e) =>
            {
                DrawThermalReceipt(e, cart, customerName, total, paid, billid);
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

        //public static void PrintThermalReceipt(DataGridView cart, string customerName, decimal total, decimal paid, int billid)
        //{
        //    PrintDocument doc = new PrintDocument();

        //    // Set to 80mm paper size (width: ~280, height can be dynamic)
        //    doc.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("Receipt", 280, 600);

        //    // Optional: Set the specific printer if needed
        //    // doc.PrinterSettings.PrinterName = "Black Copper BC-85AC";

        //    doc.PrintPage += (sender, e) =>
        //    {
        //        DrawThermalReceipt(e, cart, customerName, total, paid, billid);
        //    };

        //    // 🔥 Direct print — no dialog shown
        //    if (doc.PrinterSettings.IsValid)
        //        doc.Print();
        //    else
        //        MessageBox.Show("No valid printer found.");
        //}


        private static void DrawThermalReceipt(PrintPageEventArgs e, DataGridView cart, string customerName, decimal total, decimal paid, int billid)
        {
            Font font = new Font("Consolas", 9);
            float y = 10;
            float lineHeight = font.GetHeight(e.Graphics) + 2;
            float pageWidth = e.PageBounds.Width;
            float leftMargin = 5;
            float x = leftMargin;

            // --- Logo ---
            try
            {
                System.Drawing.Image logo = Properties.Resources.logoo; // From resources
                int logoWidth = 100;
                int logoHeight = 50;
                float centerX = (pageWidth - logoWidth) / 2;
                e.Graphics.DrawImage(logo, centerX, y, logoWidth, logoHeight);
                y += logoHeight + 5;
                logo.Dispose();
            }
            catch
            {
                e.Graphics.DrawString("MNS Computers", new Font("Consolas", 12, FontStyle.Bold), Brushes.Black, x, y);
                y += lineHeight + 10;
            }

            // --- Header ---
            e.Graphics.DrawString("office # 39 & 40, 1st floor Gallery 3, Rex city, Sitiana Road", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Phone: 0300-6634245", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Invoice ID     : #{billid}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Customer       : {customerName}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Date           : {DateTime.Now:dd-MMM-yyyy hh:mm tt}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("------------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Item         Qty War Price Disc Total", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("------------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;

            // --- Cart Items ---
            decimal totalDiscount = 0;

            foreach (DataGridViewRow row in cart.Rows)
            {
                if (row.IsNewRow) continue;

                string name = row.Cells["Name"].Value?.ToString() ?? "";
                string qty = row.Cells["Quantity"].Value?.ToString()?.PadLeft(2);
                string warranty = Truncate(row.Cells["Warranty"].Value?.ToString(), 3).PadRight(3);
                string price = row.Cells["Price"].Value?.ToString()?.PadLeft(5);
                string discount = row.Cells["Discount"].Value?.ToString()?.PadLeft(4);
                string totalPrice = row.Cells["Total"].Value?.ToString()?.PadLeft(6);

                decimal.TryParse(row.Cells["Discount"].Value?.ToString(), out decimal discVal);
                totalDiscount += discVal * Convert.ToInt32(row.Cells["Quantity"].Value);

                string headerLine = $"{qty} {warranty} {price} {discount} {totalPrice}";

                int maxNameWidth = 140; // Adjust based on font and paper
                List<string> wrappedName = WrapText(name, font, e.Graphics, maxNameWidth);

                // First line with item + columns
                if (wrappedName.Count > 0)
                {
                    string line = wrappedName[0].PadRight(12).Substring(0, Math.Min(12, wrappedName[0].Length)) + " " + headerLine;
                    e.Graphics.DrawString(line, font, Brushes.Black, x, y); y += lineHeight;

                    // Rest of the name on new lines
                    for (int i = 1; i < wrappedName.Count; i++)
                    {
                        e.Graphics.DrawString(wrappedName[i], font, Brushes.Black, x + 10, y);
                        y += lineHeight;
                    }
                }
                else
                {
                    string line = $"{name,-12}{qty} {warranty} {price} {discount} {totalPrice}";
                    e.Graphics.DrawString(line, font, Brushes.Black, x, y);
                    y += lineHeight;
                }
            }

            e.Graphics.DrawString("------------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;

            decimal due = total - paid;

            // --- Summary ---
            e.Graphics.DrawString($"Subtotal       : Rs. {total + totalDiscount:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Discount        : Rs. {totalDiscount:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Total           : Rs. {total:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Paid            : Rs. {paid:N0}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Due             : Rs. {due:N0}", font, Brushes.Black, x, y); y += lineHeight;

            // --- Footer ---
            e.Graphics.DrawString("------------------------------------------------", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("   Thank you for your business!", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Free diagnostics with any repair", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("10% discount on next purchase", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Ask about our warranty plans!", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString($"Invoice #: INV-{DateTime.Now:yyMMddHHmm}", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("Powered By:", font, Brushes.Black, x, y); y += lineHeight;
            e.Graphics.DrawString("abdulahad18022@gmail.com", font, Brushes.Black, x, y); y += lineHeight;
        }

        private static List<string> WrapText(string text, Font font, Graphics g, int maxWidth)
        {
            List<string> lines = new List<string>();
            string[] words = text.Split(' ');
            string currentLine = "";

            foreach (string word in words)
            {
                string testLine = string.IsNullOrEmpty(currentLine) ? word : currentLine + " " + word;
                SizeF size = g.MeasureString(testLine, font);
                if (size.Width > maxWidth)
                {
                    if (!string.IsNullOrEmpty(currentLine))
                    {
                        lines.Add(currentLine);
                        currentLine = word;
                    }
                    else
                    {
                        lines.Add(word);
                        currentLine = "";
                    }
                }
                else
                {
                    currentLine = testLine;
                }
            }

            if (!string.IsNullOrEmpty(currentLine))
                lines.Add(currentLine);

            return lines;
        }



        // Helper to truncate long product names
        private static string Truncate(string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return "";
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        //fpr the generation of pdf of thernaml style format
        public static void CreateThermalReceiptPdf(DataGridView cart, string filePath, string customerName, decimal total, decimal paid)
        {
            QuestPDF.Settings.License = LicenseType.Community;

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(226, PageSizes.A4.Height, Unit.Point); // 80mm width
                    page.Margin(5);
                    page.DefaultTextStyle(x => x.FontFamily("Consolas").FontSize(9));

                    page.Content().Column(column =>
                    {
                        // --- Logo + Header ---
                        column.Item().AlignCenter().Image("logo.jpg", ImageScaling.FitWidth);
                        column.Item().AlignCenter().Text("MNS Computers").Bold().FontSize(12);
                        column.Item().AlignCenter().Text("office # 39 & 40, 1st floor Gallery 3, Rex city, Sitiana Road");
                        column.Item().AlignCenter().Text("Phone: 0300-6634245");
                        column.Item().PaddingBottom(5).LineHorizontal(0.5f);

                        // --- Invoice Info ---
                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Text($"Customer: {customerName}");
                            row.RelativeItem().AlignRight().Text($"{DateTime.Now:dd-MMM-yyyy hh:mm tt}");
                        });

                        column.Item().PaddingBottom(5).LineHorizontal(0.5f);

                        // --- Table Header ---
                        column.Item().Text("----------------------------------------");
                        column.Item().Text("ITEM         QTY WAR PRICE DISC TOTAL");
                        column.Item().Text("----------------------------------------");

                        // --- Cart Items ---
                        decimal totalDiscount = 0;
                        decimal subTotal = 0;

                        foreach (DataGridViewRow row in cart.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string name = row.Cells["Name"].Value?.ToString() ?? "";
                            string qty = row.Cells["Quantity"].Value?.ToString()?.PadLeft(2);
                            string war = Truncate(row.Cells["Warranty"]?.Value?.ToString(), 3).PadRight(3);
                            string price = row.Cells["Price"].Value?.ToString()?.PadLeft(5);
                            string discount = row.Cells["Discount"].Value?.ToString()?.PadLeft(3);
                            string totalPrice = row.Cells["Total"].Value?.ToString()?.PadLeft(6);

                            if (decimal.TryParse(row.Cells["Discount"].Value?.ToString(), out decimal discVal))
                                totalDiscount += discVal * Convert.ToInt32(row.Cells["Quantity"].Value);
                            if (decimal.TryParse(row.Cells["Total"].Value?.ToString(), out decimal itemTotal))
                                subTotal += itemTotal;

                            // Split name across lines
                            string[] nameParts = name.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
                            string firstWord = nameParts.Length > 0 ? nameParts[0] : name;
                            string[] remainingWords = nameParts.Skip(1).ToArray();

                            // First line with first word and all data
                            string firstLine = $"{firstWord,-12}{qty} {war} {price} {discount} {totalPrice}";
                            column.Item().Text(firstLine);

                            // Remaining words as new lines
                            foreach (var word in remainingWords)
                            {
                                column.Item().PaddingLeft(10).Text(word);
                            }
                        }

                        // --- Summary ---
                        column.Item().Text("----------------------------------------");
                        column.Item().Text($"SUBTOTAL:    Rs. {subTotal + totalDiscount:N0}");
                        column.Item().Text($"DISCOUNT:    Rs. {totalDiscount:N0}");
                        column.Item().Text($"TOTAL:       Rs. {total:N0}");
                        column.Item().Text($"PAID:        Rs. {paid:N0}");
                        column.Item().Text($"BALANCE:     Rs. {(total - paid):N0}");
                        column.Item().Text("----------------------------------------");

                        // --- Footer ---
                        column.Item().AlignCenter().Text("Thank you for your shopping here!").Bold();
                        column.Item().PaddingTop(5).LineHorizontal(0.5f);
                        column.Item().AlignCenter().Text("** SPECIAL OFFERS **").Bold();
                        column.Item().AlignCenter().Text("Free diagnostics with any repair");
                        column.Item().AlignCenter().Text("10% discount on next purchase");
                        column.Item().AlignCenter().Text("Ask about our warranty plans!");
                        column.Item().AlignCenter().Text($"Invoice #: INV-{DateTime.Now:yyMMddHHmm}");
                        column.Item().PaddingTop(5).AlignCenter().Text("Developed By:");
                        column.Item().PaddingTop(5).AlignCenter().Text("abdulahad18022@gmail.com");
                    });
                });
            }).GeneratePdf(filePath);
        }






    }
}