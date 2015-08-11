using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Joule.Models
{
    public class Voluntario : Pessoa
    {
        public double YearsOfExperience { get; set; }
        public string CurrentEmployer { get; set; }
        public string CurrentPosition { get; set; }
        public string[] PastEmployers { get; set; }
        public string[] WorkSegments { get; set; }
        public string[] WorkAreas { get; set; }
        public string Degree { get; set; }
        public string LinkedInProfile { get; set; }
        public string[] Programs { get; set; }
        public string CurrentProfile { get; set; }
        public string About { get; set; }
        
    }
}