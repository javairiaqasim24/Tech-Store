using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;

namespace TechStore.BL.BL
{
    public class FinancialReportBL : IFinancialReportBL
    {
        private readonly IFinancialReportDL _financialDL;

        public FinancialReportBL(IFinancialReportDL financialDL)
        {
            _financialDL = financialDL;
        }

        public FinancialReportModel GetMonthlyReport(int month, int year)
        {
            return _financialDL.FetchReport(month, year);
        }

        public FinancialReportModel GetYearlyReport(int year)
        {
            return _financialDL.FetchReport(null, year);
        }
    }

}
