using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TechStore.UI;

namespace TechStore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 1. Show splash screen
           

            // 2. Simulate loading (or load real data here)
            Dashboard mainForm = new Dashboard();

            // Optional: Give system time to paint (can replace with actual init logic)
          
            Application.Run(mainForm);
        }
    }

}
