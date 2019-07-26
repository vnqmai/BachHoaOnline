using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Hotro
    {
        public int Maht { get; set; }
        public int? Manv { get; set; }
        public int? Manx { get; set; }
        public string Noidung { get; set; }
        public DateTime? Ngaygui { get; set; }

        public Nhanvien ManvNavigation { get; set; }
        public Nhanxet ManxNavigation { get; set; }
    }
}
