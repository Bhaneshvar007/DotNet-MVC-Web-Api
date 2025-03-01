using InventoryManagement_System.Interface;
using InventoryManagement_System.Models;
using InventoryManagement_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_System.Controllers
{
    public class CetegoryController : Controller
    {
        private readonly ICetegory cetegory;

        public CetegoryController(ICetegory cetegory)
        {
            this.cetegory = cetegory;
        }


        [Route("GetCategory")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await this.cetegory.GetCategoryAsync());
        }

        
        [Route("GetCetegoryById")]
        [HttpGet]
        public async Task<IActionResult> GetCetegoryById(int id)
        {
            return View(await this.cetegory.GetCategoryByIdAsync(id));
        }



        [Route("InsertCetegory")]
        [HttpGet]
        public IActionResult InsertCetegory()
        {
            return View();
        }

        [Route("InsertCetegory")]
        [HttpPost]
        public async Task<IActionResult> InsertCetegory([FromForm]string cetegoryName)
        {

            if (!ModelState.IsValid)
            {
                return View(cetegoryName);
            }
            string responseMessage = await cetegory.InsertCetegoryAsync(cetegoryName);

            return RedirectToAction("Index");
        }

        [Route("UpdateCetegory")]
        [HttpGet]
        public async Task<IActionResult> UpdateCetegory(int id)
        {
            var user = await this.cetegory.GetCategoryByIdAsync(id);
            return View(user);
        }


        [Route("UpdateCetegory")]
        [HttpPost]
        public async Task<IActionResult> UpdateCetegory([FromForm] CetegoryModel cetegory)
        {
            ViewBag.message = await this.cetegory.UpdateCetegoryAsync(cetegory);
            return RedirectToAction("Index");
        }

        [Route("DeleteCetegory")]
        [HttpGet]
        public async Task<IActionResult> DeleteCetegory(int id)
        {
            ViewBag.Message = await this.cetegory.DeleteCetegoryAsync(id);
            return RedirectToAction("Index");
        }

    }
}
