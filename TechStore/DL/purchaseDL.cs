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

namespace TechStore.DL
{
    internal class purchaseDL
    {
        public static DataTable GetProducts()
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

        public static DataTable GetSuppliers()
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                string query = "SELECT name FROM suppliers";
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

        public static void CreateSaleInvoicePdf(DataGridView cart, string filePath, string Name, DateTime saleDate)
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
                                col.Item().Image("logoo.png", ImageScaling.FitWidth);
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

                        // Footer line
                        content.Item().Element(e =>
                            e.PaddingTop(10)
                             .LineHorizontal(1)
                             .LineColor(Colors.Grey.Lighten2)
                        );

                        content.Item().AlignCenter().Text("Thank you for your business!").FontSize(12).Italic();
                    });
                });
            }).GeneratePdf(filePath);
        }

    }
}
