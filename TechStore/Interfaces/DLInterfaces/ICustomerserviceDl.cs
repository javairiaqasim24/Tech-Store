using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface ICustomerserviceDl
    {
        int SaveReceipt(customerservicerecipt receipt);
    }
}