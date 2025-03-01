using System.Diagnostics;
using DataPassing___ViewData_Temp_Data_ViewMessgae.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataPassing___ViewData_Temp_Data_ViewMessgae.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // viewdata syntex 

            // viewdata[propertyname] = value(string , array , list)
            // view data ek data passing technique hai from controller to view 
            // view data me hame type casting karni padti hai jiski vajajh se ese tittly cuppeld data 
            // bhi kahte hai view data same view me hi accesss hota hai that mean agr hamne 
            // index ka view banaye hai to viewdata only index view me hi acess hoga  
            // any other view jaise about ya contect view me ham access nhi kar sakte hai
            //ViewData["Name"] = "Bhaneshvar Khsirsagar";

            //string[] arr = { "Basnti", "Gabbar", "Thakur" };
            //ViewData["Array"] = arr ;

            //ViewData["List"] = new List<string>(){
            //    "Balaghat", "Jabalapur" , "Gadarwara"
            //} ;



            // syntex of viewBag -> viewBag.property name = "value name" 
            // view bag view data ka ek wraper hota hai jisme hame typecasting ki need nhi hoti hai 
            // agr hame flexibility chaiye to ham view bag ko choose karenge but we wknow tha tittly
            // cuppled data i always choose the viewdata
            //ViewBag.name = "Bhaneshavar";
            //ViewBag.age = 21;
            //string[] arr = { "ram", "syam", "ghansyam" };
            //ViewBag.array = arr;
            //ViewBag.list = new List<string>()
            //{
            //    "viewbag1data", "viewbag2data" , "viewbag3data"
            //};



            //// accesing the viewbeg data in viewData
            //ViewBag.item1= "Viewbag data accesing by the view data";
            //ViewData["item2"] = "ViewData accesing by the view bag";


            // Temp data :-
            // 1. temp data me typecasting karni padti hai 
            // 2 temp data ka use ham multiple view me to kar sakte hai lekin
            // temp data one time accesable hota hai that mean agar hamne temp data
            // ko index view me access kar liya hai to ye dusre view ke liye null ho jata hai

            TempData["Name"] = "Bhaneshvar Khsirsagar";

            string[] arr = { "Basnti", "Gabbar", "Thakur" };
            TempData["Array"] = arr;
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
