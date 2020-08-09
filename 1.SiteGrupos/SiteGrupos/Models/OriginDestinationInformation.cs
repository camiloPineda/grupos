using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class OriginDestinationInformation
    {
        public string DepartureDateTime { get; set; }
        public string OriginLocation { get; set; }
        public string DestinationLocation { get; set; }
        public OriginDestinationOption OriginDestinationOptions { get; set; }
    }
}