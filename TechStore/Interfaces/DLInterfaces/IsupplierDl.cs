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
        bool addsupplier(Ipersons s);
        bool updatesupplier(Ipersons s);
        bool deletesupplier(int id);
            List<Ipersons> getsuppliers();
        List<string> getsuppliernames(string name);
        List<Ipersons> searchsuppliers(string text);
    }
}
