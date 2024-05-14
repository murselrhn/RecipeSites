using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using RecipeSites.Functions;
using RecipeSites.Models;

namespace RecipeSites.Controllers
{

    public class SecurityController : Controller
    {
        // GET: Security


        RecipeEntities db = new RecipeEntities();

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(TBLUSER tbluser)

        {

            var user = db.TBLUSER.FirstOrDefault(x => x.Username == tbluser.Username &&
               x.Password == tbluser.Password);

            if (user == null)
            {
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(user.Username, false);
                Users.Userss = user;
                if (User.IsInRole("Admin"))
                {
                    return RedirectToAction("Index", "AuthorAdmin");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]

        public ActionResult Register([Bind(Include = "User_Id,Username,Email,NameSurname,Password,Add_ModifyDate,Role")] TBLUSER tbluser)
        {
            var user = db.TBLUSER.FirstOrDefault(x => x.Username== tbluser.Username &&
                  x.Password == tbluser.Password);

            if (user != null)
            {
               
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                tbluser.Role = "User";
                db.TBLUSER.Add(tbluser);
                db.SaveChanges();
               

                return RedirectToAction("Login");
            }

            return View();
        }

        public ActionResult NewMember()
        {
            return View();
        }

    }
}
