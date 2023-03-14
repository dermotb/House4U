using House4U.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace House4U.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        static List<Property> properties = new List<Property>()
        {
            new Property(){ID=0, Address="122 Saltwater lane", FullyDelegated=true, NumRooms=4, ExpiryDate=new DateTime(2024, 1, 1), ClientMail="jim@house4u.ie"},
            new Property(){ID=1, Address="1 The Crescent", FullyDelegated=true, NumRooms=2, ExpiryDate=new DateTime(2023, 12, 11), ClientMail="mick@wherever.ie"},
            new Property(){ID=2, Address="22 Freshwater Close", FullyDelegated=false, NumRooms=6, ExpiryDate=new DateTime(2023, 7, 1), ClientMail="ned@mybusiness.ie"},
            new Property(){ID=3, Address="29 Code St", FullyDelegated=true, NumRooms=5, ExpiryDate=new DateTime(2024, 6, 21), ClientMail="mary@thisplace.ie"},
        };


        // GET: api/<PropertyController>
        [HttpGet]
        public List<Property> Get()
        {
            return properties;
        }

        // GET api/<PropertyController>/5
        [HttpGet("{id}")]
        public Property Get(int id)
        {
            Property found = properties.FirstOrDefault(p => p.ID == id);
            return found;
        }

        [HttpGet("/AllEmails")]
        public List<string> GetAllEmails()
        {
            return properties.Select(p=>p.ClientMail).ToList();
        }

        // POST api/<PropertyController>
        [HttpPost]
        public HttpStatusCode Post([FromBody] Property value)
        {
            if (ModelState.IsValid)
            {
                Property found = properties.FirstOrDefault(p => p.ID == value.ID);
                if (found==null)
                {
                    properties.Add(value);
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.Conflict;
        }

        // PUT api/<PropertyController>/5
        [HttpPut]
        public HttpStatusCode Put([FromBody] Property value)
        {
            if (ModelState.IsValid)
            {
                Property found = properties.FirstOrDefault(p => p.ID == value.ID);
                if (found != null)
                {
                    found.NumRooms = value.NumRooms;
                    return HttpStatusCode.OK;
                }
            }
            return HttpStatusCode.Conflict;

        }

        // DELETE api/<PropertyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
