using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.BL.BL
{
    public interface IInventoryBl
    {
        List<Inventory> getAllinventory(string name);
        List<Inventory> getinventory();
        bool update(Inventory i);
    }
}