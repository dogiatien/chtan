using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class NguyenLieuController : Controller
    {
        public ActionResult QLNguyenLieu()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_NguyenLieu");
            return View();
        }
        public ActionResult ChiTietNguyenLieu(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietNguyenLieu " + id);
            return View();
        }
        [HttpPost]
        public ActionResult UpdateNL(string tennl,string soluong,string dongia,string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_SuaNguyenLieu  N' " + tennl + "', " + soluong+ ", "+dongia + "," + id);
            return RedirectToAction("QLNguyenLieu", "NguyenLieu");
        }
        public ActionResult XoaNguyenLieu(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaNguyenLieu " + id);
            return RedirectToAction("QLNguyenLieu","NguyenLieu");

        }
        [HttpPost]
        public ActionResult ThemNguyenLieu(string tennl,string soluong,string dongia)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemNguyenLieu N'" + tennl + "'," + soluong + ",  "+ dongia);
            return RedirectToAction("QLNguyenLieu", "NguyenLieu");
        }
    }
}