using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Chitiethoadon
    {
        public int Macthd { get; set; }
        public int? Mahd { get; set; }
        public int? Mahh { get; set; }
        public int? Soluong { get; set; }
        public double? Dongia { get; set; }
        public double? Giamgia { get; set; }

        public Hoadon MahdNavigation { get; set; }
        public Hanghoa MahhNavigation { get; set; }
    }
}
