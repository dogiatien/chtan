using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CHTAN.Controllers
{
    public class MonAnController : Controller
    {
        public ActionResult QLMonAn()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_Menu");
            ViewBag.loai = db.get("Exec PR_Loai");
            ViewBag.listnl = db.get("EXEC PR_NguyenLieu");
            ViewBag.listkm = db.get("Select * From KhuyenMai");
            return View();
        }
        public ActionResult CTMA(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietMA " + id);
            ViewBag.loai = db.get("Exec PR_Loai");
            ViewBag.listnl = db.get("EXEC PR_NguyenLieu");
            ViewBag.listkm = db.get("Select * From KhuyenMai");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateMA(string tenma, string mt, string dongia, string ha, string loai, string nl, string km,string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_SuaMonAn  N'" + tenma + "', N'" + mt + "', " + dongia + ", '" + ha + "'," + loai + "," + nl +"," + km + ","+ id);
            return RedirectToAction("QLMonAn", "MonAn");
        }
        public ActionResult XoaMA(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaMonAn " + id);
            return RedirectToAction("QLMonAn", "MonAn");

        }
        [HttpPost]
        public ActionResult ThemMA(string tenma, string mt, string dongia, HttpPostedFileBase ha ,string loai,string nl)
        {
            try
            {
                if (ha != null && ha.ContentLength > 0)
                {
                    string filename = Path.GetFileName(ha.FileName);
                    string path = Path.Combine(Server.MapPath("~/Content/Hinh"), filename);
                    ha.SaveAs(path);
                    DataModel db = new DataModel();
                    ViewBag.list = db.get("EXEC PR_ThemMonAn N'" + tenma + "', N'" + mt + "', " + dongia + ", '" + ha.FileName + "'," + loai + "," + nl);
                }
                } catch (Exception) { }
            return RedirectToAction("QLMonAn", "MonAn");

        }

    }
}