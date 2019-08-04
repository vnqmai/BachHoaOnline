using BachHoaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachHoaOnline.Helper
{
    public class Filter
    {
        public static List<Hanghoa> FilterByLoaiThuongHieu(List<Hanghoa> li,int loai, int thuonghieu)
        {
            List<Hanghoa> res = li;
            if (loai != -1)
            {
                res = res.Where(x => x.Maloai == loai).ToList();
            }

            if (thuonghieu != -1)
            {
                res = res.Where(x => x.Math == thuonghieu).ToList();
            }
            return res;
        }
    }
}
