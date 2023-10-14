using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class LoaiController : Controller
    {
        public ActionResult QLLoai()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_Loai");
            return View();
        }
        public ActionResult ChiTietLoai(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietLoai " + id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateLoai(string loai, string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_SuaLoai  N' " + loai + "'," + id);
            return RedirectToAction("QLLoai", "Loai");
        }
        public ActionResult XoaLoai(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaLoai " + id);
            return RedirectToAction("QLLoai", "Loai");

        }
        [HttpPost]
        public ActionResult ThemLoai(string loai)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemLoai N' " + loai + "'");
            return RedirectToAction("QLLoai", "Loai");
        }
    }
}
