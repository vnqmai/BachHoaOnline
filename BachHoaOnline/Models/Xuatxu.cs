using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Xuatxu
    {
        public Xuatxu()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Maxx { get; set; }
        public string Tenxx { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
