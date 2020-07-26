using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SiteGrupos.Models
{
    [DataContract]
    public class Resultado
    {
        [DataMember(Order = 1)]
        public int Respuesta { get; set; }

        [DataMember(Order = 2)]
        public string Mensaje { get; set; }
    }
}