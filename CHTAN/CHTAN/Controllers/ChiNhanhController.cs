using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CHTAN.Controllers
{
    public class ChiNhanhController : Controller
    {
        // GET: ChiNhanh
        public ActionResult QLChiNhanh()
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiNhanh");
            ViewBag.loai = db.get("Exec PR_KhuVuc");
            return View();
        }
        public ActionResult CTCN(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiNhanhCT " + id);
            ViewBag.loai = db.get("Exec PR_KhuVuc");
            return View();
        }
        [HttpPost]
        public ActionResult UpdateChiNhanh( string diachi,string sdt, string idkv, string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_SuaChiNhanh  N'" + diachi +"', '"+ sdt +"',"+ idkv+","+id );
            return RedirectToAction("QLChiNhanh", "ChiNhanh");
        }
        public ActionResult XoaCN(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaChiNhanh " + id);
            return RedirectToAction("QLChiNhanh", "ChiNhanh");

        }
        [HttpPost]
        public ActionResult ThemChiNhanh( string diachi, string sdt, string idkv)
        {

            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemChiNhanh N'" + diachi + "', '" + sdt + "'," + idkv);
            return RedirectToAction("QLChiNhanh", "ChiNhanh");

        }
    }
}