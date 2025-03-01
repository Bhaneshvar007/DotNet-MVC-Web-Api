using Crud_OperationOnStudentData.Interface;
using Crud_OperationOnStudentData.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Crud_OperationOnStudentData.Services
{
    public class StudentServices : IStudent
    {
        private readonly string _connectionstring;

        public StudentServices(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<Student>> GetStudentAsync()
        {
            var students = new List<Student>(); // List to hold student data
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync(); // Open the connection asynchronously
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllStudent", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync()) // Ensure we read all rows asynchronously
                            {
                                var student = new Student
                                {
                                    st_Id = reader.GetInt32(reader.GetOrdinal("st_Id")),
                                    Name = reader.GetString(reader.GetOrdinal("Name")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    Course = reader.GetString(reader.GetOrdinal("Course")),
                                    Branch = reader.GetString(reader.GetOrdinal("Branch")),
                                    Semester = reader.GetInt32(reader.GetOrdinal("Semester"))
                                };

                                students.Add(student); // Add the student to the list
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }

            return students; // Return the list of students
        }
    }
}
