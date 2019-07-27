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

        public List<CartItem> Carts
        {
            get
            {
                List<CartItem> myCart = HttpContext.Session.Get<List<CartItem>>("gioHang");
                if (myCart == default(List<CartItem>))
                {
                    myCart = new List<CartItem>();
                }

                return myCart;
            }
        }

        public IActionResult AddToCart(int id)
        {
            //lấy giỏ hàng đang có
            List<CartItem> gioHang = Carts;
            //kiểm tra xem hàng đã có trong giỏ chưa
            CartItem item = gioHang.SingleOrDefault(p => p.Masp == id);
            //nếu có
            if (item != null)
            {
                item.Soluong++;//tăng số lượng
                item.ThanhTien = item.Soluong * item.Dongia * (1 - (float)(item.Giamgia / 100));
            }
            else
            {
                Sanpham hh = db.Sanpham.SingleOrDefault(p => p.Masp == id);
                if(hh.Giamgia!="")
                    item = new CartItem
                    {
                        Masp = id,
                        Soluong = 1,
                        Tensp = hh.Tenhh,
                        Hinh = hh.Hinh,
                        Giamgia = float.Parse(hh.Giamgia),
                        Dongia = float.Parse(hh.Dongia),
                        ThanhTien = (float)(double.Parse(hh.Dongia) * (1 - (double.Parse(hh.Giamgia)/100)))
                    };
                else
                    item = new CartItem
                    {
                        Masp = id,
                        Soluong = 1,
                        Tensp = hh.Tenhh,
                        Hinh = hh.Hinh,
                        Giamgia = 0,
                        Dongia = float.Parse(hh.Dongia),
                        ThanhTien = (float)(double.Parse(hh.Dongia))
                    };
                gioHang.Add(item);
            }
            //lưu session
            HttpContext.Session.Set("gioHang", gioHang);
            //chuyển tới trang giỏ hàng để xem
            return View(HttpContext.Session.Get<List<CartItem>>("gioHang"));
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
