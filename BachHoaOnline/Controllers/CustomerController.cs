using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BachHoaOnline.Controllers
{
    public class CustomerController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();

        [Route("thong-tin-ca-nhan")]
        public IActionResult Index()
        {
            string email = HttpContext.Session.Get<string>("user");
            return View(db.Khachhang.Where(x=>x.Email==email).SingleOrDefault());
        }

        public IActionResult UpdateInfo(Khachhang kh)
        {
            string user = HttpContext.Session.Get<string>("user");
            Khachhang res = db.Khachhang.Where(x => x.Email == user).SingleOrDefault();
            res.Hoten = kh.Hoten;
            res.Gioitinh = kh.Gioitinh;
            res.Ngaysinh = kh.Ngaysinh;
            res.Diachi = kh.Diachi;
            res.Dienthoai = kh.Dienthoai;
            res.Matkhau = kh.Matkhau;
            db.SaveChanges();
            return Redirect("/thong-tin-ca-nhan");
        }

        [Route("dang-nhap")]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult DoLogin(string email, string password)
        {
            var kh = db.Khachhang.Where(x => x.Email == email && x.Matkhau == password).SingleOrDefault();

            if (kh == null)
            {
                TempData["status"] = "Email hoặc mật khẩu không đúng.";
                return Redirect("/dang-nhap");
            }

            HttpContext.Session.Set("user", kh.Email);

            return Redirect("/");
        }

        [Route("dang-ky")]
        public IActionResult Register()
        {
            return View();
        }

        public IActionResult DoRegister(string email, string password)
        {
            var account = db.Khachhang.Where(x => x.Email == email).SingleOrDefault();

            if (account != null)
            {
                TempData["Rstatus"] = "Email đã được sử dụng.";
                return Redirect("/dang-ky");
            }

            Khachhang kh = new Khachhang
            {
                Email = email,
                Matkhau = password
            };
            db.Khachhang.Add(kh);
            db.SaveChanges();

            TempData["Rstatus"] = "Đăng ký thành công.";
            return Redirect("/dang-ky");
        }

        [Route("dang-xuat")]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return Redirect("/dang-nhap");
        }

        public IActionResult Review(string nhanxet)
        {
            Nhanxet review = JsonConvert.DeserializeObject<Nhanxet>(nhanxet);
            review.Ngaygui = DateTime.Now;
            db.Nhanxet.Add(review);
            db.SaveChanges();

            return Content("ok");
        }
    }
}