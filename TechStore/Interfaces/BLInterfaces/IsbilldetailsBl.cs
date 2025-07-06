using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces
{
     public interface IsbilldetailsBl
    {
        bool addrecord(Spricerecord s);
        List<Supplierpayment> getdetails(int billid);
    }
}
