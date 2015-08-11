using Joule.Models;
using Joule.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Joule.Controllers
{
    public class VoluntariosController : ApiController
    {
        VoluntarioRepository voluntarioRepository = new VoluntarioRepository();
        // GET: api/Voluntario
        public IEnumerable<Voluntario> Get()
        {
            var voluntarios = voluntarioRepository.GetAll();
            //return new Voluntario[] { new Voluntario { Name = "Eric" }, new Voluntario { Name = "Fernando" } };
            return voluntarios;
        }

        // GET: api/Voluntario/5
        public HttpResponseMessage Get(string id)
        {
            try
            {
                Voluntario voluntario = DocumentDBRepository<Voluntario>.Get(x => x.Id == id).FirstOrDefault();

                return Request.CreateResponse<Voluntario>(HttpStatusCode.OK, voluntario);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }            
        }

        // POST: api/Voluntario
        public async Task<HttpResponseMessage> Post([FromBody]Voluntario voluntario)
        {
            voluntario.Type = "Voluntario";
            try
            {
                await DocumentDBRepository<Voluntario>.CreateItemAsync(voluntario);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // PUT: api/Voluntario/5
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Voluntario voluntario)
        {
            voluntario.Type = "Voluntario";
            try
            {
                await DocumentDBRepository<Voluntario>.UpdateItemAsync(id, voluntario);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Voluntario/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                await DocumentDBRepository<Voluntario>.DeleteItemAsync(id);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
