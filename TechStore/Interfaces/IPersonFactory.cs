using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.BL.Models;

namespace TechStore.Interfaces
{
    using TechStore.BL.Models;

    public interface IPersonFactory
    {
        persons CreatePerson(PersonType type, int id, string email, string address, string name);
    }


}
