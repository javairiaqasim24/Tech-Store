using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.BL.Models.Person;

namespace TechStore.Interfaces.BLInterfaces
{
    public interface ISupplierBL
    {
        bool addsupplier(persons s);
        bool updatesupplier(persons s);
        bool deletesupplier(int id);
        List<persons> getsuppliers();
        List<string> getsuppliernames(string name);
        List<persons> searchsuppliers(string text);

    }
}
