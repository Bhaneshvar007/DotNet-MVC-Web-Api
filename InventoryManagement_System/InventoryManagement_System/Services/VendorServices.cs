using System.Data;
using InventoryManagement_System.Interface;
using InventoryManagement_System.Models;
using Microsoft.Data.SqlClient;


namespace InventoryManagement_System.Services
{
    public class VendorServices : IVendor
    {
        private readonly string _connectionString;
        public VendorServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public Task<List<VendoreModel>> GetVendorAsync()
        {
            throw new NotImplementedException();
        }

        // public async Task<List<VendoreModel>> GetVendorAsync()
        //{
        //    var vendor = new List<VendoreModel>();
        //    try
        //    {
        //        using (SqlConnection connection = new SqlConnection(_connectionString))
        //        {
        //            await connection.OpenAsync();
        //            using (SqlCommand cmd = new SqlCommand("sp_GetAllVendor", connection))
        //            {
        //                using (SqlDataReader reader = cmd.ExecuteReader())
        //                {
        //                    while (reader.Read())
        //                    {
        //                        vendor.Add(new VendoreModel
        //                        {
        //                            v_id = reader.GetInt32(reader.GetOrdinal("v_id")),
        //                            vendor_name = reader.GetString(reader.GetOrdinal("vendor_name")),
        //                            vendor_email = reader.GetString(reader.GetOrdinal("vendor_email")),
        //                            vendor_address = reader.GetString(reader.GetOrdinal("vendor_address")),
        //                            product_name = reader.GetString(reader.GetOrdinal("product_name")),
        //                            cetegory_type = reader.GetString(reader.GetOrdinal("cetegory_type")),
        //                            date_of_purchase = reader.GetDateTime(reader.GetOrdinal("date_of_purchase")),
        //                            quantity = reader.GetInt32(reader.GetOrdinal("quantity")),
        //                            billing_amount = reader.GetDecimal(reader.GetOrdinal("billing_amount"))

        //                        });

        //                    }
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex.ToString());
        //        throw;
        //    }
        //    return vendor;

        //}



        public async Task<string> InsertVendorAsync(VendoreModel vendor)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("InsertVendorWithOutMessage", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@vendor_name", vendor.vendor_name);
                    cmd.Parameters.AddWithValue("@vendor_email", vendor.vendor_email);
                    cmd.Parameters.AddWithValue("@vendor_address", vendor.vendor_address);
                    cmd.Parameters.AddWithValue("@date_of_sale", vendor.date_of_sale);
                    cmd.Parameters.AddWithValue("@quantity", vendor.quantity);
                    cmd.Parameters.AddWithValue("@billing_amount", vendor.billing_amount);
                    cmd.Parameters.AddWithValue("@ProductId", vendor?.ProductModel?.ProductId);
                    cmd.Parameters.AddWithValue("@cetegoryId", vendor.CetegoryModel.cetegoryId);

                    SqlParameter returnMessage = new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, 500)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(returnMessage);

                    await cmd.ExecuteNonQueryAsync();

                    return returnMessage.Value.ToString();
                }
            }
        }
    }
}
