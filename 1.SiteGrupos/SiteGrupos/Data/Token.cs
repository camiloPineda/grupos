//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SiteGrupos.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Token
    {
        public long IdToken { get; set; }
        public string NumberToken { get; set; }
        public System.DateTime CreateDate { get; set; }
        public System.DateTime ExpireDate { get; set; }
        public bool Status { get; set; }
        public string Email { get; set; }
    }
}
