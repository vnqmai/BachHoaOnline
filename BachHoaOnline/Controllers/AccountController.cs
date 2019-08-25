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
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error","Administrator");
            }
            return View(db.Khachhang.ToList());
        }

        public IActionResult Create()
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }
            return View();
        }

        public IActionResult DoCreate(Khachhang kh)
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }

            db.Khachhang.Add(kh);
            ViewBag.status = "Tạo mới thành công.";
            return View("Create");
        }

        public IActionResult Update(int id)
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }

            return View(db.Khachhang.Where(x => x.Makh == id).SingleOrDefault());
        }

        public IActionResult DoUpdate(Khachhang kh)
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }

            Khachhang des = db.Khachhang.Where(x => x.Makh == kh.Makh).SingleOrDefault();
            des.Hoten = kh.Hoten;
            des.Matkhau = kh.Matkhau;
            des.Gioitinh = kh.Gioitinh;
            des.Ngaysinh = kh.Ngaysinh;
            des.Diachi = kh.Diachi;
            des.Dienthoai = kh.Dienthoai;
            des.Randomkey = kh.Randomkey;
            db.SaveChanges();
            ViewBag.status = "Cập nhật thành công.";
            return View("Update",des);
        }

        public IActionResult Delete(int id)
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }

            return View(db.Khachhang.Where(x => x.Makh == id).SingleOrDefault());
        }

        public IActionResult DoDelete(Khachhang kh)
        {
            if (HttpContext.Session.Get<string>("user") != "admin@bachhoaonline.herokuapp.com")
            {
                return RedirectToAction("Error", "Administrator");
            }

            db.Khachhang.Remove(db.Khachhang.Where(x => x.Makh == kh.Makh).SingleOrDefault());
            db.SaveChanges();
            ViewBag.status = "Đã xóa thành công.";
            return View("Delete");
        }
    }
}