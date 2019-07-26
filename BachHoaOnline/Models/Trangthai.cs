using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Trangthai
    {
        public Trangthai()
        {
            Hoadon = new HashSet<Hoadon>();
        }

        public int Matrangthai { get; set; }
        public string Tentrangthai { get; set; }
        public string Motra { get; set; }

        public ICollection<Hoadon> Hoadon { get; set; }
    }
}
