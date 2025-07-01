using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechStore.Interfaces.DLInterfaces;
using TechStore.BL.Models.Person;   
using TechStore.BL.Models;
using KIMS;
using MySql.Data.MySqlClient;
namespace TechStore.DL
{
    public  class SupplierDl:IsupplierDl
    {
        public bool addsupplier(Supplier s)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "INSERT INTO suppliers (name, phone, address,email) VALUES (@name, @contact, @address,@email)";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", s.name);
                    cmd.Parameters.AddWithValue("@contact", s.phone);  // Use inherited field
                    cmd.Parameters.AddWithValue("@address", s.address);
                    cmd.Parameters.AddWithValue("@email", s.email); // Use inherited field
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch(MySqlException ex)
            {
                throw new Exception("Database error while adding supplier: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
            throw new Exception("Error adding supplier: " + ex.Message, ex);
            }
        }

        public bool updatesupplier(Supplier s)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "UPDATE suppliers SET name = @name, phone = @contact, address = @address,email=@email WHERE supplier_id = @id";
                    var cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@name", s.name);
                    cmd.Parameters.AddWithValue("@contact", s.email);  // Use inherited field
                    cmd.Parameters.AddWithValue("@address", s.address);
                    cmd.Parameters.AddWithValue("@email", s.email); // Use inherited field
                    cmd.Parameters.AddWithValue("@id", s.id); // Assuming 'id' is a property of persons
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error while updating supplier: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error updating supplier: " + ex.Message, ex);
            }
        }
        public bool deletesupplier(int id)
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "DELETE FROM suppliers WHERE supplier_id = @id";
                    var cmd = new MySqlCommand(query, conn);
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }

                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error while deleting supplier: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting supplier: " + ex.Message, ex);
            }
        }
public List<Supplier> getsuppliers()
        {
            try
            {
                using (var conn = DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers";
                    var cmd = new MySqlCommand(query, conn);
                    var reader = cmd.ExecuteReader();
                    List<Supplier> suppliers = new List<Supplier>();
                    while (reader.Read())

                    {
                        Supplier s = new Supplier(
                                    reader.GetInt32("supplier_id"),
                                      reader.GetString("email"),
                                      reader.GetString("address"),
                                    reader.GetString("name"),
                                    reader.GetString("phone")

                                // Assuming email is also a field in the suppliers table
                                );
                        suppliers.Add(s);
                    }
                    return suppliers;
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error while getting suppliers: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting suppliers: " + ex.Message, ex);
            }
        }
        public List<string> getsuppliernames(string name)
        {
            try
            {
                return DatabaseHelper.Getsuppliers(name);

            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error while getting supplier names: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error getting supplier names: " + ex.Message, ex);
            }
        }
        public List<Supplier> searchsuppliers(string text)
        {
            try
            {
                using (var conn=DatabaseHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM suppliers WHERE name LIKE @text OR phone LIKE @text OR address LIKE @text";
                    var cmd = new MySqlCommand(query, conn);
                    {
                        cmd.Parameters.AddWithValue("@text", "%" + text + "%");
                        using(var reader = cmd.ExecuteReader())
                        {
                            List<Supplier> suppliers = new List<Supplier>();
                            while (reader.Read())
                            {
                                Supplier s = new Supplier(
                                    reader.GetInt32("supplier_id"),
                                      reader.GetString("email"),
                                      reader.GetString("address"),
                                    reader.GetString("name"),
                                    reader.GetString("phone")
                                    
                                  // Assuming email is also a field in the suppliers table
                                );
                                suppliers.Add(s);
                            }
                            return suppliers;
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("Database error while searching suppliers: " + ex.Message, ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Error searching suppliers: " + ex.Message, ex);
            }
        }
    }
}
