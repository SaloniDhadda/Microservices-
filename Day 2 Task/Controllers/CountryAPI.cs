using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    [RoutePrefix("api/Country")]
    public class CountryAPI : ApiController
    {
        static List<Country> Countrylist = new List<Country>()
        {
            new Country{Id=1, Name="India",Capital="Delhi"},
            new Country{Id=2, Name="Thailand",Capital="Bnagkok"},
            new Country{Id=3, Name="USA",Capital="Washington DC"},
            new Country{Id=4, Name="UK",Capital="London"},
        };
        [HttpGet]
        [Route("Countrydetails")]

        public IHttpActionResult ListAllCountries()
        {
            if (Countrylist is null)
                return NotFound();
            return Ok(Countrylist);
        }
        [HttpGet]
        [Route("GetbyId/{id}")]
        public IHttpActionResult GetbyId(int id)
        {
            Country obj = Countrylist.Find(item => item.Id == id);

            if (Countrylist is null)
                return NotFound();
            return Ok(obj);
        }
        [HttpPost]
        public IHttpActionResult AddCountry([FromBody] Country obj)
        {


            if (obj != null)
            {
                Countrylist.Add(obj);
                return Ok(obj);
            }

            return NotFound();
        }
        [HttpPut]
        [Route("UpdateCountry/{id}")]
        public IHttpActionResult UpdateCountry([FromBody] Country updateobj)
        {
            foreach (Country c in Countrylist)
            {

                if (updateobj.Id == c.Id)
                {
                    c.Name = updateobj.Name;
                    c.Capital = updateobj.Capital;
                }
            }

            return Ok(updateobj);
        }

        [HttpDelete]
        [Route("DeleteCountry/{id}")]
        public IHttpActionResult DeleteCountry(int id)
        {

            Country obj = Countrylist.Find(item => item.Id == id);

            if (Countrylist != null)
            {
                bool e = Countrylist.Remove(obj);
                if (e)
                    return Ok(obj);
            }
                return NotFound();

            }
            
        }
    }








