using BachHoaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachHoaOnline.Helper
{
    public class Sort
    {
        public static List<Hanghoa> SortWithOption(List<Hanghoa> li, int sort)
        {
            List<Hanghoa> res = li;
            if (sort != -1)
            {
                if (sort == 1)
                {
                    res = res.OrderBy(x => x.Dongia).ToList();
                }
                else if (sort == 2)
                {
                    res = res.OrderByDescending(x => x.Giamgia).ToList();
                }
            }
            return res;
        }
    }
}
