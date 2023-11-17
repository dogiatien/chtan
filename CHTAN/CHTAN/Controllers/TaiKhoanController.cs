using CHTAN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.Mime.MediaTypeNames;

namespace CHTAN.Controllers
{
    public class TaiKhoanController : Controller
    {
        public ActionResult QLTaiKhoan(string category)
        {
            DataModel db = new DataModel();
            if (string.IsNullOrEmpty(category))
            {
                ViewBag.list = db.get("EXEC PR_TaiKhoan");
            }
            else
            {
                string query = string.Format("PR_TaiKhoan_Sort " + category);
                ViewBag.list = db.get(query);
            }
            return View();
        }
        
        public ActionResult ChiTietTk(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietTK " + id);
            return View();
        }
        public ActionResult UpdateTk(string id, string tendn, string matkhau, string tentk, string sdt)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietTK " + id);
            ViewBag.listUpdate = db.get("EXEC PR_SuaTaiKhoan  '" + tendn + "' , '" + matkhau + "', N'" + tentk + "' , ' " + sdt + " ' , " + id);
            return RedirectToAction("QLTaiKhoan", "TaiKhoan");
        }
        public ActionResult UpdateTks(string id, string tendn, string matkhau, string tentk, string sdt)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietTK " + id);
            ViewBag.listUpdate = db.get("EXEC PR_SuaTaiKhoan  '" + tendn + "' , '" + matkhau + "', N'" + tentk + "' , '" + sdt + "' , " + id);
            return RedirectToAction("Info", "Home",new { id = id });
        }
        public ActionResult Sort(string searchBy) 
        {
            DataModel db = new DataModel();
            if (searchBy == "all")
            { 
            ViewBag.list = db.get("EXEC PR_TaiKhoan");
            }
            else if (searchBy == "nv")
            {
                ViewBag.list = db.get("EXEC PR_TaiKhoan_NhanVien");
            }
            else if (searchBy == "kh")
            {
                ViewBag.list = db.get("EXEC PR_TaiKhoan_KhachHang");
            }

            return View();
        }
        public ActionResult XoaTaiKhoan(String id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_XoaTaiKhoan " + id);
            return RedirectToAction("QLTaiKhoan", "TaiKhoan");

        }
        [HttpPost]
        public ActionResult ThemTaiKhoan(string tendn, string matkhau, string tentk,string sdt,string loaitk)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemTaiKhoan  '" + tendn  + "' , '" + matkhau +"', N'" + tentk + "' , ' " + sdt + " ',"+ loaitk);
            return RedirectToAction("QLTaiKhoan", "TaiKhoan");
        }

    }
}