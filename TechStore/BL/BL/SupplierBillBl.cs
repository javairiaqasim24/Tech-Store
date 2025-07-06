﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.BL.BL
{
    public class SupplierBillBl : ISupplierBillBl
    {
        private readonly ISupplierbillDl ibl;
        public SupplierBillBl(ISupplierbillDl ibl)
        {
            this.ibl = ibl;
        }
        public bool updateamount(Supplierbill b)
        {
            if(b.total_price<b.paid_price)
            {
                throw new ArgumentException("Total price canot be less than paid amount");
            }
            try
            {
                return ibl.UpdateBill(b);
            }
            catch (Exception e)
            {
                throw new Exception("error" + e.Message);
            }
        }
        public Supplierbill getbills(string batchname)
        {
            try
            {
                return ibl.GetSupplierBillByBatchName(batchname);

            }
            catch (Exception e)
            {
                throw new Exception("error" + e.Message);
            }
        }

        public List<Supplierbill> getbillbyname(string text)
        {
            try
            {
                return ibl.getbills(text);
            }
            catch
            {
                throw new ArgumentException("error");
            }
        }

        public List<Supplierbill> getbill()
        {
            return ibl.getbill();
        }

        public List<Supplierbill> getbills(int billid)
        {
            return ibl.getbills(billid);
        }
    }
}
