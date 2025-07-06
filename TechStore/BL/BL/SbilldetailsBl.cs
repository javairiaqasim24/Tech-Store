using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;
using TechStore.Interfaces;

namespace TechStore.BL.BL
{
    public class SbilldetailsBl : IsbilldetailsBl
    {
        private readonly ISbilldetailsDl ibl;
        public SbilldetailsBl(ISbilldetailsDl ibl)
        {
            this.ibl = ibl;
        }
        public bool addrecord(Spricerecord s)
        {
            if (s.payement <= 0)
            {
                throw new ArgumentException("Payement should be greater than zero");
            }
           return ibl.addrecord(s);
        }

        public List<Supplierpayment> getdetails(int billid)
        {
            return ibl.getdetails(billid);  
        }
    }
}
