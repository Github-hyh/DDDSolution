using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DDD.Infrastructure
{
    public class SessionHelper
    {
        public static void AddSession(string strsessionname,string strvalue)
        {
            HttpContext.Current.Session[strsessionname] = strvalue;
            HttpContext.Current.Session.Timeout = 600;
        }

        public static void AddSession(string strsessioinname,string[] strvalues)
        {
            HttpContext.Current.Session[strsessioinname] = strvalues;
            HttpContext.Current.Session.Timeout = 600;
        }

        public static  string[] Gets(string strsessionname)
        {
            if (HttpContext.Current.Session[strsessionname] == null)
                return null;
            return (string[])HttpContext.Current.Session[strsessionname];
        }
    }
}
