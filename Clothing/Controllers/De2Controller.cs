using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Clothing.Models.Entities;


namespace Clothing.Controllers
{    
    public class De2Controller : Controller
    {
        ClothingEntitirs db = new ClothingEntitirs();
        // GET: De2
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult RenderCategory()
        {
            List<PhanLoaiPhu> listCategory = db.PhanLoaiPhus.ToList();
            return PartialView("_MenuBar", listCategory);
        }
        public ActionResult RenderClothing()
        {
            List<SanPham> listSanpham=db.SanPhams.ToList();
            return PartialView("_Content", listSanpham);
        }
        public ActionResult RenderClothByCategory(int maloai)
        {
            List<SanPham> listSp = db.SanPhams.Where(x => x.MaPhanLoaiPhu==maloai).ToList();
            return PartialView("_Content", listSp);
        }
        public ActionResult Update(int id)
        {
            var SPmodel = db.SanPhams.Find(id);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");

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