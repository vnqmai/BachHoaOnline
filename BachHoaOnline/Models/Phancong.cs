using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Phancong
    {
        public int Mapc { get; set; }
        public int? Manv { get; set; }
        public int? Mapb { get; set; }
        public DateTime? Ngaypc { get; set; }
        public DateTime? Hieuluc { get; set; }

        public Nhanvien ManvNavigation { get; set; }
        public Phongban MapbNavigation { get; set; }
    }
}
