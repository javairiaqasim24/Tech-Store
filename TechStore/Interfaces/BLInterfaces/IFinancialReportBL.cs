using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.BLInterfaces
{
    public interface IFinancialReportBL
    {
        FinancialReportModel GetMonthlyReport(int month, int year);
        FinancialReportModel GetYearlyReport(int year);
    }

}
