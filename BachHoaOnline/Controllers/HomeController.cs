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

        [Route("san-pham/{loai}/{tenHHSEO}")]
        public IActionResult Details(string loai,string tenHHSEO)
        {
            if(db.Hanghoa.SingleOrDefault(x => x.Tenalias == tenHHSEO)!=null)
                return View(db.Hanghoa.SingleOrDefault(x => x.Tenalias == tenHHSEO));
            else
                return RedirectToAction(controllerName: "Home", actionName: "Error");
        }
        
        public ActionResult SEOUrl(string tenHHSEO)
        {
            var id = int.Parse(tenHHSEO.Substring(0, tenHHSEO.IndexOf("-")));
            var hh = db.Hanghoa.SingleOrDefault(p => p.Mahh == id);
            return View("Details", hh);
        }

        [Route("danh-muc-san-pham")]
        public IActionResult Shop(int? loai)
        {
            if (loai==null)
                return View(db.Hanghoa.ToList());
            else
                return View(db.Hanghoa.Where(x=>x.Maloai==loai).ToList());
        }

        

        public IActionResult ShopFilter(int loai, int thuonghieu, int sort, int page)
        {
            List<Hanghoa> res = db.Hanghoa.ToList();
            List<Hanghoa> pres = new List<Hanghoa>();

            res = Filter.FilterByLoaiThuongHieu(res,loai,thuonghieu);

            res = Sort.SortWithOption(res,sort);                  

            int npages = Pagination.GetNumberOfPages(res);

            TempData["Sort"] = sort;
            TempData["Page"] = page;
            TempData["Npages"] = npages;

            if (page != 1)
            {
                pres = Pagination.GetListOfPage(res,page);
                return PartialView(pres);
            }

            return PartialView(res);
        }

        public IActionResult Search(string tenhh)
        {
            List<Hanghoa> res = db.Hanghoa.ToList();

            if (tenhh.Length==0)
            {
                return PartialView(res);
            }

            res = res.Where(x => x.Tenhh.Contains(tenhh)).ToList();
            if (res != null)
                return PartialView(res);
            else
                return Content("Không tìm thấy sản phẩm " + tenhh + ".");
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
