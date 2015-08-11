using Joule.Models;
using Joule.Repositories;
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
            var voluntarios = DocumentDBRepository<Voluntario>.GetAllVoluntarios();
            //return new Voluntario[] { new Voluntario { Name = "Eric" }, new Voluntario { Name = "Fernando" } };
            return voluntarios;
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
