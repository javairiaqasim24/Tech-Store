using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.BL.BL;
using TechStore.DL;
using TechStore.Interfaces;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;
using TechStore.UI;
using TechStore;
using TechStore.BL;
using TechStore.BL.Models;
using QuestPDF.Infrastructure;
using System.Web.UI.WebControls;
namespace TechStore
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var services = new ServiceCollection();
            configureServices(services);
            ServiceProvider = services.BuildServiceProvider();
            //var mainForm = ServiceProvider.GetRequiredService <servicesform>();


            // Show login first (Modal)
            //var login = ServiceProvider.GetRequiredService<UI.Login>();
            //var result = login.ShowDialog();

            //if (result == DialogResult.OK)
            //{
                // Run dashboard only after login passes
                Application.Run(ServiceProvider.GetRequiredService<Dashboard>());
            //}
        }




        public static void configureServices(IServiceCollection services)
        {
            services.AddScoped<IproductDl, ProductDL>();
            services.AddScoped<IsupplierDl, SupplierDl>();
            services.AddScoped<Icustomersaledl, Customersaledl>();
            services.AddScoped<ICustomerDL, CustomerDL>();
            services.AddScoped<IBatchesDl, BatchesDl>();
            services.AddScoped<IBatchdetailsDl, BatchdetailsDl>();
            services.AddScoped<ISupplierbillDl, SupplierbillDl>();
            services.AddScoped<IInventorylogDl,InventorylogDl>();
            services.AddScoped<IPurchaseDl, purchaseDL>();
            services.AddScoped<IInventoryDl,InventoryDl>();
            services.AddScoped<ISreturnsDl,SreturnsDl>();
            services.AddScoped<ISbilldetailsDl,SbilldetailsDl>();
            services.AddScoped<IFinancialReportDL, FinancialReportDL>();
            services.AddScoped<ICustomerserviceDl,CustomerserviceDl>();
            services.AddScoped<Iservice_partsDl,service_partsDl>();

            services.AddScoped<IproductBl, ProductBL>();
            services.AddScoped<ISupplierBL, SupplierBl>();
            services.AddScoped<ICustomerSaleBL, CustomerSaleBL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<IBatchesBl, BatchesBl>();
            services.AddScoped<IBatchDetailsBL, BatchDetailsBL>();
            services.AddScoped<ISupplierBillBl, SupplierBillBl>();
            services.AddScoped<IInventorylogBl, InventorylogBl>();
            services.AddScoped<IInventoryBl,InventoryBl>();
            services.AddScoped<IsreturnBl, SreturnBl>();
            services.AddScoped<IInventorylogBl, InventorylogBl>();
            services.AddScoped<IsbilldetailsBl,SbilldetailsBl>();
            services.AddScoped<Idashboard, Dashboardservice>();
            services.AddScoped<IFinancialReportBL,FinancialReportBL>();
            services.AddScoped<ICustomer_serviceBl, Customer_serviceBl>();
            services.AddScoped<IServicePartBl, ServicePartBl>();


            services.AddTransient<HomeContentform>();
            services.AddTransient<Dashboard>();
            services.AddTransient<addproductform>();
            services.AddTransient<productsform>();
            services.AddTransient<Supplierform>();
            services.AddTransient<Addsupplierform>();
            services.AddTransient<orders>();
            services.AddTransient<AddCustomerform>();
            services.AddTransient<Customerform>();
            services.AddTransient<Customersale>();
            services.AddTransient<AddBatchform>();
            services.AddTransient<Addcategoryform>();
            services.AddTransient<Loadingform>();
            services.AddTransient<BatchDetailsform>();
            services.AddTransient<AddbatchDetailsform>();
            services.AddTransient<Batchesform>();
            services.AddTransient<BillingRecordsOverview>();
            services.AddTransient<BillingRecordsOverviewBL>();
            services.AddTransient<BillingRecordsOverviewDL>();
            services.AddTransient<Inventorylogform>();
            services.AddTransient<PurchaseInvoice>();
            services.AddTransient<Customerreturns>();
            services.AddTransient<PurchaseInvoice>();
            services.AddTransient<CustomerBill_SpecificProducts>();
            services.AddTransient<Supplierbillsform>();
            services.AddTransient<Inventoryform>();
            services.AddTransient<Supplier_eturnsform>();
            services.AddTransient<DashboardDl>();
            services.AddTransient<UI .Login>();
            services.AddTransient<reportform>();
            services.AddTransient<logins>();
            services.AddTransient<serviceform>();
            services.AddTransient<Services>();
           

        }
    }
    public class CustomAppContext : ApplicationContext
    {
        public CustomAppContext(IServiceProvider provider)
        {
            var login = provider.GetRequiredService<UI.Login>();

            login.FormClosed += (s, e) =>
            {
                if (login.DialogResult == DialogResult.OK)
                {
                    var dashboard = provider.GetRequiredService<Dashboard>();
                    dashboard.FormClosed += (sd, ed) => ExitThread();
                    dashboard.Show();
                }
                else
                {
                    ExitThread(); // user closed login, exit
                }
            };

            login.Show();
        }
    }

    public class LoginApplicationContext : ApplicationContext
    {
        public bool IsAuthenticated { get; private set; } = false;

        public LoginApplicationContext(IServiceProvider provider)
        {
            var loginForm = provider.GetRequiredService<UI.Login>();
            loginForm.FormClosed += (s, e) =>
            {
                if (loginForm.DialogResult == DialogResult.OK)
                {
                    IsAuthenticated = true;
                }

                ExitThread(); // Ends the Application.Run loop
            };

            loginForm.Show();
        }
    }
}







