using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Trangweb
    {
        public Trangweb()
        {
            Phanquyen = new HashSet<Phanquyen>();
        }

        public int Matrang { get; set; }
        public string Tentrang { get; set; }
        public string Url { get; set; }

        public ICollection<Phanquyen> Phanquyen { get; set; }
    }
}
