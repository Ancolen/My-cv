using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace My_cv.Controllers
{
    public class ContactController : Controller
    {
        GenericRepository<Table_Contact> repo = new GenericRepository<Table_Contact>();

        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
        public ActionResult DeleteMessage(int id)
        {
            var del = repo.Find(x => x.ID == id);
            repo.TDelete(del);
            return RedirectToAction("Index");
        }
    }
}