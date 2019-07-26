using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Thuonghieu
    {
        public Thuonghieu()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Math { get; set; }
        public string Tenth { get; set; }
        public string Mota { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
