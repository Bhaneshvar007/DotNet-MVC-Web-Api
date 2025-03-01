using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using User_Registration_Mvc.Interface;
using User_Registration_Mvc.Models;

namespace User_Registration_Mvc.Services
{
    public class UserServices : IUser
    {
        private readonly string _connectionString;
        public UserServices(IConfiguration configuration)

        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }


        public async Task<List<User>> GetUsersAsynce()
        {
            var user = new List<User>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetAllUsers", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                user.Add(new User
                                {
                                    U_id = reader.GetInt32(reader.GetOrdinal("U_Id")),
                                    firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                    lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                    email = reader.GetString(reader.GetOrdinal("email")),
                                    phoneNum = reader.GetString(reader.GetOrdinal("phoneNum")),
                                    country = reader.GetString(reader.GetOrdinal("country")),
                                    state = reader.GetString(reader.GetOrdinal("state")),
                                    area = reader.GetString(reader.GetOrdinal("area")),
                                    pincode = reader.GetString(reader.GetOrdinal("pincode"))
                                });
                            }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }

            return user;
        }

        public async Task<User> GetUsersByIdAsynce(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetUsersById", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@U_id", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new User
                                {

                                    U_id = reader.GetInt32(reader.GetOrdinal("U_id")),
                                    firstName = reader.GetString(reader.GetOrdinal("firstName")),
                                    lastName = reader.GetString(reader.GetOrdinal("lastName")),
                                    email = reader.GetString(reader.GetOrdinal("email")),
                                    phoneNum = reader.GetString(reader.GetOrdinal("phoneNum")),
                                    country = reader.GetString(reader.GetOrdinal("country")),
                                    state = reader.GetString(reader.GetOrdinal("state")),
                                    area = reader.GetString(reader.GetOrdinal("area")),
                                    pincode = reader.GetString(reader.GetOrdinal("pincode"))

                                };
                             }


                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
            return null;        
        }

        public async Task<IActionResult> UserRegistrationAsync(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();
                    using (SqlCommand cmd = new SqlCommand("SP_InsertUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // You no longer need to pass @U_id as it's auto-generated
                        cmd.Parameters.AddWithValue("@firstName", user.firstName);
                        cmd.Parameters.AddWithValue("@lastName", user.lastName);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@phoneNum", user.phoneNum);
                        cmd.Parameters.AddWithValue("@country", user.country);
                        cmd.Parameters.AddWithValue("@state", user.state);
                        cmd.Parameters.AddWithValue("@area", user.area);
                        cmd.Parameters.AddWithValue("@pincode", user.pincode);

                        var result = new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, 200)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(result);

                        // Execute the stored procedure
                        int res = await cmd.ExecuteNonQueryAsync();

                        string statusMessage = (string)result.Value;

                        // Return appropriate result based on operation success
                        if (res > 0)
                        {
                            return new OkObjectResult(statusMessage);
                        }
                        else
                        {
                            return new BadRequestObjectResult(statusMessage);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public async Task<string> UpdateUserAsync(User user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_UpdateUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@U_id", user.U_id);

                        cmd.Parameters.AddWithValue("@firstName", user.firstName);
                        cmd.Parameters.AddWithValue("@lastName", user.lastName);
                        cmd.Parameters.AddWithValue("@email", user.email);
                        cmd.Parameters.AddWithValue("@phoneNum", user.phoneNum);
                        cmd.Parameters.AddWithValue("@country", user.country);
                        cmd.Parameters.AddWithValue("@state", user.state);
                        cmd.Parameters.AddWithValue("@area", user.area);
                        cmd.Parameters.AddWithValue("@pincode", user.pincode);

                        SqlParameter resultMessageParam = new SqlParameter("@ReturnMessage",
                            SqlDbType.NVarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultMessageParam);

                        await cmd.ExecuteNonQueryAsync();

                        return resultMessageParam.Value?.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                return "Error updating student: " + ex.Message;
            }
            return null;    
        }

        public async Task<string> DeleteUserAsync(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_DeleteUser", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@U_id", id);

                        SqlParameter outputParam = new SqlParameter("@ReturnMessage", 
                            SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        await cmd.ExecuteNonQueryAsync();

                        return outputParam.Value.ToString();  
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }

        }


    }
}
