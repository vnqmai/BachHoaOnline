using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachHoaOnline.Models
{
    public class CartItem
    {
        public int Masp { get; set; }
        public string Tensp { get; set; }
        public string Tenalias { get; set; }
        public float Dongia { get; set; }
        public float Giamgia { get; set; }
        public string Hinh { get; set; }
        public int Soluong { get; set; }
        public float ThanhTien { get; set; }
    }
}
