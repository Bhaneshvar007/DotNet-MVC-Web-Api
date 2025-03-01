using WebApiFor_Join.Interface;
using WebApiFor_Join.Models;
using System.Data;
using Microsoft.Data.SqlClient;


namespace WebApiFor_Join.Services
{
    public class JoinsServices : ICetegoryProducts
    {
        private readonly string _connectionString;

        public JoinsServices(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Products>> GetProductsAsync()
        {
            var products = new List<Products>();

            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("GetProductsWithCategoryRightJoin", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                var product = new Products
                                {
                                    productId = reader.GetInt32(reader.GetOrdinal("productId")),
                                    productName = reader.GetString(reader.GetOrdinal("productName")),
                                    productPrice = reader.GetInt32(reader.GetOrdinal("productPrice")),
                                    Cetegorys = new Cetegorys
                                    {
                                        cetegoryId = reader.GetInt32(reader.GetOrdinal("cetegoryId")),
                                        cetegoryName = reader.GetString(reader.GetOrdinal("cetegoryName"))
                                    }
                                };

                                products.Add(product);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you can use a logging framework like Serilog, NLog, etc.)
                // For now, we'll just throw the exception
                throw new ApplicationException("An error occurred while retrieving products.", ex);
            }

            return products;
        }
    }
}