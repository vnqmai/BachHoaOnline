using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BachHoaOnline.Models;

namespace BachHoaOnline.Controllers
{
    public class HomeController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();
        public IActionResult Index()
        {
            return View(db.Sanpham.ToList());
        }

        public IActionResult Details(int id)
        {
            return View(db.Sanpham.Where(x=>x.Masp==id));
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
