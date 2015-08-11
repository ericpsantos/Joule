using Joule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Joule.Controllers
{
    public class VoluntariosController : ApiController
    {
        // GET: api/Voluntario
        public IEnumerable<Voluntario> Get()
        {
            return new Voluntario[] { new Voluntario { Name = "Eric" }, new Voluntario { Name = "Fernando" } };
        }

        // GET: api/Voluntario/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Voluntario
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Voluntario/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Voluntario/5
        public void Delete(int id)
        {
        }
    }
}
