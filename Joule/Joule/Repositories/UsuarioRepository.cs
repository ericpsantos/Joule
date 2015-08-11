using Joule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joule.Repositories
{
    public class UsuarioRepository
    {
        public IEnumerable<Usuario> GetAll()
        {
            return DocumentDBRepository<Usuario>.Get(x => x.Type == "Usuario");
        }
    }
}
