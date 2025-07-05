using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface IInventorylogDl
    {
        List<inventorylog> getlog();
        List<inventorylog> getlog(string searchTerm);
    }
}