using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface IInventoryDl
    {
        List<Inventory> GetInventoryByProductName();
        List<Inventory> SearchInventoryByProductName(string name);
        bool UpdateInventory(Inventory i);
    }
}