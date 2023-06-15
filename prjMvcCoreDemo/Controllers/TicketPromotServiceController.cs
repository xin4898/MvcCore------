using Microsoft.AspNetCore.Mvc;
using prjMvcCoreDemo.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace prjMvcCoreDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketPromotServiceController : ControllerBase
    {
        // GET: api/<TicketPromotServiceController>
        [HttpGet]
        public IEnumerable<TProduct> Get()
        {
            DbDemoContext db = new DbDemoContext();
            var datas = from p in db.TProducts
                        select p;
            foreach(var i in datas)
            {
                i.FCost = 0;
                if (i.FQty >= 50)
                    i.FQty = 50;
            }
            return datas;
        }

        // GET api/<TicketPromotServiceController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TicketPromotServiceController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TicketPromotServiceController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TicketPromotServiceController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
