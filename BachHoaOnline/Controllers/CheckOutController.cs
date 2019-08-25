using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using BachHoaOnline.Models.Paypal;
using BraintreeHttp;
using Microsoft.AspNetCore.Mvc;
using PayPal.Payments;
using PayPal.Core;

namespace BachHoaOnline.Controllers
{
    public class CheckOutController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();

        [Route("thanh-toan")]
        public IActionResult Index()
        {
            return View();
        }
        
        [Route("hoa-don")]
        public IActionResult CheckOut()
        {         
            return View();            
        }

        public IActionResult DoCheckOut(Hoadon hd)
        {
            Khachhang kh = db.Khachhang.Where(x => x.Email == HttpContext.Session.Get<string>("user")).SingleOrDefault();
            hd.Makh = kh.Makh;
            hd.Matrangthai = 1;
            hd.Ngaydat = DateTime.Now;
            hd.Ngaygiao = DateTime.Now.AddDays(7);
            hd.Cachthanhtoan = hd.Cachthanhtoan;

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
            HttpContext.Session.Set("gioHang", "");
            return View("CheckOut",db.Hoadon.Where(x=>x.Mahd==hoadonid).SingleOrDefault());
        }

        public async Task<IActionResult> Paypal_Checkout()
        {
            var environment = new PayPal.Core.SandboxEnvironment("AQjasbufxBKsLNiUCLjl9diJ-yUbo1kcgiimEdjHGGpdEF057SEIIP53VOxEMXLbYU2OwIgDFkSXteGq", "EMLjGQqRwBLb9B41qZHgZaMOdeEf6avNI3tUHz5BKe6_SG9dFGycckKhSH9CrjuKYKYgRvMYbHt0vYPv");
            var client = new PayPal.Core.PayPalHttpClient(environment);

            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("gioHang");
            var itemList = new ItemList()
            {
                Items = new List<Item>()
            };
            float total = 0;
            foreach (var item in cart)
            {
                total += item.Dongia * item.Soluong;
                itemList.Items.Add(new Item() {
                    Name = item.Tensp,
                    Currency = "USD",                    
                    Quantity = item.Soluong.ToString(),
                    Price = item.Dongia.ToString(),
                    Sku = "sku",
                    Tax = "0"
                });
            }
            var payment = new Payment()
            {
                Intent = "sale",
                Transactions = new List<Transaction>()
                {
                    new Transaction()
                    {                        
                        Amount = new Amount()
                        {
                            Total = total.ToString(),
                            Currency = "USD",
                            Details = new AmountDetails
                            {
                                Tax = "0",
                                Shipping = "0",
                                Subtotal = total.ToString()
                            }
                        },
                        ItemList = itemList,
                        Description = "Don hang 001",
                        InvoiceNumber = DateTime.Now.Ticks.ToString()
                    }
                },
                RedirectUrls = new RedirectUrls()
                {
                    CancelUrl = "https://" + Request.Host.ToString()+"/CheckOut/Paypal_Error",
                    ReturnUrl = "https://" + Request.Host.ToString() + "/CheckOut/Paypal_Success"
                },
                Payer = new Payer()
                {
                    PaymentMethod = "paypal"
                }
            };

            PaymentCreateRequest request = new PaymentCreateRequest();
            request.RequestBody(payment);

            try
            {
                HttpResponse response = await client.Execute(request);
                var statusCode = response.StatusCode;
                Payment result = response.Result<Payment>();

                var links = result.Links.GetEnumerator();
                string paypalRedirectUrl = null;
                while (links.MoveNext())
                {
                    LinkDescriptionObject lnk = links.Current;
                    if (lnk.Rel.ToLower().Trim().Equals("approval_url"))
                    {
                        //saving the payapalredirect URL to which user will be redirected for payment  
                        paypalRedirectUrl = lnk.Href;
                    }
                }
                return Redirect(paypalRedirectUrl);
            }
            catch (HttpException httpException)
            {
                var statusCode = httpException.StatusCode;
                var debugId = httpException.Headers.GetValues("PayPal-Debug-Id").FirstOrDefault();

                //return RedirectToAction("Paypal_Error");
                return Content(httpException.ToString());
            }
            
        }

        public IActionResult Paypal_Success()
        {
            Khachhang kh = db.Khachhang.Where(x => x.Email == HttpContext.Session.Get<string>("user")).SingleOrDefault();
            Hoadon hd = new Hoadon {
                Ngaydat = DateTime.Now,
                Ngaygiao = DateTime.Now.AddDays(7),
                Cachthanhtoan = "Paypal"
            };
            hd.Makh = kh.Makh;
            hd.Matrangthai = 1;

            return DoCheckOut(hd);
        }

        public IActionResult Paypal_Error()
        {
            return View("CheckOut", null);
            //return Content("Thanh toán thất bại.");
        }
        //int makh, DateTime ngaydat, DateTime ngaygiao,string hoten, string diachi, string cthanhtoan, string cvanchuyen, double pvanchuyen, int matt, string ghichu        
    }
}