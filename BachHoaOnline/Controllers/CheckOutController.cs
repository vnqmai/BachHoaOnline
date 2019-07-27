using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BachHoaOnline.Controllers
{
    public class CheckOutController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CheckOut(Hoadon hd)
        {
            //Hoadon h = new Hoadon
            //{                
            //    Makh = hd.Makh,                                
            //    Ngaygiao = hd.Ngaygiao,
            //    Ngaydat = hd.Ngaydat,
            //    Hoten = hd.Hoten,                
            //    Diachi = hd.Diachi,
            //    Cachthanhtoan = hd.Cachthanhtoan,
            //    Cachvanchuyen = hd.Cachvanchuyen,
            //    Phivanchuyen = hd.Phivanchuyen,
            //    Matrangthai = hd.Matrangthai,
            //    Ghichu = hd.Ghichu

            //};
            hd.Makh = 9;
            hd.Matrangthai = 1;
            db.Hoadon.Add(hd);
            db.SaveChanges();
            int hoadonid = db.Hoadon.OrderByDescending(x => x.Mahd).ToList()[0].Mahd;
            List<CartItem> chitiet = HttpContext.Session.Get<List<CartItem>>("gioHang");
            foreach (var x in chitiet)
            {
                Chitiethoadon ct = new Chitiethoadon
                {
                    Mahd = hoadonid,
                    Mahh = x.Masp,
                    Soluong = x.Soluong,
                    Dongia = x.Dongia,
                    Giamgia = x.Giamgia
                };
                db.Chitiethoadon.Add(ct);
            }
            db.SaveChanges();
            return View(hd);            
        }

        //int makh, DateTime ngaydat, DateTime ngaygiao,string hoten, string diachi, string cthanhtoan, string cvanchuyen, double pvanchuyen, int matt, string ghichu        
    }
}