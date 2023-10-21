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
        public ActionResult LienHe(string category)
        {
            DataModel db = new DataModel();
            ViewBag.listhinh = db.get("EXEC PR_Menu");
            if (string.IsNullOrEmpty(category))
            {
                ViewBag.list = db.get("EXEC PR_ChiNhanh");
            }
            else
            {
                string query = string.Format("EXEC PR_CTKhuVuc N'" + category+"'");
                ViewBag.list = db.get(query);
            }
            ViewBag.listcn = db.get("Execute PR_KhuVuc");
            
            return View();
        }
    }
}