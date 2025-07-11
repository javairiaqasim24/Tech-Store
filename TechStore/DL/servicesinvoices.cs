using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KIMS;
using MySql.Data.MySqlClient;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace TechStore.DL
{
    internal class servicesinvoices
    {

        public static Stream GetLogoImageStream()
        {
            var image = Properties.Resources.logo; // This is a System.Drawing.Image


            var ms = new MemoryStream();
            image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            ms.Position = 0; // Reset stream position
            return ms;
        }

        public static void CreateServiceReceiptPdf(string filePath, string customerName, string itemName, string description, DateTime receivingDate, DateTime deliveryDate , int serviceId)
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
                        column.Item().AlignCenter().Image(GetLogoImageStream(), ImageScaling.FitWidth);
                        column.Item().AlignCenter().Text("MNS Computers").Bold().FontSize(12);
                        column.Item().AlignCenter().Text("Service Receipt").Bold();
                        column.Item().AlignCenter().Text("Sitiana Road, Faisalabad");
                        column.Item().AlignCenter().Text("0300-6634245");
                        column.Item().PaddingBottom(5).LineHorizontal(0.5f);

                        column.Item().Text($"Date: {DateTime.Now:dd-MMM-yyyy hh:mm tt}");
                        column.Item().Text($"Service ID: {serviceId}");
                        column.Item().Text($"Customer: {customerName}");
                        column.Item().PaddingBottom(5).LineHorizontal(0.5f);
                        column.Item().Text($"Item: {itemName}");
                        column.Item().Text($"Description: {description}");
                        column.Item().Text($"Receiving: {receivingDate:dd-MMM-yyyy}");
                        column.Item().Text($"Delivery: {deliveryDate:dd-MMM-yyyy}");

                        column.Item().PaddingBottom(5).LineHorizontal(0.5f);
                        column.Item().AlignCenter().Text("We will notify you when the repair is done.");
                        column.Item().AlignCenter().Text("Thanks for trusting MNS Computers!");
                        //column.Item().PaddingTop(5).AlignCenter().Text($"Invoice #: SRV-{DateTime.Now:yyMMddHHmm}");
                        column.Item().PaddingTop(5).AlignCenter().Text("Developed by:");
                        column.Item().AlignCenter().Text("abdulahad18022@gmail.com");
                    });
                });
            }).GeneratePdf(filePath);
        }

        public static int InsertServiceAndReturnId(int customerId, string itemName, string description, DateTime receiveDate, DateTime deliveryDate)
        {
            string query = @"INSERT INTO service_line (customer_id, nameofitem, description, recievedate, deliverydate)
                     VALUES (@customer_id, @item, @desc, @rec, @deliv);
                     SELECT LAST_INSERT_ID();";

            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customer_id", customerId);
                    cmd.Parameters.AddWithValue("@item", itemName);
                    cmd.Parameters.AddWithValue("@desc", description);
                    cmd.Parameters.AddWithValue("@rec", receiveDate);
                    cmd.Parameters.AddWithValue("@deliv", deliveryDate);

                    // This will return the new service_id
                    object result = cmd.ExecuteScalar();
                    return Convert.ToInt32(result);
                }
            }
        }


    }
}
