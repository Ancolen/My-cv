using My_cv.Models.Entity;
using My_cv.Repositories;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace My_cv.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        GenericRepository<Table_Admin> db = new GenericRepository<Table_Admin>();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Table_Admin p)
        { 
            DbCVEntities db = new DbCVEntities();
            var control = db.Table_Admin.FirstOrDefault(x => x.Nick == p.Nick && x.Password == p.Password);
            if (control != null)
            {
                FormsAuthentication.SetAuthCookie(control.Nick, false);
                Session["Nick"] = control.Nick.ToString();
                return RedirectToAction("index", "AboutMe");
            }
            else
            {
                return RedirectToAction("index", "Login");
            }
        }
        public ActionResult LogOut()
        { 
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("index", "Login");
        }
    }
}