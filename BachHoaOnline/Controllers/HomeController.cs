using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BachHoaOnline.Models;
using BachHoaOnline.Helper;

namespace BachHoaOnline.Controllers
{
    public class HomeController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();
        public IActionResult Index()
        {
            return View(db.Hanghoa.ToList());
        }

        [Route("san-pham/{tenHHSEO}")]
        public IActionResult Details(string tenHHSEO)
        {
            return View(db.Hanghoa.SingleOrDefault(x => x.Tenalias == tenHHSEO));
        }
        
        public ActionResult SEOUrl(string tenHHSEO)
        {
            var id = int.Parse(tenHHSEO.Substring(0, tenHHSEO.IndexOf("-")));
            var hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == id);
            return View("Details", hh);
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

        [Route("add-to-cart/{url}")]
        public IActionResult AddToCart(string url)
        {            
            //lấy giỏ hàng đang có
            List<CartItem> gioHang = Carts;
            //kiểm tra xem hàng đã có trong giỏ chưa
            CartItem item = gioHang.SingleOrDefault(p => p.Tensp == url);
            //nếu có
            if (item != null)
            {
                item.Soluong++;//tăng số lượng
                item.ThanhTien = item.Soluong * item.Dongia * (1 - (float)(item.Giamgia / 100));
            }
            else
            {
                Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Tenalias == url);
                if(hh.Giamgia!=0)
                    item = new CartItem
                    {
                        Masp = hh.Mahh,
                        Soluong = 1,
                        Tensp = hh.Tenhh,
                        Hinh = hh.Hinh,
                        Giamgia = (float)hh.Giamgia,
                        Dongia = (float) hh.Dongia,
                        ThanhTien = (float)(hh.Dongia * (1 - (hh.Giamgia / 100)))
                    };
                else
                    item = new CartItem
                    {
                        Masp = hh.Mahh,
                        Soluong = 1,
                        Tensp = hh.Tenhh,
                        Hinh = hh.Hinh,
                        Giamgia = 0,
                        Dongia = (float) hh.Dongia,
                        ThanhTien = (float)hh.Dongia
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
