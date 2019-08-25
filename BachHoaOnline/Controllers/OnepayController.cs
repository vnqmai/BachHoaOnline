using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BachHoaOnline.Models;
using Microsoft.AspNetCore.Mvc;

namespace BachHoaOnline.Controllers
{
    public class OnepayController : Controller
    {
        BACHHOA_ONLINEContext db = new BACHHOA_ONLINEContext();
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Onepay()
        {
            decimal totalPrices = 0;
            List<CartItem> cart = HttpContext.Session.Get<List<CartItem>>("gioHang");
            foreach (CartItem product in cart)
            {
                totalPrices += (decimal)(product.ThanhTien *100);
            }
            string amount = totalPrices.ToString();
            string url = RedirectOnepay(RandomString(), amount, "192.186.1.7");
            return Redirect(url);
        }

        public ActionResult OnepayResponse()
        {
            string hashvalidateResult = "";

            // Khoi tao lop thu vien
            VPCRequest conn = new VPCRequest(OnepayProperty.URL_ONEPAY_TEST);
            conn.SetSecureSecret(OnepayProperty.HASH_CODE);

            // Xu ly tham so tra ve va du lieu ma hoa
            string a = "https://" + Request.Host.ToString() + "/Onepay/Onepay" + Request.QueryString.ToString();
            hashvalidateResult = conn.Process3PartyResponse(new Uri(a).ParseQueryString());

            // Lay tham so tra ve tu cong thanh toan
            string vpc_TxnResponseCode = conn.GetResultField("vpc_TxnResponseCode");
            string amount = conn.GetResultField("vpc_Amount");
            string localed = conn.GetResultField("vpc_Locale");
            string command = conn.GetResultField("vpc_Command");
            string version = conn.GetResultField("vpc_Version");
            string cardType = conn.GetResultField("vpc_Card");
            string orderInfo = conn.GetResultField("vpc_OrderInfo");
            string merchantID = conn.GetResultField("vpc_Merchant");
            string authorizeID = conn.GetResultField("vpc_AuthorizeId");
            string merchTxnRef = conn.GetResultField("vpc_MerchTxnRef");
            string transactionNo = conn.GetResultField("vpc_TransactionNo");
            string acqResponseCode = conn.GetResultField("vpc_AcqResponseCode");
            string txnResponseCode = vpc_TxnResponseCode;
            string message = conn.GetResultField("vpc_Message");

            // Kiem tra 2 tham so tra ve quan trong nhat
            if (hashvalidateResult == "CORRECTED" && txnResponseCode.Trim() == "0")
            {
                Khachhang kh = db.Khachhang.Where(x => x.Email == HttpContext.Session.Get<string>("user")).SingleOrDefault();
                Hoadon hd = new Hoadon
                {
                    Ngaydat = DateTime.Now,
                    Ngaygiao = DateTime.Now.AddDays(7),
                    Cachthanhtoan = "Onepay"
                };
                hd.Makh = kh.Makh;
                hd.Matrangthai = 1;
                return RedirectToAction("DoCheckOut", "CheckOut",hd);
                //return View("PaySuccess");
            }
            else
            {
                return RedirectToAction("DoCheckOut", "CheckOut", null);
                //return Content("PayUnSuccess");
            }
        }

        /// <summary>
        /// View thong tin the
        /// </summary>
        public PartialViewResult InforBase()
        {
            return PartialView();
        }

        /// <summary>
        /// Sinh ky tu ngau nhien
        /// </summary>
        private string RandomString()
        {
            var str = new StringBuilder();
            var random = new Random();
            for (int i = 0; i <= 5; i++)
            {
                var c = Convert.ToChar(Convert.ToInt32(random.Next(65, 68)));
                str.Append(c);
            }
            return str.ToString().ToLower();
        }

        /// <summary>
        /// Redirect den onepay
        /// </summary>
        public string RedirectOnepay(string codeInvoice, string amount, string ip)
        {
            // Khoi tao lop thu vien
            VPCRequest conn = new VPCRequest(OnepayProperty.URL_ONEPAY_TEST);
            conn.SetSecureSecret(OnepayProperty.HASH_CODE);

            // Gan cac thong so de truyen sang cong thanh toan onepay
            conn.AddDigitalOrderField("AgainLink", OnepayProperty.AGAIN_LINK);
            conn.AddDigitalOrderField("Title", "Bách hóa online");
            conn.AddDigitalOrderField("vpc_Locale", OnepayProperty.PAYGATE_LANGUAGE);
            conn.AddDigitalOrderField("vpc_Version", OnepayProperty.VERSION);
            conn.AddDigitalOrderField("vpc_Command", OnepayProperty.COMMAND);
            conn.AddDigitalOrderField("vpc_Merchant", OnepayProperty.MERCHANT_ID);
            conn.AddDigitalOrderField("vpc_AccessCode", OnepayProperty.ACCESS_CODE);
            conn.AddDigitalOrderField("vpc_MerchTxnRef", RandomString());
            conn.AddDigitalOrderField("vpc_OrderInfo", codeInvoice);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_ReturnURL", Url.Action("OnepayResponse", "Onepay", null, Request.Scheme, null));

            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", "");
            conn.AddDigitalOrderField("vpc_SHIP_City", "");
            conn.AddDigitalOrderField("vpc_SHIP_Country", "");
            conn.AddDigitalOrderField("vpc_Customer_Phone", "");
            conn.AddDigitalOrderField("vpc_Customer_Email", "");
            conn.AddDigitalOrderField("vpc_Customer_Id", "");
            conn.AddDigitalOrderField("vpc_TicketNo", ip);

            string url = conn.Create3PartyQueryString();
            return url;
        }
    }
}