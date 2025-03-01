using Crud_OperationOnStudentData.Interface;
using Crud_OperationOnStudentData.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crud_OperationOnStudentData.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudent student;

        public StudentController(IStudent student)
        {
            this.student = student;
        }

        [HttpGet("GetStudent")]
        public async Task<List<Student>> GetStudents()
        {
            return await student.GetStudentAsync();
        }
    
    }
}
