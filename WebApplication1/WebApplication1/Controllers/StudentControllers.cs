using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController] // The [ApiControllers] attributes enables a few features inclidung attributes routing reuirement , automatic model validation and binding source perameter interface
    public class StudentControllers : ControllerBase  // the controllerBase class is a base class for all controllers in asp.net core that handles HTTP request.
    {
        static List<Student> students = new List<Student>();
        // GET: api/<StudentControllers>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }

        // GET api/<StudentControllers>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return students.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<StudentControllers>
        [HttpPost]
        public void Post([FromBody] Student value)
        {
            students.Add(value);
        }

        
        
        // DELETE api/<StudentControllers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            students.RemoveAll(s => s.Id == id);
        }
    }
}
