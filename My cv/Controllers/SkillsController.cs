using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using My_cv.Models.Entity;
using My_cv.Repositories;

namespace My_cv.Controllers
{
    public class SkillsController : Controller
    {
        GenericRepository<Table_skills> repo = new GenericRepository<Table_skills>();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }
        [HttpGet]
        public ActionResult AddSkill()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(Table_skills p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            repo.TDelete(skill);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSkill(int id)
        {
            var skill = repo.Find(x => x.ID == id);
            return View(skill);
        }
        [HttpPost]
        public ActionResult EditSkill(Table_skills p)
        {
            var skill = repo.Find(x => x.ID == p.ID);
            skill.Skills = p.Skills;
            skill.Rate = p.Rate;
            repo.TUpdate(skill);
            return RedirectToAction("Index");
        }
    }
}