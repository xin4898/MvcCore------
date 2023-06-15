using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System.IO;

namespace prjMvcCoreDemo.Controllers
{
    public class ProductController : Controller
    {
        private IWebHostEnvironment _enviro = null;
        public ProductController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        // GET: Product
        public ActionResult List(CKeywordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            DbDemoContext db = new DbDemoContext();
            IEnumerable<TProduct> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.TProducts
                        select p;
            }
            else
                datas = db.TProducts.Where(p => p.FName.Contains(keyword));
            return View(datas);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            DbDemoContext db = new DbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
            return View(prod);
        }
        [HttpPost]
        public ActionResult Edit(CProductWraper x)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == x.FId);
            if (prod != null)
            {
                if (x.photo != null)
                {
                    string photoName = Guid.NewGuid().ToString() + ".jpg";
                    x.photo.CopyTo(new FileStream(
                        _enviro.WebRootPath+"/images/"+ photoName, 
                        FileMode.Create));
                    prod.FImagePath = photoName;
                }
                prod.FName = x.FName;
                prod.FQty = x.FQty;
                prod.FCost = x.FCost;
                prod.FPrice = x.FPrice;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbDemoContext db = new DbDemoContext();
                TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                {
                    db.TProducts.Remove(prod);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(TProduct t)
        {
            DbDemoContext db = new DbDemoContext();
            db.TProducts.Add(t);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}