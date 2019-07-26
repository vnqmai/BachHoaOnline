using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Phanquyen
    {
        public int Mapq { get; set; }
        public int? Mapb { get; set; }
        public int? Matrang { get; set; }
        public bool? Them { get; set; }
        public bool? Xoa { get; set; }
        public bool? Sua { get; set; }
        public bool? Xem { get; set; }

        public Phongban MapbNavigation { get; set; }
        public Trangweb MatrangNavigation { get; set; }
    }
}
