using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class DefaultController : ApiController
        {
            static List<string> mystrings = new List<string> { "Value0", "Value1", "Value2", "Value3" };

            //GET : api/Demo

            public IEnumerable<string> Get()
            {
                return mystrings;
            }

            //GET :api/Demo/2
            public string Get(int id)
            {
                return mystrings[id];
            }

            //POST 
            [HttpPost]
            //public IEnumerable<string> Post([FromUri] string val)
            //{

            //    mystrings.Add(val);
            //    return mystrings;
            //}

            public IEnumerable<string> Post([FromUri] sampleModel m)
            {
                mystrings.Add(m.name);
                return mystrings;
            }

            //Put

            public IEnumerable<string> Put(int id, [FromUri] string val)
            {
                mystrings[id - 1] = val;
                return mystrings;
            }

            //Delete

            public IEnumerable<string> Delete(int id)
            {
                mystrings.RemoveAt(id);
                return mystrings;
            }
        }
    }