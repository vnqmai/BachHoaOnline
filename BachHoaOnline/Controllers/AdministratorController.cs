using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BachHoaOnline.Controllers
{
    public class AdministratorController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error");
            }
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}