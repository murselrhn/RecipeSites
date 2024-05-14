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
    public class RecipesController : Controller
    {
        RecipeEntities db = new RecipeEntities();
        // GET: Blog
        public ActionResult Index()
        {
            var recipes = db.TBLRECIPE.ToList();

            ViewBag.Title = "Sweety Recipes | Recipes";
            return View(recipes);
        }


        public ActionResult Details(int? id)
        {

            ViewBag.Title = "Sweety Recipes | Recipes";

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
        [HttpPost]
        public ActionResult Details(string txtName, string txtEmail, string comment, int id)
        {
            TBLCOMMENT newComment = new TBLCOMMENT();
            newComment.Text = comment;
            newComment.User = 1;
            newComment.Comment_Id = id;
            newComment.Time_Stamp = DateTime.Now;
            db.TBLCOMMENT.Add(newComment);
            db.SaveChanges();
            
            return View();
        }
        public ActionResult NewRecipe()
        {

            return View();
        }
        [HttpPost]
       
        public ActionResult NewRecipe([Bind(Include = "Recipe_Id,Title,Integredients,Instructions")] TBLRECIPE nrecipe)
        {
            if (ModelState.IsValid) { 
                db.TBLRECIPE.Add(nrecipe);
            db.SaveChanges();

            return View();
            }

            return View(nrecipe);
        }

    }
}