using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_Nhi.Common
{
    public class XoaKyTu
    {
        public static string RemoveSpecialChars(string str)
        {
            string[] chars = new string[] { ",", ".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(",")", ":", "|", "[", "]"};
            for(int i = 0; i <chars.Length; i++)
            {
                if (str.Contains(chars[i]))
                {
                   str = str.Replace(chars[i], "");
                }
            }
            return str;
        }
    }
}