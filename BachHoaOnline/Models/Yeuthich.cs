using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Yeuthich
    {
        public int Mayt { get; set; }
        public int? Makh { get; set; }
        public int? Mahh { get; set; }
        public DateTime? Ngaychon { get; set; }

        public Hanghoa MahhNavigation { get; set; }
        public Khachhang MakhNavigation { get; set; }
    }
}
