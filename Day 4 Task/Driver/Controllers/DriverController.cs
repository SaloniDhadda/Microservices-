using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Driver.Controllers
{
        [Route("api/[controller]")]
        [ApiController]
        public class DriverController : ControllerBase
    {
        static List<DriverModel> driverList = new List<DriverModel>()
        {
            new DriverModel(){DriverId =1, DriverName = "Micheal", Rating= 5, Phoneno=9999999},
            new DriverModel(){DriverId =2, DriverName = "Mike", Rating= 5, Phoneno=1199999},
        };
        // GET api/<DriverController>/5
        [HttpGet]
        public List<DriverModel>Get()
        {
            return  driverList;
        }
        [HttpGet("{id}")]
            public DriverModel Get(int id)
            {
            DriverModel obj = driverList.Find(item => item.DriverId == id);
            return obj;
            }

            // POST api/<DriverController>
            [HttpPost]
            public List<DriverModel> Post([FromBody] DriverModel obj)
        {
            driverList.Add(obj);
            return driverList;
        }
       

            // PUT api/<DriverController>/5
            [HttpPut("{id}")]
            public IActionResult Put(int id, [FromBody] DriverModel updateobj)
            {
            DriverModel oldobj = driverList.Find(item => item.DriverId == id);
            if(oldobj != null)
            {
                driverList.Insert(id - 1, updateobj);
                driverList.Remove(oldobj);
                return Ok();
            }
            return NotFound("Error");
            }

            // DELETE api/<DriverController>/5
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
            DriverModel obj = driverList.Find(item => item.DriverId == id);
            if(obj != null)
            {
                driverList.Remove(obj);
                return Ok();

            }

            return NotFound("Error");
            }
        }
    }
