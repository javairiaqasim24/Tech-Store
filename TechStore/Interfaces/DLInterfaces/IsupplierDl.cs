using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;

namespace TechStore.Interfaces.DLInterfaces
{
    public interface IsupplierDl
    {
        bool addsupplier(Supplier s);
        bool updatesupplier(Supplier s);
        bool deletesupplier(int id);
            List<Supplier> getsuppliers();
        List<string> getsuppliernames(string name);
        List<Supplier> searchsuppliers(string text);
    }
}
