using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Nhanxet
    {
        public Nhanxet()
        {
            Hotro = new HashSet<Hotro>();
        }

        public int Manx { get; set; }
        public int? Makh { get; set; }
        public int? Mahh { get; set; }
        public string Noidung { get; set; }
        public int? Rating { get; set; }
        public DateTime? Ngaygui { get; set; }

        public Hanghoa MahhNavigation { get; set; }
        public Khachhang MakhNavigation { get; set; }
        public ICollection<Hotro> Hotro { get; set; }
    }
}
