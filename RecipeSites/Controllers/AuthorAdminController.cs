using RecipeSites.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RecipeSites.Controllers
{
    public class AuthorAdminController : Controller
    {
        // GET: AuthorAdmin
        RecipeEntities db = new RecipeEntities();

        [Authorize(Roles = "Admin")]
       
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Index_User()
        {
            return View(db.TBLUSER.ToList());
        }

        // GET: User/Details
        public ActionResult Details_User(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            if (tBLUSER == null)
            {
                return HttpNotFound();
            }
            return View(tBLUSER);
        }
        // GET: Kullanıcı/Create
        public ActionResult Create_User()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_User([Bind(Include = "User_Id,Username,NameSurname,Email,Add_ModifyDate,Password,Role")] TBLUSER tBLUSER)
        {
            if (ModelState.IsValid)
            {
                db.TBLUSER.Add(tBLUSER);
                db.SaveChanges();

                return View();
            }

            return View(tBLUSER);
        }

        // GET: User/Edit
        public ActionResult Edit_User(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            if (tBLUSER == null)
            {
                return HttpNotFound();
            }
            return View(tBLUSER);
        }

        // POST: Kullanıcı/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_User([Bind(Include = "User_Id,Username,Password,Role")] TBLUSER tBLUSER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLUSER).State = EntityState.Modified;
                db.SaveChanges();


            }
            return View(tBLUSER);
        }

        // GET: Kullanıcı/Delete
        public ActionResult Delete_User(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            if (tBLUSER == null)
            {
                return HttpNotFound();
            }
            return View(tBLUSER);
        }

        // POST: Kullanıcı/Delete
        [HttpPost, ActionName("Delete_User")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBLUSER tBLUSER = db.TBLUSER.Find(id);
            db.TBLUSER.Remove(tBLUSER);
            db.SaveChanges();

            return RedirectToAction("Index_User");
        }


    

    public ActionResult Index_Recipe()
    {
        return View(db.TBLRECIPE.ToList());
    }

        
    public ActionResult Details_Recipe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRECIPE tBLRECIPE = db.TBLRECIPE.Find(id);
            if (tBLRECIPE == null)
            {
                return HttpNotFound();
            }
            return View(tBLRECIPE);
        }

        public ActionResult Create_Recipe()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create_Recipe([Bind(Include = "Recipe_Id,Title,Integredients,Instructions")] TBLRECIPE tBLRECIPE)
        {
            if (ModelState.IsValid)
            {
                db.TBLRECIPE.Add(tBLRECIPE);
                db.SaveChanges();

                return View();
            }

            return View(tBLRECIPE);
        }


        public ActionResult Edit_Recipe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRECIPE tBLRECIPE = db.TBLRECIPE.Find(id);
            if (tBLRECIPE == null)
            {
                return HttpNotFound();
            }
            return View(tBLRECIPE);
        }

        // POST: Kullanıcı/Edit

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit_Recipe([Bind(Include = "Recipe_Id,Title,Integredients,Instructions")] TBLRECIPE tBLRECIPE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBLRECIPE).State = EntityState.Modified;
                db.SaveChanges();


            }
            return View(tBLRECIPE);
        }

        // GET: Kullanıcı/Delete
        public ActionResult Delete_Recipe(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBLRECIPE tBLRECIPE = db.TBLRECIPE.Find(id);
            if (tBLRECIPE == null)
            {
                return HttpNotFound();
            }
            return View(tBLRECIPE);
        }

        // POST: Kullanıcı/Delete
        [HttpPost, ActionName("Delete_Recipe")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmedR(int id)
        {
            TBLRECIPE tBLRECIPE = db.TBLRECIPE.Find(id);
            db.TBLRECIPE.Remove(tBLRECIPE);
            db.SaveChanges();

            return RedirectToAction("Index_Recipe");
        }


    }
}


