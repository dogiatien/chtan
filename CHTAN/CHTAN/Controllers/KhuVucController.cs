using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class KhuVucController : Controller
    {
        public ActionResult QLKhuVuc()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_KhuVuc");
            return View();
        }
        public ActionResult ChiTietKV(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_CTKhuVuc " + id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateKV(string tenkv, string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_SuaKhuVuc  N' " + tenkv + "'," + id);
            return RedirectToAction("QLKhuVuc", "KhuVuc");
        }
        public ActionResult XoaKV(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaKhuVuc " + id);
            return RedirectToAction("QLKhuVuc", "KhuVuc");

        }
        [HttpPost]
        public ActionResult ThemKV(string tenkv)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_ThemKhuVuc N' " + tenkv+ "'");
            return RedirectToAction("QLKhuVuc", "KhuVuc");
        }
    }
}