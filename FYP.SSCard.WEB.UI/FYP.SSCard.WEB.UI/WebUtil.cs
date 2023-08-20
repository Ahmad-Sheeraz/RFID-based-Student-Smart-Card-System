using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP.SSCard.WEB.UI
{
    public class WebUtil
    {
        public static readonly string CURRENT_USER = "CurrentUser";
        public static readonly string MY_COOKIE = "info";
        //public static readonly int ADMIN_ROLE = 1;
    }
    public enum Roles
    {
        Admin=1,
        Office=2,
        Library=3,
        Cafeteria=4,
        Student=8,
        
    }
}