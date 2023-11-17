using CHTAN.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class KMController : Controller
    {
        public ActionResult QLKM()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("Select * From KhuyenMai");
            return View();
        }
        public ActionResult ChiTietKM(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get( "Exec Pr_CTKM " + id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateKM(string loai, string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_SuaKM  " + loai + "," + id);
            return RedirectToAction("QLKM", "KM");
        }
        public ActionResult XoaKM(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaKM " + id);
            return RedirectToAction("QLKM", "KM");

        }
        [HttpPost]
        public ActionResult ThemKM(string loai)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemKM  " + loai );
            return RedirectToAction("QLKM", "KM");
        }
    }
}