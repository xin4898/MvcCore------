using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace prjMvcCoreDemo.Controllers
{
    public class CustomerController : SuperController
    {
        public IActionResult List(CKeywordViewModel vm)
        {
            string keyword = vm.txtKeyword;
            DbDemoContext db = new DbDemoContext();
            IEnumerable<TCustomer> datas = null;
            if (string.IsNullOrEmpty(keyword))
            {
                datas = from p in db.TCustomers
                        select p;
            }
            else
                datas = db.TCustomers.Where(p => p.FName.Contains(keyword)||
                p.FPhone.Contains(keyword) ||
                p.FEmail.Contains(keyword) ||
                p.FAddress.Contains(keyword) );
            return View(datas); 
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            DbDemoContext db = new DbDemoContext();
            TCustomer cust = db.TCustomers.FirstOrDefault(p => p.FId == id);
            return View(cust);
        }
        [HttpPost]
        public ActionResult Edit(TCustomer x)
        {
            DbDemoContext db = new DbDemoContext();
            TCustomer cust = db.TCustomers.FirstOrDefault(p => p.FId == x.FId);
            if (cust != null)
            { 
                cust.FName = x.FName;
                cust.FPhone = x.FPhone;
                cust.FEmail = x.FEmail;
                cust.FAddress = x.FAddress;
                cust.FPassword = x.FPassword;
                db.SaveChanges();
            }
            return RedirectToAction("List");
        }

        public ActionResult Delete(int? id)
        {
            if (id != null)
            {
                DbDemoContext db = new DbDemoContext();
                TCustomer prod = db.TCustomers.FirstOrDefault(p => p.FId == id);
                if (prod != null)
                {
                    db.TCustomers.Remove(prod);
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
        public ActionResult Create(TCustomer t)
        {
            DbDemoContext db = new DbDemoContext();
            db.TCustomers.Add(t);
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
