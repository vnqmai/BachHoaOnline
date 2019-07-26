using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Hanghoa
    {
        public Hanghoa()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
            Nhanxet = new HashSet<Nhanxet>();
            Yeuthich = new HashSet<Yeuthich>();
        }

        public int Mahh { get; set; }
        public string Tenhh { get; set; }
        public string Tenalias { get; set; }
        public int? Maloai { get; set; }
        public string Motadonvi { get; set; }
        public double? Dongia { get; set; }
        public string Hinh { get; set; }
        public string Ngaysx { get; set; }
        public double? Giamgia { get; set; }
        public int? Solanxem { get; set; }
        public string Mota { get; set; }
        public int? Mancc { get; set; }
        public int? Maxx { get; set; }
        public int? Math { get; set; }
        public int? Chitietloai { get; set; }

        public Chitietloai ChitietloaiNavigation { get; set; }
        public Loai MaloaiNavigation { get; set; }
        public Nhacungcap ManccNavigation { get; set; }
        public Thuonghieu MathNavigation { get; set; }
        public Xuatxu MaxxNavigation { get; set; }
        public ICollection<Chitiethoadon> Chitiethoadon { get; set; }
        public ICollection<Nhanxet> Nhanxet { get; set; }
        public ICollection<Yeuthich> Yeuthich { get; set; }
    }
}
