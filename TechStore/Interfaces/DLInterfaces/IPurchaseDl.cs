using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TechStore.Interfaces.DLInterfaces
{
    internal interface IPurchaseDl
    {
        void CreateSaleInvoicePdf(DataGridView cart, string filePath, string Name, DateTime saleDate);
       
        DataTable GetProducts();


    }
}
