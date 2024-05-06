using Microsoft.Ajax.Utilities;
using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_cv.Controllers
{
    public class SocialMediaController : Controller
    {
        GenericRepository<Table_Social_media> repo = new GenericRepository<Table_Social_media>();
        public ActionResult Index()
        {
            var social = repo.List();
            return View(social);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(Table_Social_media p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteSocialMedia(int id)
        {
            var del = repo.Find(x => x.ID == id);
            repo.TDelete(del);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditSocialMedia(int id)
        {
            var edit = repo.Find(x => x.ID == id);
            return View(edit);
        }
        [HttpPost]
        public ActionResult EditSocialMedia(Table_Social_media p)
        {
            repo.TUpdateAll(where: x => x.ID == p.ID, updatedEntity: p);
            return RedirectToAction("Index");
        }
    }
}