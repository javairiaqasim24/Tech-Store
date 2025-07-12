//using KIMS;
//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using TechStore.BL.Models;
//using TechStore.DL;
//using TechStore.UI;

//namespace TechStore.BL
//{
//    public class EditDeleteServicesBL
//    {
//        private readonly EditDeleteServicesDL _dataLayer;

//        public EditDeleteServicesBL()
//        {
//            _dataLayer = new EditDeleteServicesDL();
//        }

//        public DataTable GetAllServices()
//        {
//            return _dataLayer.GetAllServices();
//        }

//        public DataTable SearchServicesByCustomer(int customerId)
//        {
//            return _dataLayer.SearchServicesByCustomer(customerId);
//        }

//        public ServiceRequest GetServiceById(int serviceId)
//        {
//            return _dataLayer.GetServiceById(serviceId);
//        }


//        public bool DeleteService(int serviceId)
//        {
//            // Add business validation here if needed
//            return _dataLayer.DeleteService(serviceId);
//        }

//        public List<customer> GetAllCustomers()
//        {
//            return _dataLayer.GetAllCustomers();
//        }


//        public bool UpdateService(ServiceRequest service)
//        {
//            string updateLineQuery = @"UPDATE service_line SET 
//                            nameofitem = @name,
//                            description = @desc,
//                            recievedate = @recvDate,
//                            deliverydate = @delivDate
//                            WHERE service_id = @serviceId";

//            var lineParams = new MySqlParameter[] {
//        new MySqlParameter("@name", service.ServiceLine.NameOfItem),
//        new MySqlParameter("@desc", service.ServiceLine.Description ?? (object)DBNull.Value),
//        new MySqlParameter("@recvDate", service.ServiceLine.RecieveDate),
//        new MySqlParameter("@delivDate", service.ServiceLine.DeliveryDate ?? (object)DBNull.Value),
//        new MySqlParameter("@serviceId", service.ServiceId)
//    };

//            string updateRequestQuery = @"UPDATE service_requests SET
//                               status = @status,
//                               problem_description = @problem,
//                               solution = @solution,
//                               total_charge = @charge,
//                               amount_paid = @paid,
//                               payment_status = @payStatus
//                               WHERE service_request_id = @reqId";

//            var requestParams = new MySqlParameter[] {
//        new MySqlParameter("@status", service.Status),
//        new MySqlParameter("@problem", service.ProblemDescription),
//        new MySqlParameter("@solution", service.Solution ?? (object)DBNull.Value),
//        new MySqlParameter("@charge", service.TotalCharge),
//        new MySqlParameter("@paid", service.AmountPaid),
//        new MySqlParameter("@payStatus", service.PaymentStatus),
//        new MySqlParameter("@reqId", service.ServiceRequestId)
//    };

//            try
//            {
//                using (var conn = DatabaseHelper.Instance.GetConnection())
//                {
//                    conn.Open();
//                    using (var transaction = conn.BeginTransaction())
//                    {
//                        try
//                        {
//                            // Execute both updates in a transaction
//                            int lineUpdated = DatabaseHelper.Instance.ExecuteNonQueryTransaction(
//                                updateLineQuery, lineParams, transaction);

//                            int requestUpdated = DatabaseHelper.Instance.ExecuteNonQueryTransaction(
//                                updateRequestQuery, requestParams, transaction);

//                            if (lineUpdated > 0 && requestUpdated > 0)
//                            {
//                                transaction.Commit();
//                                return true;
//                            }
//                            else
//                            {
//                                transaction.Rollback();
//                                Console.WriteLine("One of the updates affected 0 rows");
//                                return false;
//                            }
//                        }
//                        catch (Exception ex)
//                        {
//                            transaction.Rollback();
//                            Console.WriteLine($"Transaction rolled back. Error: {ex.Message}");
//                            return false;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Database operation failed: {ex.Message}");
//                return false;
//            }
//        }
//    }
//}

using System;
using System.Collections.Generic;
using System.Data;
using TechStore.DL;

namespace TechStore.BL
{
    public static class EditDeleteServicesBL
    {
        public static List<string> GetAllCustomerNames()
        {
            return EditDeleteServicesDL.GetAllCustomerNames();
        }

        public static DataTable GetServicesByCustomer(string fullName)
        {
            return EditDeleteServicesDL.GetServicesByCustomer(fullName);
        }
        public static DataTable GetAllServices()
        {
            return EditDeleteServicesDL.GetAllServices();
        }

        public static bool UpdateService(int serviceId, string item, string status, string paymentStatus, DateTime received, DateTime delivery, decimal charge)
        {
            return EditDeleteServicesDL.UpdateService(serviceId, item, status, paymentStatus, received, delivery, charge);
        }


        public static void DeleteService(int serviceId)
        {
            EditDeleteServicesDL.DeleteService(serviceId);
        }
    }
}
