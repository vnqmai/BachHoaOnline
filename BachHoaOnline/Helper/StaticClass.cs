using BachHoaOnline.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BachHoaOnline.Helper
{
    public class StaticClass
    {        
        public static string ToURLFriendly(string tieuDe)
        {            
            string str = tieuDe.ToLower().Trim();

            //thay the tieng viet
            str = Regex.Replace(str, @"[ạảãàáâậầấẩẫăắằặẳẵ]", "a");
            str = Regex.Replace(str, @"[óòọõỏôộổỗồốơờớợởỡ]", "o");
            str = Regex.Replace(str, @"[éèẻẹẽêếềệểễ]", "e");
            str = Regex.Replace(str, @"[úùụủũưựữửừứ]", "u");
            str = Regex.Replace(str, @"[íìịỉĩ]", "i");
            str = Regex.Replace(str, @"[ýỳỷỵỹ]", "y");
            str = Regex.Replace(str, @"[đ]", "d");            

            str = Regex.Replace(str, @"[^a-z0-9\s-]", "");// Remove invalid characters for param  
            str = Regex.Replace(str, @"\s+", "-").Trim(); // convert multiple spaces into one hyphens   
            //str = str.Substring(0, str.Length <= 30 ? str.Length : 30).Trim(); //Trim to max 30 char  
            str = Regex.Replace(str, @"\s", "-"); // Replaces spaces with hyphens     
            return str;
        }        
    }
}
