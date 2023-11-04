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
    public class CartController : Controller
    {
        private DataModel db = new DataModel();

        // Phương thức để hiển thị giỏ hàng
        public ActionResult Index(string id)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC GetCartItemsByCustomer " + id);
            ViewBag.listma = db.get("EXEC PR_Menu");
            return View();
        }

        // Phương thức để thêm sản phẩm vào giỏ hàng
        [HttpPost]
        public ActionResult AddToCart(string idma, string idtk)
        {
            DataModel db = new DataModel();
            ViewBag.list = db.get("EXEC InsertOrUpdateCartItem " + idma +"," + idtk);
            return RedirectToAction("Index","Home");
        }
        [HttpPost]
        public ActionResult UpdateCart(string soluong, string idtk ,string idma,string idcart)
        {
            db = new DataModel();
            ViewBag.list = db.get("EXEC UpdateCartItem " + idcart + "," + idtk + "," + idma + "," + soluong);
            return RedirectToAction("Index", "Cart" ,new { id = idtk });
        }
        public ActionResult DeleteItem(string idma,string idtk) 
        {
            db = new DataModel();
            ViewBag.list = db.get("EXEC DeleteCartItem " + idtk + "," + idma );
            return RedirectToAction("Index", "Cart", new { id = idtk });
        }
        [HttpPost]
        public ActionResult CheckOut(string idtk, string ngaydat, string diachi, string tongtien)
        {
            db = new DataModel();
            ViewBag.list = db.get("EXEC InsertHoaDon " + idtk + ",'" + ngaydat + "', N'" + diachi + "'," + tongtien);
            ViewBag.listcart = db.get("EXEC GetCartItemsByCustomer " + idtk);
            ViewBag.list = db.get("EXEC InsertCTHD " + idtk);
            TempData["idtk"] = idtk;
            return RedirectToAction("ThanhToan", "Cart", new { id = idtk });
        }
        public ActionResult ThanhToan(string idtk)
        {
            db = new DataModel();
             idtk = TempData["idtk"]?.ToString(); // Lấy giá trị idtk từ TempData
            ViewBag.listma = db.get("EXEC PR_Menu");
            ViewBag.list = db.get("EXEC Proc_HoaDonMoiNhat " + idtk);
            ViewBag.listcthd = db.get("EXEC Proc_CTHDMoiNhat " + idtk);
            return View();
        }
        public ActionResult ThanhToanSuccess(string id)
        {
            db = new DataModel();
            ViewBag.list= db.get("Pr_ThanhToan " + id);
            return View();
        }
     
    }
}