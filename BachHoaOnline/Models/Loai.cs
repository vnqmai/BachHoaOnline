using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Loai
    {
        public Loai()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Maloai { get; set; }
        public string Tenloai { get; set; }
        public string Tenloaialias { get; set; }
        public string Hinh { get; set; }
        public string Mota { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
