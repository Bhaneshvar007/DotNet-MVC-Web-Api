using CrudWebApi.Interface;
using CrudWebApi.Model;
 using Microsoft.AspNetCore.Mvc;

namespace CrudWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee) //  Creating a CONSTRUCORE of a inheritance
        {
            _employee = employee;
        }

        [HttpGet("GetEmployees")]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employee.GetEmployeesAsync();
        }

        [HttpPost("InsertEmployees")]
        public async Task<string> InsertEmployees([FromBody] Employee employee)
        {
            return await _employee.InsertEmployeesAsync(employee);
        }

        [HttpGet("GetEmpById")]
        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _employee.GetEmployeeByIdAsync(id);
        }

        [HttpDelete("DeleteEmployee")]

        public async Task<string> DeleteEmployee(int id)
        {
            return await _employee.DeleteEmployeeAsync(id);

        }
        
        [HttpPut("UpdateEmployee")]

        public async Task<string> UpdateEmployee( Employee employee)
        {
            return await _employee.UpdateEmployeeAsync(employee);

        }
    }
}