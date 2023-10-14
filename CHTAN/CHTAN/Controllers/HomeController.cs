using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Index()
        //{
        //    DataModel db = new DataModel();
        //    ViewBag.list = db.get("EXEC PR_Menu");
        //    ViewBag.listloai = db.get("Exec PR_Loai");
        //    return View();
        //}
        public ActionResult Index(string category)
        {
            DataModel db = new DataModel();
            if (string.IsNullOrEmpty(category))
            {
                ViewBag.list = db.get("EXEC PR_Menu");
            }
            else
            {
                string query = string.Format("EXEC PR_TimTheoLoai " + category);
                ViewBag.list = db.get(query);
            }
            ViewBag.listloai = db.get("EXEC PR_Loai");
            return View();
        }
        public ActionResult Admin()
        {
            DataModel db = new DataModel();
            return View();
        }
    }
}