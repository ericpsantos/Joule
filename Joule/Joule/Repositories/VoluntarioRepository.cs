using Joule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joule.Repositories
{
    public class VoluntarioRepository
    {
        public IEnumerable<Voluntario> GetAll()
        {
            return DocumentDBRepository<Voluntario>.Get(x => x.Type == "Voluntario");
        }
    }
}
