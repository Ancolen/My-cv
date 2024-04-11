using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_cv.Controllers
{
    public class AboutMeController : Controller
    {
        GenericRepository<Table_about_me> repo = new GenericRepository<Table_about_me>();
        [HttpGet]
        public ActionResult Index()
        {
            var aboutMe = repo.List();
            return View(aboutMe);
        }
        [HttpPost]
        public ActionResult Index(Table_about_me p) 
        {
            var aboutMe = repo.Find(x => x.ID == 1);
            aboutMe.Name = p.Name;
            aboutMe.Surname = p.Surname;
            aboutMe.Address = p.Address;
            aboutMe.Mail = p.Mail;
            aboutMe.Phone_Number = p.Phone_Number;
            aboutMe.Description = p.Description;
            repo.TUpdate(aboutMe);
            return RedirectToAction("Index");
        }
    }
}