using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_cv.Models.Entity;


namespace My_cv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default

        DbCVEntities db = new DbCVEntities();

        public ActionResult Index()
        {

            var variables = db.Table_about_me.ToList();

            return View(variables);
        }
        public PartialViewResult About()
        {
            return PartialView();
        }
        public PartialViewResult Education()
        {
            var variables = db.Table_educations.ToList();
            return PartialView(variables);
        }
        public PartialViewResult Skills()
        {
            var variables = db.Table_skills.ToList();
            return PartialView(variables);
        }
        public PartialViewResult Hobbies()
        {
            var variables = db.Table_Hobbies.ToList();
            return PartialView(variables);
        }
        [HttpGet]
        public PartialViewResult Contact()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult Contact(Table_Contact t)
        {
            t.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Table_Contact.Add(t);
            db.SaveChanges();
            return PartialView();
        }
        public PartialViewResult SocialMedia()
        {
            var socialmedia = db.Table_Social_media.ToList();
            return PartialView(socialmedia);
        }
    }
}