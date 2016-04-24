using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using _254ShadesV2.Models;

namespace _254ShadesV2.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        private readonly IShadeService shadeService;
        public HomeController(IShadeService shadeService)
        {
            this.shadeService = shadeService;
        }

        public async Task<IActionResult> Index()
        {

            //Shade newShade = new Shade()
            //{
            //    NamedBy = "mrssavageangel",
            //    NumericValue = 56,
            //    HexValue = "#383838",
            //    LongHexValue = "#383838",
            //    Name = "John Major Gray"
            //};

            //await shadeService.SaveShadeAsync(newShade);
            //var results = await shadeService.GetShadesAsync();
            
            //foreach(var p in results)
            //{
            //    System.Diagnostics.Debug.WriteLine(p.Name);
            //}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
