using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class EToken
    {
        public string NumberToken { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
    }
}