using RecipeSites.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RecipeSites.Functions
{
    public static class Users
    {


        public static TBLUSER Userss
        {
            get
            {
                HttpContextWrapper context = null;

                if (System.Web.HttpContext.Current != null)
                    context = new HttpContextWrapper(System.Web.HttpContext.Current);

                if (context.Session["User"] == null) { return new TBLUSER(); };

                return (TBLUSER)context.Session["User"];
            }
            set
            {
                HttpContext.Current.Session["User"] = value;
            }
        }


        public static List<TBLUSER> User
        {
            get
            {
                HttpContextWrapper context = null;
                if (System.Web.HttpContext.Current != null)
                    context = new HttpContextWrapper(System.Web.HttpContext.Current);
                if (context.Session["UserID"] == null) { return new List<TBLUSER>(); };
                return (List<TBLUSER>)context.Session["UserID"];
            }
            set
            {
                HttpContext.Current.Session["UserID"] = value;
            }
        }

    }

}
