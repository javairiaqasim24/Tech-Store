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

            var mainForm = ServiceProvider.GetRequiredService<Customersale>();
            Application.Run(mainForm);
        }
        public static void configureServices(IServiceCollection services)
        {
            //DL
            services.AddScoped<IproductDl, ProductDL>();
            services.AddScoped<IsupplierDl, SupplierDl>();
            services.AddScoped<Icustomersaledl, Customersaledl>();

            //BL
            services.AddScoped<TechStore.Interfaces.BLInterfaces.IproductBl, TechStore.BL.BL.ProductBL>();
            services.AddScoped<IPersonFactory, PersonFactory>();
            services.AddScoped<ISupplierBL, SupplierBl>();
            services.AddScoped<ICustomerSaleBL, CustomerSaleBL>();

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


        }
    }
}
