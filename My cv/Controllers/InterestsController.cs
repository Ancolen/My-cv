using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_cv.Controllers
{
    public class InterestsController : Controller
    {
        GenericRepository<Table_Hobbies> repo = new GenericRepository<Table_Hobbies> ();
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }
        [HttpGet]
        public ActionResult AddHobby()
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult AddHobby(Table_Hobbies p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditHobby(int id)
        {
            var hobby = repo.Find(x => x.ID == id);
            return View(hobby);
        }
        [HttpPost]
        public ActionResult EditHobby(Table_Hobbies p)
        {
            var hobby = repo.Find(x => x.ID == p.ID);
            hobby.Hobby_0 = p.Hobby_0;
            hobby.Hobby_1 = p.Hobby_1;
            repo.TUpdate(hobby);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHobby(int id)
        {
            var hobby = repo.Find(x => x.ID == id);
            repo.TDelete(hobby);
            return RedirectToAction("Index");
        }
    }
}