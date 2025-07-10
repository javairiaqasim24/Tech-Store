using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.DLInterfaces
{
    public interface IFinancialReportDL
    {
        FinancialReportModel FetchReport(int? month, int year);
    }

}
