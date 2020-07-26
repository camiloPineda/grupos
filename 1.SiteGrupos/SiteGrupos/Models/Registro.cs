using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class Registro
    {
        public string documentType { get; set; }
        public string agencyName { get; set; }
        public string contactType { get; set; }
        public string contactName { get; set; }
        public string cityName { get; set; }
        public string phoneNumber { get; set; }
        public string emailAddress { get; set; }
        public string password { get; set; }
        public bool terminos { get; set; }
    }
}