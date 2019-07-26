using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Hotro = new HashSet<Hotro>();
            Phancong = new HashSet<Phancong>();
        }

        public int Manv { get; set; }
        public string Hoten { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public string Randomkey { get; set; }

        public ICollection<Hotro> Hotro { get; set; }
        public ICollection<Phancong> Phancong { get; set; }
    }
}
