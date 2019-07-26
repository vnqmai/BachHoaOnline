using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Nhacungcap
    {
        public Nhacungcap()
        {
            Hanghoa = new HashSet<Hanghoa>();
        }

        public int Mancc { get; set; }
        public string Tenncc { get; set; }
        public string Nguoilienhe { get; set; }
        public string Dienthoai { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Logo { get; set; }
        public string Mota { get; set; }

        public ICollection<Hanghoa> Hanghoa { get; set; }
    }
}
