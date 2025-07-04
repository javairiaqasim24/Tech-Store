using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;
using TechStore.DL;

namespace TechStore.BL.BL
{
    public class InventoryBl : IInventoryBl
    {
        private readonly IInventoryDl ibl;
        public InventoryBl(IInventoryDl ibl)
        {
            this.ibl = ibl;
        }
        public bool update(Inventory i)
        {
            try
            {
                return ibl.UpdateInventory(i);
            }
            catch { return false; }
        }
        public List<Inventory> getinventory()
        {
            return ibl.GetInventoryByProductName();
        }
        public List<Inventory> getAllinventory(string name)
        {
            return ibl.SearchInventoryByProductName(name);
        }
    }
}
