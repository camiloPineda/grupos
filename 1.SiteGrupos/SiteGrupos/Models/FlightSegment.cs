using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class FlightSegment
    {
        public string DepartureDateTime { get; set; }
        public string ArrivalDateTime { get; set; }
        public string StopQuantity { get; set; }
        public string FlightNumber { get; set; }
        public string JourneyDuration { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }
        public string Equipment { get; set; }
        public string MarketingAirline { get; set; }
        public string Meal { get; set; }
        public string CabinType { get; set; }
        public string RPH { get; set; }
        public List<BookingClassAvail> BookingClassAvailList { get; set; }
    }
}