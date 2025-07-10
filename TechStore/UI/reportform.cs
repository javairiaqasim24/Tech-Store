using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Drawing;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.UI
{
    public partial class reportform : Form
    {
        private readonly IFinancialReportBL financialReportBL;

        public reportform(IFinancialReportBL financialReportBL)
        {
            InitializeComponent();
            QuestPDF.Settings.License = LicenseType.Community;

            this. financialReportBL =financialReportBL;
        }

        private void btnmonth_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpdate.Value;
            int month = selectedDate.Month;
            int year = selectedDate.Year;

            var report = financialReportBL.GetMonthlyReport(month, year);
            string title = $"Monthly Financial Report - {selectedDate:MMMM yyyy}";
            string fileName = $"Monthly_Report_{month}_{year}.pdf";

            GeneratePdfReport(report, title, fileName);
        }

        private void btnyear_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dtpdate.Value;
            int year = selectedDate.Year;

            var report = financialReportBL.GetYearlyReport(year);
            string title = $"Yearly Financial Report - {year}";
            string fileName = $"Yearly_Report_{year}.pdf";

            GeneratePdfReport(report, title, fileName);
        }

        private void GeneratePdfReport(FinancialReportModel report, string title, string filename)
        {
            var document = new FinancialReportDocument(report, title);

            // Save dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF files (*.pdf)|*.pdf";
                saveFileDialog.FileName = filename;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    document.GeneratePdf(saveFileDialog.FileName);
                    MessageBox.Show("PDF report generated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

    }
    public class FinancialReportDocument : IDocument
    {
        private readonly FinancialReportModel report;
        private readonly string title;

        public FinancialReportDocument(FinancialReportModel report, string title)
        {
            this.report = report;
            this.title = title;
        }

        // ✅ REQUIRED for QuestPDF v2024+
        public DocumentSettings GetSettings() => new DocumentSettings();

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container.Page(page =>
            {
                page.Size(PageSizes.A4);
                page.Margin(30);
                page.DefaultTextStyle(x => x.FontSize(11).FontFamily("Helvetica"));

                var primaryColor = "#123458"; // Your brand color

                page.Header().PaddingBottom(20).Row(row =>
                {
                    row.RelativeItem().AlignLeft().Text("TechStore")
                        .FontSize(20).Bold().FontColor(primaryColor);

                    row.RelativeItem().AlignRight().Text(title)
                        .FontSize(14).SemiBold().FontColor(Colors.Grey.Darken3);
                });

                page.Content().Column(col =>
                {
                    col.Spacing(15);

                    col.Item().Text("Summary")
                        .FontSize(14).Bold().FontColor(primaryColor);

                    col.Item().Row(row =>
                    {
                        row.Spacing(15);

                        row.RelativeItem().Background(Colors.Grey.Lighten4).Padding(12).Column(c =>
                        {
                            c.Item().Text("Total Revenue").SemiBold();
                            c.Item().Text($"PKR {report.TotalRevenue:N0}").FontSize(12);
                        });

                        row.RelativeItem().Background(Colors.Grey.Lighten4).Padding(12).Column(c =>
                        {
                            c.Item().Text("Total Purchases").SemiBold();
                            c.Item().Text($"PKR {report.TotalPurchases:N0}").FontSize(12);
                        });
                    });

                    col.Item().Row(row =>
                    {
                        row.Spacing(15);

                        row.RelativeItem().Background("#d0f5d8").Padding(12).Column(c =>
                        {
                            c.Item().Text("Gross Profit").SemiBold();
                            c.Item().Text($"PKR {report.GrossProfit:N0}").FontSize(12);
                        });
                    });

                    col.Item().Text("Customer Transactions")
                        .FontSize(14).Bold().FontColor(primaryColor);

                    col.Item().Row(row =>
                    {
                        row.Spacing(15);

                        row.RelativeItem().Background(Colors.Indigo.Lighten5).Padding(12).Column(c =>
                        {
                            c.Item().Text("Received").SemiBold();
                            c.Item().Text($"PKR {report.CustomerReceived:N0}").FontSize(12);
                        });

                        row.RelativeItem().Background(Colors.Red.Lighten4).Padding(12).Column(c =>
                        {
                            c.Item().Text("Dues").SemiBold();
                            c.Item().Text($"PKR {report.CustomerDues:N0}").FontSize(12);
                        });
                    });

                    col.Item().Text("Supplier Transactions")
                        .FontSize(14).Bold().FontColor(primaryColor);

                    col.Item().Row(row =>
                    {
                        row.Spacing(15);

                        row.RelativeItem().Background(Colors.Indigo.Lighten5).Padding(12).Column(c =>
                        {
                            c.Item().Text("Paid").SemiBold();
                            c.Item().Text($"PKR {report.SupplierPaid:N0}").FontSize(12);
                        });

                        row.RelativeItem().Background(Colors.Red.Lighten4).Padding(12).Column(c =>
                        {
                            c.Item().Text("Dues").SemiBold();
                            c.Item().Text($"PKR {report.SupplierDues:N0}").FontSize(12);
                        });
                    });

                    col.Item().PaddingTop(20).AlignRight().Text($"Generated on: {DateTime.Now:dd MMM yyyy hh:mm tt}")
                        .FontSize(9).Italic().FontColor(Colors.Grey.Darken1);
                });

                page.Footer().AlignCenter().PaddingTop(10).Text("TechStore Financial Report")
                    .FontSize(9)
                    .FontColor(Colors.Grey.Darken2);
            });
        }

    }



}
