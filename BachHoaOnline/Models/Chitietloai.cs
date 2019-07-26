using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Chitietloai
    {
        public Chitietloai()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Mactl { get; set; }
        public string Tenctl { get; set; }
        public string Mota { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
