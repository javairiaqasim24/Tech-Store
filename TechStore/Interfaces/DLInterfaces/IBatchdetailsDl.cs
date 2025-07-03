using System.Collections.Generic;
using TechStore.BL.Models;

namespace TechStore.DL
{
    public interface IBatchdetailsDl
    {
        bool addbatchdetails(Batchdetails b);
        bool deletebatchdetails(int batch_details_id);
        List<Batchdetails> getbatchdetails();
        List<string> getbatches(string text);
        List<string> getproductnames(string text);
        bool updatebatchdetails(Batchdetails b);
        List<Batchdetails> getbatchdetailsbyname(string text);
    }
}