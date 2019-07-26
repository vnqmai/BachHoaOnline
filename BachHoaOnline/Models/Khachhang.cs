using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Hoadon = new HashSet<Hoadon>();
            Nhanxet = new HashSet<Nhanxet>();
            Yeuthich = new HashSet<Yeuthich>();
        }

        public int Makh { get; set; }
        public string Matkhau { get; set; }
        public string Hoten { get; set; }
        public bool? Gioitinh { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Diachi { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public string Randomkey { get; set; }

        public ICollection<Hoadon> Hoadon { get; set; }
        public ICollection<Nhanxet> Nhanxet { get; set; }
        public ICollection<Yeuthich> Yeuthich { get; set; }
    }
}
