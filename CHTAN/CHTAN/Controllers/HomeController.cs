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

        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult Index()
        {
            DataModel db = new DataModel();

            // Lấy danh sách danh mục
            ViewBag.listloai = db.get("EXEC PR_Loai");
            ViewBag.list = db.get("EXEC PR_Menu");
            ViewBag.listnl = db.get("EXEC PR_NguyenLieu");
            ViewBag.listkm = db.get("Select * From KhuyenMai");
            ViewBag.listth = db.get("Select * From TaiKhoan");
            return View();
        }
        public ActionResult Admin()
        {
            if (Session["taikhoan"] == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                DataModel db = new DataModel();
                ViewBag.listma = db.get("EXEC PR_Menu");
                ViewBag.listcthd = db.get("SELECT IDMA,SUM(SoLuong) AS TotalQuantity FROM CTHD   Group by IDMA");
                return View();
            }
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
        public ActionResult Login()
        {
            DataModel db = new DataModel();
            return View();
        }
        public ActionResult SignUp()
        {
            DataModel db = new DataModel();
            return View();
        }
        [HttpPost]
        public ActionResult DangKy(string tendn, string matkhau, string tentk, string sdt, string loaitk)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ThemTaiKhoan  '" + tendn + "' , '" + matkhau + "', N'" + tentk + "' , ' " + sdt + " '," + loaitk);
            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public ActionResult XulyDangNhap(string username, string password)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC Pr_Login '" + username + "','" + password + "'");
            if (ViewBag.list.Count > 0)
            {
                string userRole = ViewBag.list[0][5].ToString(); // Lấy thông tin vai trò từ cơ sở dữ liệu

                if (userRole == "1")
                {
                    Session["taikhoan"] = ViewBag.list[0];
                    return RedirectToAction("Admin", "Home"); // Chuyển hướng đến trang Dashboard của Admin
                }
                if (userRole == "2")
                {
                    Session["taikhoan"] = ViewBag.list[0];
                    return RedirectToAction("Staff", "Home"); // Chuyển hướng đến trang Dashboard của Nhân viên
                }
                else if (userRole == "3")
                {
                    Session["taikhoan"] = ViewBag.list[0];
                    return RedirectToAction("Index", "Home"); // Chuyển hướng đến trang Dashboard của Khách hàng
                }
            }

            return RedirectToAction("Login", "Home");
        }
        public ActionResult Logout()
        {
            Session["taikhoan"] = null;
            return RedirectToAction("Index", "Home");

        }
        public ActionResult Staff()
        {
            DataModel db = new DataModel();
            return View();
        }
        public ActionResult Info(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC PR_ChiTietTK " + id);
            ViewBag.listcthd = db.get("EXEC HoaDonTK " + id);
            ViewBag.listhd = db.get("EXEC HoaDonTKS " + id);
            ViewBag.listma = db.get("EXEC PR_Menu");
            return View();
        }
    }
}