using Microsoft.AspNetCore.Mvc;
using User_Registration_Mvc.Interface;
using User_Registration_Mvc.Models;

namespace User_Registration_Mvc.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly IUser user;

        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpGet("Index")]
        public async Task<IActionResult> Index()
        {
            return View(await this.user.GetUsersAsynce());
        }

        [HttpGet("UserRegistration")]
        public IActionResult UserRegistration()
        {
            return View();
        }

        [HttpPost("UserRegistration")]
        public async Task<IActionResult> UserRegistration([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            ViewBag.message = await this.user.UserRegistrationAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await this.user.GetUsersByIdAsynce(id);
            return View(user);
        }

        [HttpGet("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id)
        {
            var user = await this.user.GetUsersByIdAsynce(id);
            return View(user);
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] User user)
        {
            ViewBag.message = await this.user.UpdateUserAsync(user);
            return RedirectToAction("Index");
        }

        [HttpGet("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            ViewBag.Message = await this.user.DeleteUserAsync(id);
            return RedirectToAction("Index");
        }
    }
}
