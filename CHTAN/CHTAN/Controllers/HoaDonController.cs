using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class HoaDonController : Controller
    {
        public ActionResult Index()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_HoaDon");
            ViewBag.listcthd = db.get("EXEC Pr_CtHD");
            ViewBag.listma = db.get("EXEC PR_Menu");
            return View();
        }
        public ActionResult IndexStaff()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_HoaDon");
            ViewBag.listcthd = db.get("EXEC Pr_CtHD");
            ViewBag.listma = db.get("EXEC PR_Menu");
            return View();
        }
        public ActionResult DeleteHD(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("Pr_XoaHoaDon " + id);
            return RedirectToAction("Index","HoaDon");
        }
        public ActionResult ThanhToanSuccess(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("Pr_ThanhToan " + id);
            return RedirectToAction("Index", "HoaDon");
        }
    }
}