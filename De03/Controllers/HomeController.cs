using De03.Models.Entities;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De03.Models.Entities;
using System.Data.Entity.Validation;
using System.EnterpriseServices;

namespace De03.Controllers
{
    public class HomeController : Controller
    {
        De03Entities db=new De03Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult RenderCategory()
        {
            List<PhanLoai> listcat=db.PhanLoais.ToList();
            return PartialView("_Menu", listcat);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listpr = db.SanPhams.ToList();
            return PartialView("_Content", listpr);
        }
        public ActionResult RenderProductId(int ma)
        {
            List<SanPham> listpr = db.SanPhams.Where(x=>x.MaPhanLoai==ma).ToList();
            return PartialView("_Content", listpr);
        }
        public ActionResult Detail(int Id)
        {
            if (Id == null)
            {
                return Content("Error");
            }
            var sanPham = db.SanPhams.Where(sp => sp.MaSanPham == Id).ToList();
            return View(sanPham);
        }
        public ActionResult Add()
        {
            var sp = new SanPham();
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais,"MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus,"MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(sp);

        }
        [HttpPost]
        public ActionResult Add(SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(sp);
            }
        }
        public ActionResult Update(int id)
        {
            var list = db.SanPhams.Find(id);
            ViewBag.MaPhanLoai = new SelectList(db.PhanLoais, "MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList(db.PhanLoaiPhus, "MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(list);

        }
        [HttpPost]
        public ActionResult Update(SanPham sp)
        {
            var list = db.SanPhams.Find(sp.MaSanPham);
            if (sp == null)
            {
                return HttpNotFound();
            }
            else
            {
                try
                {
                    list.MaSanPham = sp.MaSanPham;
                    list.TenSanPham = sp.TenSanPham;
                    list.MaPhanLoai = sp.MaPhanLoai;
                    list.GiaNhap = sp.GiaNhap;
                    list.DonGiaBanNhoNhat = sp.DonGiaBanNhoNhat;
                    list.DonGiaBanLonNhat=sp.DonGiaBanLonNhat;
                    list.TrangThai = sp.TrangThai;
                    list.MoTaNgan = sp.MoTaNgan;
                    list.AnhDaiDien = sp.AnhDaiDien;
                    list.NoiBat = sp.NoiBat;
                    list.MaPhanLoaiPhu = sp.MaPhanLoaiPhu;
                    db.SaveChanges();

                   /* var ploai=db.PhanLoais.Where(x=>x.MaPhanLoai == (int)sp.MaPhanLoai);
                    foreach(var l in ploai)
                    {
                        l.MaPhanLoai = (int)sp.MaPhanLoai;
                    }
                    db.SaveChanges();
                    var ploai1 = db.PhanLoaiPhus.Where(x => x.MaPhanLoaiPhu == (int)sp.MaPhanLoaiPhu);
                    foreach (var l1 in ploai1)
                    {
                        l1.MaPhanLoaiPhu = (int)sp.MaPhanLoaiPhu;
                    }
                   */
                  //  db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch(Exception ex)
                {
                    return View(sp);
                }
            }
           

        }
        public ActionResult Delete(int id)
        {
            var sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            return View(sp);
        }
        public ActionResult DeleteConfrim(int id)
        {
            var p=db.SanPhams.Find(id);
            var listmau = db.SPTheoMaus.Where(x => x.MaSanPham == id);
            var msid=listmau.Select(i=>i.MaSPTheoMau).ToArray();

            var chitiet = db.ChiTietSPBans.Where(x => msid.Contains((int)x.MaSPTheoMau));
            var anhchitiet = db.AnhChiTietSPs.Where(x => msid.Contains((int)x.MaSPTheoMau));
            if (p != null)
            {
                try
                {
                    db.AnhChiTietSPs.RemoveRange(anhchitiet);
                    db.ChiTietSPBans.RemoveRange(chitiet);
                    db.SPTheoMaus.RemoveRange(listmau);
                    db.SanPhams.Remove(p);

                    db.SaveChanges();
                }
                catch(DbEntityValidationException ex)
                {
                    var errorMessages=ex.EntityValidationErrors
                        .SelectMany(x=>x.ValidationErrors)
                        .Select(x=>x.ErrorMessage);
                    var full = string.Join("; ", errorMessages);
                    var exception = string.Concat(ex.Message, "The validation errors are: ", full);
                    throw new DbEntityValidationException(exception, ex.EntityValidationErrors);

                }
            }
            ;
            return RedirectToAction("Index");
        }
    }
}