using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Data;
using System.Windows.Forms;

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
                        content.Item().Text("Sales Invoice").FontSize(20).Bold().AlignCenter();
                        content.Item().Text($"Customer: {customerName}").FontSize(14);
                        content.Item().Text($"Date: {saleDate.ToShortDateString()}").FontSize(12);
                        content.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        content.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.RelativeColumn(2); // SKU
                                columns.RelativeColumn(3); // Product Name
                                columns.RelativeColumn(2); // Quantity
                                columns.RelativeColumn(2); // Unit Price
                                columns.RelativeColumn(2); // Discount
                                columns.RelativeColumn(2); // Total
                            });

                            // Header
                            table.Header(header =>
                            {
                                header.Cell().Element(c => CellStyle(c)).Text("SKU").Bold();
                                header.Cell().Element(c => CellStyle(c)).Text("Product").Bold();
                                header.Cell().Element(c => CellStyle(c)).Text("Qty").Bold();
                                header.Cell().Element(c => CellStyle(c)).Text("Price").Bold();
                                header.Cell().Element(c => CellStyle(c)).Text("Discount").Bold();
                                header.Cell().Element(c => CellStyle(c)).Text("Total").Bold();
                            });

                            // Rows
                            foreach (DataGridViewRow row in cart.Rows)
                            {
                                if (row.IsNewRow) continue;

                                table.Cell().Element(c => c.Padding(5)).Text(row.Cells["Sku"]?.Value?.ToString());
                                table.Cell().Element(c => c.Padding(5)).Text(row.Cells["Name"]?.Value?.ToString());
                                table.Cell().Element(c => c.Padding(5)).AlignCenter().Text(row.Cells["Quantity"]?.Value?.ToString());
                                table.Cell().Element(c => c.Padding(5)).AlignCenter().Text(row.Cells["Price"]?.Value?.ToString());
                                table.Cell().Element(c => c.Padding(5)).AlignCenter().Text(row.Cells["Discount"]?.Value?.ToString());
                                table.Cell().Element(c => c.Padding(5)).AlignRight().Text(row.Cells["Total"]?.Value?.ToString());
                            }
                        });

                        content.Item().PaddingTop(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

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

        private static IContainer CellStyle(IContainer container)
        {
            return container
                .Padding(5)
                .Background(Colors.Grey.Lighten3)
                .BorderBottom(1)
                .AlignCenter();
        }
    }
}
