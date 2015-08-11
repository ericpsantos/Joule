using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Joule.Models
{
    public class Usuario : Pessoa
    {
        public string[] Programs { get; set; }
        public string CurrentProfile { get; set; }
        public string About { get; set; }
    }
}
