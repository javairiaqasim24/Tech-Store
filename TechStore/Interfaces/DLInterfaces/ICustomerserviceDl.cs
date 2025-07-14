using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ICustomerserviceDl
    {
        bool SaveReceipt(customerservicerecipt receipt);
    }
}