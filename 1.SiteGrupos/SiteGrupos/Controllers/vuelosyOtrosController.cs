using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SiteGrupos.Bussines;
using SiteGrupos.Data;
using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SiteGrupos.Controllers
{


    public class vuelosyOtrosController : Controller
    {

        string urlBase = "https://localhost:44300";
        // string urlBase = "https://www.grupos.co/";

        public ActionResult vuelosyOtros()
        {
            try
            {
                ManagerCookie cookie = new ManagerCookie();
                ClientCookie coookieSession = cookie.ObtenerCookie(HttpContext.Request.Cookies["userAuth"]);

                ViewData["userName"] = string.IsNullOrEmpty(coookieSession.userName) ? string.Empty : coookieSession.userName.ToString();

                if (coookieSession != null)
                {
                    return View();
                }
                return Content("<script language='javascript' type='text/javascript'>alert('Acceso no autorizado.');window.location.href = '" + urlBase + "';</script>");
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
        }
        public ActionResult cerrar()
        {
            if (Request.Cookies["userAuth"] != null)
            {
                var c = new HttpCookie("userAuth");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
            return RedirectToAction("Index", "Grupos");
        }
        public dynamic error()
        {
            return Content("<script language='javascript' type='text/javascript'>alert('Acceso no autorizado.');</script>");
        }
        public JsonResult ListadoCiudades()
        {
            return Json(new BCities().ListadoCiudades(), JsonRequestBehavior.AllowGet);
        }
        public ActionResult InterpretarRespuesta(dynamic respuesta)
        {
            var data = respuesta[0];
            JObject resultado = JObject.Parse(data);

            IList<JToken> results = resultado["OriginDestinationInformation"].Children().ToList();
            List<OriginDestinationInformation> InformationList = new List<OriginDestinationInformation>();

            foreach (JToken result in results)
            {
                OriginDestinationInformation Information = new OriginDestinationInformation();
                //Llenar ida y vuelta         
                IList<JToken> opcionesVuelo = result["OriginDestinationOptions"].Children().ToList();
                foreach (var opcion in opcionesVuelo)
                {
                    if (opcion.Path.Contains("OriginDestinationOptions.OriginDestinationOption"))
                    {
                        OriginDestinationOption ListadoOpcionVuelo = new OriginDestinationOption();
                        List<FlightSegment> ListadoSegmentosVuelos = new List<FlightSegment>();
                        Information.DepartureDateTime = result["DepartureDateTime"].ToString();
                        Information.OriginLocation = result["OriginLocation"].ToString();
                        Information.DestinationLocation = result["DestinationLocation"].ToString();

                        dynamic segmentos = opcion.ToList();
                        //varios segmentos de vuelo
                        for (int v = 0; v < segmentos[0].Count; v++)
                        {
                            var nivelsuperior = segmentos[0];
                            var vuelo = nivelsuperior[v]["FlightSegment"];
                            int i = 0;
                            List<BookingClassAvail> BookingClassAvailList = new List<BookingClassAvail>();
                            var DepartureDateTime = string.Empty;
                            var ArrivalDateTime = string.Empty;
                            var StopQuantity = string.Empty;
                            var FlightNumber = string.Empty;
                            var JourneyDuration = string.Empty;
                            var DepartureAirport = string.Empty;
                            var ArrivalAirport = string.Empty;
                            var Equipment = string.Empty;
                            var MarketingAirline = string.Empty;
                            var Meal = string.Empty;
                            var RPH = string.Empty;
                            var CabinType = string.Empty;
                            foreach (var item in vuelo)
                            {
                                if (i == 0)//Datos del vuelo
                                {
                                    DepartureDateTime = item.First["DepartureDateTime"].Value;
                                    ArrivalDateTime = item.First["ArrivalDateTime"].Value;
                                    StopQuantity = item.First["StopQuantity"].Value;
                                    FlightNumber = item.First["FlightNumber"].Value;
                                    JourneyDuration = item.First["JourneyDuration"].Value;

                                }
                                if (i == 1)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    DepartureAirport = nivel1["LocationCode"].Value;
                                }
                                if (i == 2)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    ArrivalAirport = nivel1["LocationCode"].Value;
                                }
                                if (i == 3)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    Equipment = nivel1["AirEquipType"].Value;
                                }
                                if (i == 4)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    MarketingAirline = nivel1["CompanyShortName"].Value;
                                }
                                if (i == 5)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    Meal = nivel1["MealCode"].Value;
                                }
                                if (i == 6)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    CabinType = nivel1["CabinType"].Value;
                                    RPH = nivel1["RPH"].Value;
                                }
                                if (i == 7)
                                {

                                    for (int x = 0; x < item.First.Count; x++)
                                    {
                                        var nivel1 = item.First;
                                        var nivel2 = nivel1[x]["@attributes"];
                                        var ResBookDesigCode = nivel2["ResBookDesigCode"].Value;
                                        var ResBookDesigQuantity = nivel2["ResBookDesigQuantity"].Value;
                                        var RPHBooking = nivel2["RPH"].Value;
                                        BookingClassAvail bookingClassAvail = new BookingClassAvail
                                        {
                                            ResBookDesigCode = ResBookDesigCode,
                                            ResBookDesigQuantity = ResBookDesigQuantity,
                                            RPHBooking = RPHBooking
                                        };
                                        BookingClassAvailList.Add(bookingClassAvail);
                                    }
                                }
                                i++;
                            }
                            FlightSegment nuevoSegmento = new FlightSegment
                            {
                                DepartureDateTime = DepartureDateTime,
                                ArrivalDateTime = ArrivalDateTime,
                                StopQuantity = StopQuantity,
                                FlightNumber = FlightNumber,
                                JourneyDuration = JourneyDuration,
                                DepartureAirport = DepartureAirport,
                                ArrivalAirport = ArrivalAirport,
                                Equipment = Equipment,
                                MarketingAirline = MarketingAirline,
                                Meal = Meal,
                                RPH = RPH,
                                CabinType = CabinType,
                                BookingClassAvailList = BookingClassAvailList

                            };
                            ListadoSegmentosVuelos.Add(nuevoSegmento);
                        }


                        ListadoOpcionVuelo.ListFlightSegment = ListadoSegmentosVuelos;
                        Information.OriginDestinationOptions = ListadoOpcionVuelo;
                        InformationList.Add(Information);
                    }
                    else
                    {
                        Information.DepartureDateTime = result["DepartureDateTime"].ToString();
                        Information.OriginLocation = result["OriginLocation"].ToString();
                        Information.DestinationLocation = result["DestinationLocation"].ToString();
                        Information.OriginDestinationOptions = null;
                        InformationList.Add(Information);
                    }
                }
            }
            return Json(InformationList);

        }
    }
}