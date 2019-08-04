using BachHoaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BachHoaOnline.Helper
{
    public class Pagination
    {
        public static int GetNumberOfPages(List<Hanghoa> li)
        {
            int npages = 1;
            if (li.Count % 12 == 0)
            {
                npages = li.Count / 12;
            }
            else
            {
                npages = (li.Count / 12) + 1;
            }
            return npages;
        }

        public static List<Hanghoa> GetListOfPage(List<Hanghoa> li, int curpage)
        {
            List<Hanghoa> res = li;
            if (curpage != 1)
            {
                res = li.Skip((curpage - 1) * 12).Take(12).ToList();                
            }
            return res;
        }
    }
}
