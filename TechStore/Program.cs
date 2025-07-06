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
namespace TechStore
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            

            var services = new ServiceCollection();
            configureServices(services);
            ServiceProvider = services.BuildServiceProvider();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var mainForm = ServiceProvider.GetRequiredService<Supplierbillsform>();

            Application.Run(mainForm);
        }
        public static void configureServices(IServiceCollection services)
        {
            //DL
            services.AddScoped<IproductDl, ProductDL>();
            services.AddScoped<IsupplierDl, SupplierDl>();
            services.AddScoped<Icustomersaledl, Customersaledl>();
            services.AddScoped<ICustomerDL, CustomerDL>();
            services.AddScoped<IBatchesDl, BatchesDl>();
            services.AddScoped<IBatchdetailsDl, BatchdetailsDl>();
            services.AddScoped<ISupplierbillDl, SupplierbillDl>();
            services.AddScoped<IInventorylogDl,InventorylogDl>();
            services.AddScoped<IPurchaseDl, purchaseDL>();
            services.AddScoped<ISbilldetailsDl,SbilldetailsDl>();


            //BL
            services.AddScoped<IproductBl, ProductBL>();
            services.AddScoped<ISupplierBL, SupplierBl>();
            services.AddScoped<ICustomerSaleBL, CustomerSaleBL>();
            services.AddScoped<ICustomerBL, CustomerBL>();
            services.AddScoped<IBatchesBl, BatchesBl>();
            services.AddScoped<IBatchDetailsBL, BatchDetailsBL>();
            services.AddScoped<ISupplierBillBl, SupplierBillBl>();
            services.AddScoped<IInventorylogBl, InventorylogBl>();
            services.AddScoped<IsbilldetailsBl, SbilldetailsBl>();





            //forms
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

        }
    }
}







