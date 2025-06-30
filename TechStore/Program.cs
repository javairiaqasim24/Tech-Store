using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.DL;
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

            var mainForm = ServiceProvider.GetRequiredService<Dashboard>();
            Application.Run(mainForm);
        }
        public static void configureServices(IServiceCollection services)
        {//DL
            services.AddScoped<IproductDl, ProductDL>();
            //BL
            services.AddScoped<TechStore.Interfaces.BLInterfaces.IproductBl, TechStore.BL.BL.ProductBL>();
            //forms
            services.AddTransient<HomeContentform>();
            services.AddTransient<Dashboard>();
            //services.AddScoped<Addproductform>();
            services.AddTransient<Inventoryform>();

        }
    }
}
  
