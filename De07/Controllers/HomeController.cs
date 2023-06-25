using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De07.Models.Entities;
using Microsoft.Ajax;
namespace De07.Controllers
{
    public class HomeController : Controller
    {
        De07Entities db=new De07Entities();
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult RenderCategory()
        {
            List<PhanLoai> listPloai=db.PhanLoais.ToList();
            return PartialView("Menu", listPloai);
        }

        public ActionResult RenderPlant()
        {
            List<SanPham> listsp=db.SanPhams.ToList();
            return PartialView("Content", listsp);
        }
      
        public ActionResult RenderPlantByCatId(int ma)
        {
            List<SanPham> listSP=db.SanPhams.Where(x => x.MaPhanLoai==ma).ToList();
            return PartialView("Content",listSP);
        }
        public ActionResult ChiTietSanPham(int Id)
        {
            if (Id == null)
            {
                return Content("Error");
            }
            var sanPham = db.SanPhams.Where(sp => sp.MaSanPham == Id).ToList();
            return View(sanPham);
        }
        public ActionResult Update(int Id)
        {
            var SPmodel = db.SanPhams.Find(Id);
          /*  ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
*/
            return View(SPmodel);

        }
        [HttpPost]
        public ActionResult Update(SanPham sp)
        {

            var Product = db.SanPhams.Find(sp.MaSanPham);

            if (Product == null)
            {

                return HttpNotFound();

            }
            else
            {
                try
                {
                    Product.TenSanPham = sp.TenSanPham;
                    Product.MaPhanLoai = sp.MaPhanLoai;
                    Product.GiaNhap = sp.GiaNhap;
                    Product.DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat;
                    Product.DonGiaBanLonNhat = sp.DonGiaBanLonNhat;
                    Product.TrangThai = sp.TrangThai;
                    Product.MoTaNgan = sp.MoTaNgan;
                    Product.AnhDaiDien = sp.AnhDaiDien;
                    Product.NoiBat = sp.NoiBat;
                    Product.MaPhanLoaiPhu = sp.MaPhanLoaiPhu;
                    db.SaveChanges();

                    var ploai = db.PhanLoais.Where(o => o.MaPhanLoai == (int)Product.MaPhanLoai);
                    foreach (var loai in ploai)
                    {
                        loai.MaPhanLoai = (int)sp.MaPhanLoai;
                    }
                    db.SaveChanges();
                    var ploaiphu = db.PhanLoaiPhus.Where(o => o.MaPhanLoaiPhu == (int)Product.MaPhanLoaiPhu);
                    foreach (var loaiphhu in ploaiphu)
                    {
                        loaiphhu.MaPhanLoaiPhu = (int)sp.MaPhanLoaiPhu;
                    }
                    db.SaveChanges();
                    // db.Dispose();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    return View(sp);
                }
            }

        } 
    }
}