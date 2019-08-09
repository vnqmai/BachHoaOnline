using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BachHoaOnline.Controllers
{
    public class CartController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();        

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

        [Route("gio-hang")]
        public IActionResult Index()
        {
            return View(Carts);
        }

        public IActionResult AddToCart(string tenhh, int soluong)
        {
            //lấy giỏ hàng đang có
            List<CartItem> gioHang = Carts;
            //kiểm tra xem hàng đã có trong giỏ chưa
            CartItem item = gioHang.SingleOrDefault(p => p.Tensp == tenhh);
            //nếu có
            if (item != null)
            {
                item.Soluong+=soluong;//tăng số lượng
                item.ThanhTien = item.Dongia * item.Soluong;
            }
            else
            {
                Hanghoa hh = db.Hanghoa.SingleOrDefault(p => p.Tenhh.Contains(tenhh));
                if (hh.Giamgia != 0)
                    item = new CartItem
                    {
                        Masp = hh.Mahh,
                        Soluong = soluong,
                        Tensp = hh.Tenhh,
                        Tenalias = hh.Tenalias,
                        Hinh = hh.Hinh,
                        Giamgia = (float)hh.Giamgia,
                        Dongia = (float)(hh.Dongia-(hh.Dongia*hh.Giamgia/100)),
                        ThanhTien = (float)(hh.Dongia - (hh.Dongia * hh.Giamgia / 100)) * soluong
                    };
                else
                    item = new CartItem
                    {
                        Masp = hh.Mahh,
                        Soluong = soluong,
                        Tensp = hh.Tenhh,
                        Tenalias = hh.Tenalias,
                        Hinh = hh.Hinh,
                        Giamgia = 0,
                        Dongia = (float)hh.Dongia,
                        ThanhTien = (float)hh.Dongia * soluong
                    };
                gioHang.Add(item);
            }
            //lưu session
            HttpContext.Session.Set("gioHang", gioHang);
            //chuyển tới trang giỏ hàng để xem            
            return Json(Carts);
        }

        public bool UpdateCart(string giohang)
        {
            List<CartItem> gio = JsonConvert.DeserializeObject<List<CartItem>>(giohang);
            gio = gio.Where(x=>x.Soluong!=0).ToList();
            HttpContext.Session.Set("gioHang", gio);
            return true;
        }

        public IActionResult RemoveCartItem(string itemName)
        {
            List<CartItem> gio = Carts;
            gio.Remove(gio.Where(x => x.Tensp == itemName).SingleOrDefault());
            HttpContext.Session.Set("gioHang", gio);
            return Json(gio);
        }
    }
}