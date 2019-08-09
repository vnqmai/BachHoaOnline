using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BachHoaOnline.Controllers
{
    public class OrderController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();

        public IActionResult Index()
        {
            return View(db.Hoadon.ToList());
        }

        public IActionResult Update(int id)
        {
            return View(db.Hoadon.Where(x=>x.Mahd == id).SingleOrDefault());
        }

        public IActionResult DoUpdate(Hoadon hd)
        {
            Hoadon des = db.Hoadon.Where(x => x.Mahd == hd.Mahd).SingleOrDefault();
            des.Hoten = hd.Hoten;
            des.Diachi = hd.Diachi;
            des.Ngaygiao = hd.Ngaygiao;
            des.Matrangthai = hd.Matrangthai;
            des.Cachthanhtoan = hd.Cachthanhtoan;
            des.Ghichu = hd.Ghichu;
            db.SaveChanges();
            ViewBag.status = "Cập nhật thành công.";
            return View("Update");
        }

        public IActionResult Delete(int id)
        {
            return View(db.Hoadon.Where(x => x.Mahd == id).SingleOrDefault());
        }

        public IActionResult DoDelete(Hoadon hd)
        {
            List<Chitiethoadon>cthd = db.Chitiethoadon.Where(x => x.Mahd == hd.Mahd).ToList();
            foreach (Chitiethoadon ct in cthd)
            {
                db.Chitiethoadon.Remove(ct);
            }
            db.Hoadon.Remove(db.Hoadon.Where(x => x.Mahd == hd.Mahd).SingleOrDefault());
            db.SaveChanges();
            ViewBag.status = "Đã xóa thành công.";
            return View("Delete");
        }
    }
}