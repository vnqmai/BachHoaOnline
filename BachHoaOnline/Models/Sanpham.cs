using BachHoaOnline.Helper;
using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Sanpham
    {
        public int Masp { get; set; }
        public string Tenhh { get; set; }
        public string Tenalias { get { return StaticClass.ToURLFriendly(Tenhh); } set { } }
        public string Dongia { get; set; }
        public string Giamgia { get; set; }
        public string Hinh { get; set; }
        public string Ncc { get; set; }
        public string Thuonghieu { get; set; }
        public string Xuatxu { get; set; }
        public string Mota { get; set; }
        public string Loai { get; set; }
        public string Chitietloai { get; set; }
        public string Solanxem { get; set; }
        public string Ngaysx { get; set; }
        public string Motadonvi { get; set; }
    }
}
