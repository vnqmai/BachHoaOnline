using System;
using System.Collections.Generic;

namespace BachHoaOnline.Models
{
    public partial class Hoadon
    {
        public Hoadon()
        {
            Chitiethoadon = new HashSet<Chitiethoadon>();
        }

        public int Mahd { get; set; }
        public int? Makh { get; set; }
        public DateTime? Ngaydat { get; set; }
        public DateTime? Ngaygiao { get; set; }
        public string Hoten { get; set; }
        public string Diachi { get; set; }
        public string Cachthanhtoan { get; set; }
        public string Cachvanchuyen { get; set; }
        public double? Phivanchuyen { get; set; }
        public int? Matrangthai { get; set; }
        public string Ghichu { get; set; }

        public Khachhang MakhNavigation { get; set; }
        public Trangthai MatrangthaiNavigation { get; set; }
        public ICollection<Chitiethoadon> Chitiethoadon { get; set; }
    }
}
