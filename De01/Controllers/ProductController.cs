using De01.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using De01.Models.Entities;

namespace De01.Controllers
{
    
    public class ProductController : Controller
    {
        De01Model1 db = new De01Model1();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RenderCategory()
        {
            List<PhanLoai> listPl=db.PhanLoais.ToList();
            return PartialView("_Menu",listPl);
        }
        public ActionResult RenderProduct()
        {
            List<SanPham> listPr = db.SanPhams.ToList();
            return PartialView("_Content", listPr);
        }
        public ActionResult RenderProductId(int ma)
        {
            List<SanPham> listPr = db.SanPhams.Where(x=>x.MaPhanLoai==ma).ToList();
            return PartialView("_Content", listPr);
        }
        public ActionResult AddProduct()
        {
            var sp = new SanPham();
            ViewBag.MaPhanLoai = new SelectList("MaPhanLoai", "PhanLoaiChinh");
            ViewBag.MaPhanLoaiPhu = new SelectList("MaPhanLoaiPhu", "TenPhanLoaiPhu");
            return View(sp);
        }
        [HttpPost]
        public ActionResult AddProduct(SanPham sp)
        {
            try
            {
                db.SanPhams.Add(sp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(sp);
            }
        }
    }
}