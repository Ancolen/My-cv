using Antlr.Runtime.Tree;
using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_cv.Controllers
{
    public class EducationsController : Controller
    {
        GenericRepository<Table_educations> repo = new GenericRepository<Table_educations>();

        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }
        [HttpGet]
        public ActionResult AddSchool()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSchool(Table_educations p)
        {
            if(!ModelState.IsValid)
                return View("AddSchool");
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSchool(int id)
        {
            var education = repo.Find(x => x.ID == id);
            return View(education);
        }
        [HttpPost]
        public ActionResult EditSchool(Table_educations p)
        {
            repo.TUpdateAll(where: x => x.ID == p.ID, updatedEntity: p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSchool(int id)
        {
            var del = repo.Find(x => x.ID == id);
            repo.TDelete(del);
            return RedirectToAction("Index");
        }
    }
}