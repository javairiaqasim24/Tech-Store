//using KIMS;
//using MySql.Data.MySqlClient;
//using System;
//using System.Collections.Generic;
//using System.Data;
//using TechStore.BL.Models;


//namespace TechStore.DL
//{
//    public class EditDeleteServicesDL
//    {
//        public DataTable GetAllServices()
//        {
//            string query = @"
//                SELECT 
//                    sr.service_request_id,
//                    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
//                    sl.nameofitem,
//                    sr.problem_description,
//                    sr.status,
//                    sr.total_charge,
//                    sr.amount_paid,
//                    sr.payment_status,
//                    sl.recievedate,
//                    sl.deliverydate
//                FROM service_requests sr
//                JOIN service_line sl ON sr.service_id = sl.service_id
//                JOIN customers c ON sl.customer_id = c.customer_id
//                ORDER BY sl.recievedate DESC";

//            return DatabaseHelper.Instance.ExecuteDataTable(query);
//        }

//        public DataTable SearchServicesByCustomer(int customerId)
//        {
//            string query = @"
//                SELECT 
//                    sr.service_request_id,
//                    CONCAT(c.first_name, ' ', c.last_name) AS customer_name,
//                    sl.nameofitem,
//                    sr.problem_description,
//                    sr.status,
//                    sr.total_charge,
//                    sr.amount_paid,
//                    sr.payment_status,
//                    sl.recievedate,
//                    sl.deliverydate
//                FROM service_requests sr
//                JOIN service_line sl ON sr.service_id = sl.service_id
//                JOIN customers c ON sl.customer_id = c.customer_id
//                WHERE c.customer_id = @customerId
//                ORDER BY sl.recievedate DESC";

//            var parameters = new MySqlParameter[]
//            {
//                new MySqlParameter("@customerId", customerId)
//            };

//            return DatabaseHelper.Instance.ExecuteDataTable(query, parameters);
//        }

//        public ServiceRequest GetServiceById(int serviceId)
//        {
//            string query = @"
//                SELECT 
//                    sr.*,
//                    sl.*
//                FROM service_requests sr
//                JOIN service_line sl ON sr.service_id = sl.service_id
//                WHERE sr.service_request_id = @serviceId";

//            var parameters = new MySqlParameter[]
//            {
//                new MySqlParameter("@serviceId", serviceId)
//            };

//            using (var reader = DatabaseHelper.Instance.ExecuteReader(query, parameters))
//            {
//                if (reader.Read())
//                {
//                    return new ServiceRequest
//                    {
//                        ServiceRequestId = Convert.ToInt32(reader["service_request_id"]),
//                        ServiceId = Convert.ToInt32(reader["service_id"]),
//                        Status = reader["status"].ToString(),
//                        ProblemDescription = reader["problem_description"].ToString(),
//                        Solution = reader["solution"].ToString(),
//                        TotalCharge = Convert.ToDecimal(reader["total_charge"]),
//                        AmountPaid = Convert.ToDecimal(reader["amount_paid"]),
//                        PaymentStatus = reader["payment_status"].ToString(),
//                        ServiceLine = new ServiceLine
//                        {
//                            ServiceId = Convert.ToInt32(reader["service_id"]),
//                            CustomerId = Convert.ToInt32(reader["customer_id"]),
//                            NameOfItem = reader["nameofitem"].ToString(),
//                            Description = reader["description"].ToString(),
//                            RecieveDate = Convert.ToDateTime(reader["recievedate"]),
//                            DeliveryDate = reader["deliverydate"] != DBNull.Value ?
//                                Convert.ToDateTime(reader["deliverydate"]) : (DateTime?)null
//                        }
//                    };
//                }
//            }
//            return null;
//        }

//        public bool UpdateService(ServiceRequest service)
//        {
//            string updateServiceLineQuery = @"
//                UPDATE service_line 
//                SET 
//                    customer_id = @customerId,
//                    nameofitem = @nameOfItem,
//                    description = @description,
//                    recievedate = @recieveDate,
//                    deliverydate = @deliveryDate
//                WHERE service_id = @serviceId";

//            string updateServiceRequestQuery = @"
//                UPDATE service_requests 
//                SET 
//                    status = @status,
//                    problem_description = @problemDescription,
//                    solution = @solution,
//                    total_charge = @totalCharge,
//                    amount_paid = @amountPaid,
//                    payment_status = @paymentStatus
//                WHERE service_request_id = @serviceRequestId";

//            var parameters = new MySqlParameter[]
//            {
//                new MySqlParameter("@customerId", service.ServiceLine.CustomerId),
//                new MySqlParameter("@nameOfItem", service.ServiceLine.NameOfItem),
//                new MySqlParameter("@description", service.ServiceLine.Description),
//                new MySqlParameter("@recieveDate", service.ServiceLine.RecieveDate),
//                new MySqlParameter("@deliveryDate", service.ServiceLine.DeliveryDate ?? (object)DBNull.Value),
//                new MySqlParameter("@serviceId", service.ServiceId),
//                new MySqlParameter("@status", service.Status),
//                new MySqlParameter("@problemDescription", service.ProblemDescription),
//                new MySqlParameter("@solution", service.Solution),
//                new MySqlParameter("@totalCharge", service.TotalCharge),
//                new MySqlParameter("@amountPaid", service.AmountPaid),
//                new MySqlParameter("@paymentStatus", service.PaymentStatus),
//                new MySqlParameter("@serviceRequestId", service.ServiceRequestId)
//            };

