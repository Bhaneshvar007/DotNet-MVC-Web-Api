using System.Data;
using CrudWebApi.Interface;
using CrudWebApi.Model;
using Microsoft.Data.SqlClient;

namespace CrudWebApi.Services
{
    public class EmployeeServices : IEmployee
    {
        // Declare a private readonly variable to hold the connection string
        private readonly string _connectionstring;

        // Constructor: Gets the connection strin onnectionString("DefaultConnection");
        public EmployeeServices(IConfiguration configuration)
        {
            _connectionstring = configuration.GetConnectionString("DefaultConnection");
        }   

        // Method to fetch all employees from the database asynchronously
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            // Initialize a list to hold the employee data
            var employees = new List<Employee>();

            try
            {
                // Create a new SQL connection using the connection string
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    // Open the connection (blocking version for simplicity)
                    conn.Open();

                    // Create a new SQL command that will execute the stored procedure sp_GetEmployee
                    using (SqlCommand cmd = new SqlCommand("sp_GetEmployee", conn))
                    {
                        // Specify that the command will be a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Execute the command and use the SQL reader to fetch the data
                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            // Loop through the data returned by the reader
                            while (reader.Read())
                            {
                                // Add each employee's data into the employee list
                                employees.Add(new Employee
                                {
                                    EmpId = reader.GetInt32(reader.GetOrdinal("EmpId")),       // Fetch EmpId
                                    EmpName = reader.GetString(reader.GetOrdinal("EmpName")), // Fetch EmpName
                                    Designation = reader.GetString(reader.GetOrdinal("Designation")), // Fetch Designation
                                    Salary = reader.GetDouble(reader.GetOrdinal("Salary")),   // Fetch Salary
                                    city = reader.GetString(reader.GetOrdinal("city")),       // Fetch City
                                    Payment = reader.GetString(reader.GetOrdinal("Payment"))  // Fetch Payment Method
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, log it or rethrow (in this case, print the error)
                Console.WriteLine($"Error fetching employees: {ex.Message}");
                throw; // Re-throws the caught exception
            }

            // Return the list of employees fetched from the database
            return employees;
        }


        // Method to insert a new employee into the database
        public async Task<string> InsertEmployeesAsync(Employee emp)
        {
            try
            {
                // Create a new SQL connection
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    // Open the connection asynchronously
                    await conn.OpenAsync();

                    // Create a new SQL command that will execute the stored procedure sp_InsertEmployee
                    using (SqlCommand cmd = new SqlCommand("sp_InsertEmployee", conn))
                    {
                        // Specify that the command is a stored procedure
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters for the stored procedure using the values from the employee object
                        cmd.Parameters.AddWithValue("@EmpName", emp.EmpName);         // EmpName parameter
                        cmd.Parameters.AddWithValue("@Designation", emp.Designation);  // Designation parameter
                        cmd.Parameters.AddWithValue("@Salary", emp.Salary);           // Salary parameter
                        cmd.Parameters.AddWithValue("@City", emp.city);               // City parameter
                        cmd.Parameters.AddWithValue("@Payment", emp.Payment);         // Payment method parameter

                        // Execute the command asynchronously
                        int rowsAffected = await cmd.ExecuteNonQueryAsync();

                        // Check if the insertion was successful (at least one row affected)
                        if (rowsAffected > 0)
                        {
                            // Return a success message if at least one row was inserted
                            return "Employee inserted successfully.";
                        }
                        else
                        {
                            // Return a message if no rows were inserted
                            return "No employee was inserted.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // If an exception occurs, log it or rethrow (in this case, print the error)
                Console.WriteLine($"Error inserting employee: {ex.Message}");
                // Return an error message if an exception occurs
                return $"Error inserting employee: {ex.Message}";
            }
        }

        //Method for get the employe by id;
        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            try
            {

                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync(); // Use async version

                    using (SqlCommand cmd = new SqlCommand("sp_getEmpByID", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpId", id); // Add parameter

                        using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                        {
                            if (await reader.ReadAsync())
                            {
                                return new Employee
                                {
                                    EmpId = reader.GetInt32(reader.GetOrdinal("EmpId")),
                                    EmpName = reader.GetString(reader.GetOrdinal("EmpName")),
                                    Designation = reader.GetString(reader.GetOrdinal("Designation")),
                                    Salary = reader.GetDouble(reader.GetOrdinal("Salary")),
                                    city = reader.GetString(reader.GetOrdinal("city")),
                                    Payment = reader.GetString(reader.GetOrdinal("Payment"))
                                };
                            }
                            else
                            {
                                Console.WriteLine($"No employee found with ID: {id}");
                                return null; // Explicitly return null when no employee is found
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error (consider using a logging framework)
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }

            return null; // Return null if not found
        }

        public async Task<string> DeleteEmployeeAsync(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteEmployee", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@EmpId", id);

                        // Add output parameter
                        SqlParameter outputParam = new SqlParameter(
                            "@ResultMessage",
                            SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(outputParam);

                        // Execute the command
                        await cmd.ExecuteNonQueryAsync();

                        // Retrieve output parameter value
                        return outputParam.Value.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                throw;
            }
       
        }

        public async Task<string> UpdateEmployeeAsync(Employee emp)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_connectionstring))
                {
                    await conn.OpenAsync();

                    // Use the correct stored procedure name
                    using (SqlCommand cmd = new SqlCommand("sp_updateEmp", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        cmd.Parameters.AddWithValue("@EmpId", emp.EmpId);
                        cmd.Parameters.AddWithValue("@NewEmpName", emp.EmpName);
                        cmd.Parameters.AddWithValue("@NewDesignation", emp.Designation);
                        cmd.Parameters.AddWithValue("@NewSalary", emp.Salary);
                        cmd.Parameters.AddWithValue("@NewCity", emp.city);
                        cmd.Parameters.AddWithValue("@NewPayment", emp.Payment);

                        // Add output parameter to retrieve the result message
                        SqlParameter resultMessageParam = new SqlParameter("@ResultMessage", SqlDbType.NVarChar, 255)
                        {
                            Direction = ParameterDirection.Output
                        };
                        cmd.Parameters.Add(resultMessageParam);

                        // Execute the command asynchronously
                        await cmd.ExecuteNonQueryAsync();

                        // Get the result message from the output parameter
                        return resultMessageParam.Value.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return $"Error: {ex.Message}";
            }
        }

    }
}
