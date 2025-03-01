using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using webProjectWithMvc.Interface;
using webProjectWithMvc.Models;
using System.Data;

namespace webProjectWithMvc.Services
{
    public class StudentServices : IStudent
    {
        private readonly string _connectionstring;

        public StudentServices(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }



        public async Task<List<Student>> GetStudentAsynce()
        {
            var student = new List<Student>();
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_GetStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                student.Add(new Student
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Department = reader.GetString(reader.GetOrdinal("Department"))

                                });
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return student;

        }

        public async Task<IActionResult> InsertStudentAsynce(Student std)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_insertStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", std.Id);
                        cmd.Parameters.AddWithValue("@Name", std.Name);
                        cmd.Parameters.AddWithValue("@Department", std.Department);

                        var result = new SqlParameter("@ReturnMessge", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(result);

                        int res = await cmd.ExecuteNonQueryAsync();

                        string statusMessage = (string)result.Value;

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
                return new StatusCodeResult(500);
            }

        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();  

                    using (SqlCommand cmd = new SqlCommand("sp_getStudentByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Student
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Department = reader.GetString(reader.GetOrdinal("Department"))
                                };
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return null;
        }

        public async Task<string> DeleteStudentAsync(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_DeleteStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", id);

                        SqlParameter outputParam = new SqlParameter("@ReturnMessage", SqlDbType.VarChar, 100)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        await cmd.ExecuteNonQueryAsync();

                        return outputParam.Value.ToString(); // Return the output message
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                return $"Error: {ex.Message}";
            }
        
        }


        public async Task<string> UpdateStudentAsync(Student student)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();

                    using (SqlCommand cmd = new SqlCommand("sp_UpdateStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Id", student.Id);
                        cmd.Parameters.AddWithValue("@Name", student.Name ?? (object)DBNull.Value);
                        cmd.Parameters.AddWithValue("@Department", student.Department ?? (object)DBNull.Value);

                        SqlParameter resultMessageParam = new SqlParameter("@ReturnMessage", SqlDbType.NVarChar, 255)
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
        }


    }
}


