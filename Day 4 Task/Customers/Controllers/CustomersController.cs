using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        // GET: api/<CustomersController>
        static List<CustomersModel> CustomersList = new List<CustomersModel>()
        {
            new CustomersModel(){CustomerId =1, CustomerName = "Jack", CustomerPhone=9999999},
            new CustomersModel(){CustomerId =2, CustomerName = "Joe", CustomerPhone=1199999},
        };
        // GET api/<CustomersController>/5
        [HttpGet]
        public List<CustomersModel> Get()
        {
            return CustomersList;
        }
        [HttpGet("{id}")]
        public CustomersModel Get(int id)
        {
            CustomersModel obj = CustomersList.Find(item => item.CustomerId == id);
            return obj;
        }

        // POST api/<CustomersController>
        [HttpPost]
        public List<CustomersModel> Post([FromBody] CustomersModel obj)
        {
            CustomersList.Add(obj);
            return CustomersList;
        }


        // PUT api/<CustomersController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CustomersModel updateobj)
        {
            CustomersModel oldobj = CustomersList.Find(item => item.CustomerId == id);
            if (oldobj != null)
            {
                CustomersList.Insert(id - 1, updateobj);
                CustomersList.Remove(oldobj);
                return Ok();
            }
            return NotFound("Error");
        }

        // DELETE api/<CustomersController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            CustomersModel obj = CustomersList.Find(item => item.CustomerId == id);
            if (obj != null)
            {
                CustomersList.Remove(obj);
                return Ok();

            }

            return NotFound("Error");
        }
    }
}