//            try
//            {
//                DatabaseHelper.Instance.ExecuteNonQuery(updateServiceLineQuery, parameters);
//                DatabaseHelper.Instance.ExecuteNonQuery(updateServiceRequestQuery, parameters);
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public bool DeleteService(int serviceId)
//        {
//            string deletePartsQuery = "DELETE FROM service_parts WHERE service_request_id = @serviceId";
//            string deleteRequestQuery = "DELETE FROM service_requests WHERE service_request_id = @serviceId";
//            string deleteServiceLineQuery = "DELETE FROM service_line WHERE service_id = (SELECT service_id FROM service_requests WHERE service_request_id = @serviceId)";

//            var parameter = new MySqlParameter("@serviceId", serviceId);

//            try
//            {
//                // Delete in reverse order due to foreign key constraints
//                DatabaseHelper.Instance.ExecuteNonQuery(deletePartsQuery, new[] { parameter });
//                DatabaseHelper.Instance.ExecuteNonQuery(deleteRequestQuery, new[] { parameter });
//                DatabaseHelper.Instance.ExecuteNonQuery(deleteServiceLineQuery, new[] { parameter });
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }

//        public List<customer> GetAllCustomers()
//        {
//            var customers = new List<customer>();
//            string query = "SELECT customer_id, first_name, last_name FROM customers";

//            using (var reader = DatabaseHelper.Instance.ExecuteReader(query))
//            {
//                while (reader.Read())
//                {
//                    customers.Add(new customer
//                    {
//                        CustomerId = Convert.ToInt32(reader["customer_id"]),
//                        FirstName = reader["first_name"].ToString(),
//                        LastName = reader["last_name"].ToString()
//                    });
//                }
//            }
//            return customers;
//        }
//    }
//}
using KIMS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace TechStore.DL
{
    public static class EditDeleteServicesDL
    {
        public static List<string> GetAllCustomerNames()
        {
            List<string> names = new List<string>();
            string query = "SELECT CONCAT(first_name, ' ', last_name) AS full_name FROM customers";
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        names.Add(reader.GetString("full_name"));
                    }
                }
            }
            return names;
        }

        public static DataTable GetServicesByCustomer(string fullName)
        {
            int custId = DatabaseHelper.Instance.getcustid(fullName);
            string query = @"
                SELECT 
                    sl.service_id, 
                    sl.nameofitem AS Item, 
                    sl.recievedate AS Received, 
                    sl.deliverydate AS Delivery, 
                    sr.status AS Status, 
                    sr.total_charge AS Charge,
                    sr.payment_status AS PaymentStatus
                FROM service_line sl
                LEFT JOIN service_requests sr ON sl.service_id = sr.service_id
                WHERE sl.customer_id = @custId;";

            MySqlParameter[] parameters = {
                new MySqlParameter("@custId", custId)
            };

            return DatabaseHelper.Instance.ExecuteDataTable(query, parameters);
        }

        public static bool UpdateService(int serviceId, string item, string status, string paymentStatus, DateTime received, DateTime delivery, decimal charge)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update service_line
                        string updateLine = "UPDATE service_line SET nameofitem = @item, recievedate = @received, deliverydate = @delivery WHERE service_id = @id";
                        MySqlParameter[] lineParams = {
                    new MySqlParameter("@item", item),
                    new MySqlParameter("@received", received),
                    new MySqlParameter("@delivery", delivery),
                    new MySqlParameter("@id", serviceId)
                };
                        DatabaseHelper.Instance.ExecuteNonQueryTransaction(updateLine, lineParams, transaction);

                        // Update service_requests
                        string updateRequest = "UPDATE service_requests SET status = @status, payment_status = @paymentStatus, total_charge = @charge WHERE service_id = @id";
                        MySqlParameter[] reqParams = {
                    new MySqlParameter("@status", status),
                    new MySqlParameter("@paymentStatus", paymentStatus),
                    new MySqlParameter("@charge", charge),
                    new MySqlParameter("@id", serviceId)
                };
                        DatabaseHelper.Instance.ExecuteNonQueryTransaction(updateRequest, reqParams, transaction);

                        transaction.Commit();
                        return true;
                    }
                    catch
                    {
                        transaction.Rollback();
                        return false;
                    }
                }
            }
        }

        public static DataTable GetAllServices()
        {
            string query = @"
        SELECT 
            sl.service_id, 
            CONCAT(c.first_name, ' ', c.last_name) AS Customer,
            sl.nameofitem AS Item, 
            sl.recievedate AS Received, 
            sl.deliverydate AS Delivery, 
            sr.status AS Status, 
            sr.total_charge AS Charge,
            sr.payment_status AS PaymentStatus
        FROM service_line sl
        JOIN customers c ON sl.customer_id = c.customer_id
        LEFT JOIN service_requests sr ON sl.service_id = sr.service_id;";

            return DatabaseHelper.Instance.ExecuteDataTable(query);
        }

        public static void DeleteService(int serviceId)
        {
            using (var conn = DatabaseHelper.Instance.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        string deleteParts = "DELETE FROM service_parts WHERE service_request_id IN (SELECT service_request_id FROM service_requests WHERE service_id = @sid)";
                        string deleteRequests = "DELETE FROM service_requests WHERE service_id = @sid";
                        string deleteLine = "DELETE FROM service_line WHERE service_id = @sid";

                        MySqlParameter[] param = { new MySqlParameter("@sid", serviceId) };

                        DatabaseHelper.Instance.ExecuteNonQueryTransaction(deleteParts, param, transaction);
                        DatabaseHelper.Instance.ExecuteNonQueryTransaction(deleteRequests, param, transaction);
                        DatabaseHelper.Instance.ExecuteNonQueryTransaction(deleteLine, param, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
    }
}
