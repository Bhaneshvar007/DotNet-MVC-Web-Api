using Microsoft.AspNetCore.Mvc;
using webProjectWithMvc.Interface;
using webProjectWithMvc.Models;
using System.Threading.Tasks;

namespace webProjectWithMvc.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent student;

        public StudentController(IStudent student)
        {
            this.student = student;
        }

        // GET: /student
        [Route("student")]
        public async Task<IActionResult> Index()
        {
            return View(await this.student.GetStudentAsynce());
        }

        // GET: /student/insert
        [Route("student/insert")]
        public IActionResult InsertStudent()
        {
            return View();
        }

        // POST: /student/insert
        [Route("student/insert")]
        [HttpPost]
        public async Task<IActionResult> InsertStudent([FromForm] Student std)
        {
            ViewBag.Message = await this.student.InsertStudentAsynce(std);
            return RedirectToAction("Index");
        }

        // GET: /student/{id}
        [Route("student/{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var std = await student.GetStudentByIdAsync(id);
            if (std == null)
            {
                return NotFound("Student not found.");
            }
            return View(std);
        }

        // DELETE: /student/delete/{id}
        [Route("student/delete/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            ViewBag.Message = await this.student.DeleteStudentAsync(id);
            return RedirectToAction("Index");
        }

        // GET: /student/update/{id}
        [Route("student/update/{id}")]
        public async Task<IActionResult> UpdateStudent(int id)
        {
            var std = await student.GetStudentByIdAsync(id);
            if (std == null)
            {
                return NotFound("Student not found.");
            }
            return View(std);
        }

        // POST: /student/update
        [Route("student/update")]
        [HttpPost]
        public async Task<IActionResult> UpdateStudent([FromForm] Student std)
        {
            ViewBag.Message = await student.UpdateStudentAsync(std);
            return RedirectToAction("Index");
        }
    }
}
