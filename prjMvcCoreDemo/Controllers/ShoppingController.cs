using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using prjMvcCoreDemo.ViewModels;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class ShoppingController : Controller
    {   
        public IActionResult CartView()
        {
            if (!HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                return RedirectToAction("List");

            string json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
            List<CShoppingCartItem> cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
            if (cart == null)
                return RedirectToAction("List");
            return View(cart);
        }
        public IActionResult List(CKeywordViewModel vm)
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
        public ActionResult AddToCart(int? id)
        {
            if (id == null)
                return RedirectToAction("List");
            DbDemoContext db = new DbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(p => p.FId == id);           
            return View(prod);
        }
        [HttpPost]
        public ActionResult AddToCart(CAddToCartViewModel vm)
        {
            DbDemoContext db = new DbDemoContext();
            TProduct prod = db.TProducts.FirstOrDefault(t => t.FId == vm.txtFId);
            if (prod != null)
            {
                string json = "";
                List<CShoppingCartItem> cart = null;
                if (HttpContext.Session.Keys.Contains(CDictionary.SK_PURCHASED_PRODUCTS_LIST))
                {
                    json = HttpContext.Session.GetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST);
                    cart = JsonSerializer.Deserialize<List<CShoppingCartItem>>(json);
                }
                else
                    cart = new List<CShoppingCartItem>();
                CShoppingCartItem item = new CShoppingCartItem();
                item.price = (decimal)prod.FPrice;
                item.productId = vm.txtFId;
                item.FName=prod.FName;
                item.count = vm.txtCount;
                item.product = prod;
                cart.Add(item);
                json = JsonSerializer.Serialize(cart);
                HttpContext.Session.SetString(CDictionary.SK_PURCHASED_PRODUCTS_LIST, json);
            }
            return RedirectToAction("List");
        }
    }
}
