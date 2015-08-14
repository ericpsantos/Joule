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
    public class UsuariosController : ApiController
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        // GET: api/Usuario
        public IEnumerable<Usuario> Get()
        {
            var Usuarios = usuarioRepository.GetAll();

            return Usuarios;
        }

        // GET: api/Usuario/5
        public HttpResponseMessage Get(string id)
        {
            try
            {
                Usuario Usuario = DocumentDBRepository<Usuario>.Get(x => x.Id == id).FirstOrDefault();

                return Request.CreateResponse<Usuario>(HttpStatusCode.OK, Usuario);
            }
            catch
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Not Found");
            }
        }

        // POST: api/Usuario
        public async Task<HttpResponseMessage> Post([FromBody]Usuario usuario)
        {
            usuario.Type = "Usuario";
            try
            {
                await DocumentDBRepository<Usuario>.CreateItemAsync(usuario);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, e);
            }

            SendGridService sendGrid = new SendGridService();

            try
            {
                sendGrid.SendWelcomeEmail(usuario);
            } catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.ServiceUnavailable, e.Message);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // PUT: api/Usuario/5
        public async Task<HttpResponseMessage> Put(string id, [FromBody]Usuario usuario)
        {
            usuario.Type = "Usuario";
            try
            {
                await DocumentDBRepository<Usuario>.UpdateItemAsync(id, usuario);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        // DELETE: api/Usuario/5
        public async Task<HttpResponseMessage> Delete(string id)
        {
            try
            {
                await DocumentDBRepository<Usuario>.DeleteItemAsync(id);
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}
