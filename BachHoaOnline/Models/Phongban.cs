using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Phongban
    {
        public Phongban()
        {
            Phancong = new HashSet<Phancong>();
            Phanquyen = new HashSet<Phanquyen>();
        }

        public int Mapb { get; set; }
        public string Tenpb { get; set; }
        public string Thontin { get; set; }

        public ICollection<Phancong> Phancong { get; set; }
        public ICollection<Phanquyen> Phanquyen { get; set; }
    }
}
