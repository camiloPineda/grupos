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
        public void InterpretarRespuesta(dynamic respuesta)
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
                        FlightSegment nuevoSegmento = new FlightSegment();
                        Information.DepartureDateTime = result["DepartureDateTime"].ToString();
                        Information.OriginLocation = result["OriginLocation"].ToString();
                        Information.DestinationLocation = result["DestinationLocation"].ToString();

                        dynamic segmentos = opcion.ToList();
                        foreach (var segmento in segmentos)
                        {
                            var vuelo = segmento["FlightSegment"].Children();
                            int i = 0;
                            nuevoSegmento.BookingClassAvailList = new List<BookingClassAvail>();
                            foreach (var item in vuelo)
                            {
                                if (i == 0)//Datos del vuelo
                                {
                                    nuevoSegmento.DepartureDateTime = item.First["DepartureDateTime"].Value;
                                    nuevoSegmento.ArrivalDateTime = item.First["ArrivalDateTime"].Value;
                                    nuevoSegmento.StopQuantity = item.First["StopQuantity"].Value;
                                    nuevoSegmento.FlightNumber = item.First["FlightNumber"].Value;
                                    nuevoSegmento.JourneyDuration = item.First["JourneyDuration"].Value;

                                }
                                if (i == 1)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.DepartureAirport = nivel1["LocationCode"].Value;
                                }
                                if (i == 2)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.ArrivalAirport = nivel1["LocationCode"].Value;
                                }
                                if (i == 3)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.Equipment = nivel1["AirEquipType"].Value;
                                }
                                if (i == 4)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.MarketingAirline = nivel1["CompanyShortName"].Value;
                                }
                                if (i == 5)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.Meal = nivel1["MealCode"].Value;
                                }
                                if (i == 6)
                                {
                                    var nivel1 = item.First["@attributes"];
                                    nuevoSegmento.CabinType = nivel1["CabinType"].Value;
                                    nuevoSegmento.RPH = nivel1["RPH"].Value;
                                }
                                if (i == 7)
                                {

                                    for (int x = 0; x < item.First.Count; x++)
                                    {
                                        var nivel1 = item.First;
                                        var nivel2 = nivel1[x]["@attributes"];
                                        var ResBookDesigCode = nivel2["ResBookDesigCode"].Value;
                                        var ResBookDesigQuantity = nivel2["ResBookDesigQuantity"].Value;
                                        var RPH = nivel2["RPH"].Value;
                                        BookingClassAvail bookingClassAvail = new BookingClassAvail
                                        {
                                            ResBookDesigCode = ResBookDesigCode,
                                            ResBookDesigQuantity = ResBookDesigQuantity,
                                            RPH = RPH
                                        };
                                        nuevoSegmento.BookingClassAvailList.Add(bookingClassAvail);
                                    }
                                }
                                i++;
                            }
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

            //Bloque Ida
            ViewBag.DepartureDateTimeIda = InformationList[0].DepartureDateTime;
            ViewBag.OriginLocationIda = InformationList[0].OriginLocation;
            ViewBag.DestinationLocationIda = InformationList[0].DestinationLocation;
            ViewBag.OriginDestinationOptionsIda = InformationList[0].OriginDestinationOptions;

            //Bloque Regreso
            ViewBag.DepartureDateTimeRegreso = InformationList[1].DepartureDateTime;
            ViewBag.OriginLocationRegreso = InformationList[1].OriginLocation;
            ViewBag.DestinationLocationRegreso = InformationList[1].DestinationLocation;
            ViewBag.OriginDestinationOptionsRegreso = InformationList[1].OriginDestinationOptions;
        }
    }
}