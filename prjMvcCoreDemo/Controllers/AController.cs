using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;
using System.Text.Json;

namespace prjMvcCoreDemo.Controllers
{
    public class AController : Controller
    {
        private IWebHostEnvironment _enviro = null; 
        public string demoObj2Json()
        {
            TCustomer x = new TCustomer()
            {
                FId = 1,
                FName = "Marco",
                FPhone = "0966541254",
                FEmail = "marco@gmail.com",
                FAddress = "Taipei",
                FPassword = "123"
            };
            string json = JsonSerializer.Serialize(x);
            return json;
        }
        public string demoJson2Obj()
        {
            string json = demoObj2Json();
            TCustomer x = JsonSerializer.Deserialize<TCustomer>(json);
            return x.FName + "<br/>" + x.FPhone;
        }
        public IActionResult showCountBySession()
        {
            int count = 0;
            if (HttpContext.Session.Keys.Contains("COUNT"))
                count = (int)HttpContext.Session.GetInt32("COUNT");
            count++;
            HttpContext.Session.SetInt32("COUNT", count);
            ViewBag.COUNT = count;
            return View();
        }
        public AController(IWebHostEnvironment p)
        {
            _enviro = p;
        }
        public ActionResult demoFileUpload()
        {
            return View();
        }
        [HttpPost]
        public ActionResult demoFileUpload(IFormFile photo)
        {
            string path = _enviro.WebRootPath + "/images/001.jpg";
            photo.CopyTo(new FileStream(path, FileMode.Create));
            return View();
        }





        public IActionResult Index()
        {
            return View();
        }
        public ActionResult demoView()
        {
            return View();
        }

        public string demoInterface()
        {
            I1 x = new C2();
            return userC1(x);
        }

        [NonAction]
        private string userC1(I1 p)
        {
            return p.start();
        }

        public string sayHello()
        {
            return "Hello ASP.NET MVC.";
        }
        public string lotto()
        {
            return (new prjMvcDmeo.Models.CLottoGen()).getNumbers();
        }
    }
}
