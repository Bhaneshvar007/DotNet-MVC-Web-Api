using CrudWebApi.Model;

namespace CrudWebApi.Interface
{
    public interface IEmployee
    {
        // This is an for getting all the data (interface)
        Task<List<Employee>> GetEmployeesAsync();

        // This is an for interst the  data (interface)
        Task<string> InsertEmployeesAsync(Employee employee);

        Task<Employee> GetEmployeeByIdAsync(int id);
        Task<string> DeleteEmployeeAsync(int id);
        Task<string> UpdateEmployeeAsync(Employee employee);


    }
}
