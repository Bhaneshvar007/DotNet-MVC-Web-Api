using InventoryManagement_System.Interface;
using InventoryManagement_System.Models;
using InventoryManagement_System.Services;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement_System.Controllers
{
    public class VendorController : Controller
    {
        private readonly IVendor vendor;
        private readonly IProduct product;
        private readonly ICetegory cetegory;


        public VendorController(IVendor vendor , IProduct product, ICetegory cetegory)
        {
            this.vendor = vendor;
            this.product = product;
            this.cetegory = cetegory;
        }




        [HttpGet]
        [Route("InsertVendor")]
        public async Task<IActionResult> InsertVendor()
        {
            var categories = await cetegory.GetCategoryAsync();
            var products = await product.GetProductAsync();

            ViewBag.Categories = categories ?? new List<CetegoryModel>();
            ViewBag.Products = products ?? new List<ProductModel>();

            return View();
        }

        [HttpPost]
        [Route("InsertVendor")]
        public async Task<IActionResult> InsertVendor(VendoreModel model)
        {
            //if (ModelState.IsValid)
            //{
            //    string message = await vendor.InsertVendorAsync(model);
            //    ViewBag.Message = message;

            //    var categories = await cetegory.GetCategoryAsync();
            //    var products = await product.GetProductAsync();

            //    ViewBag.Categories = categories ?? new List<CetegoryModel>();
            //    ViewBag.Products = products ?? new List<ProductModel>();

            //    return View();
            //}

            string message = await vendor.InsertVendorAsync(model);
            ViewBag.Message = message;
            return View(model);
        }
    }
}
