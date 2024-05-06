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
            repo.TUpdateAll(where: x => x.ID == 1, updatedEntity: p);
            return RedirectToAction("Index");
        }
    }
}