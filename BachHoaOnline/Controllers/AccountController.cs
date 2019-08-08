using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BachHoaOnline.Controllers
{
    public class AccountController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();

        public IActionResult Index()
        {
            return View(db.Khachhang.ToList());
        }

        public IActionResult Update(int id)
        {
            return View(db.Khachhang.Where(x => x.Makh == id).SingleOrDefault());
        }

        public IActionResult DoUpdate()
        {
            return View("Update");
        }

        public IActionResult Delete(int id)
        {
            return View(db.Khachhang.Where(x => x.Makh == id).SingleOrDefault());
        }

        public IActionResult DoDelete()
        {
            return View("Delete");
        }
    }
}