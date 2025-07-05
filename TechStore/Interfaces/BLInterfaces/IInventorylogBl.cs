using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces.BLInterfaces
{
    public interface IInventorylogBl
    {
        List<inventorylog> getlog();
        List<inventorylog> getlog(string searchTerm);
    }
}
