using SiteGrupos.Data;
using SiteGrupos.Models;
using System.Web.Mvc;
using System.Net;
using SiteGrupos.Controllers;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using SiteGrupos.Bussines;

namespace SitioGrupos.Controllers
{
    [AllowAnonymous]
    public class GruposController : Controller
    {
        string urlBase = "https://localhost:44300";
        //string urlBase = "https://www.grupos.co/";
        string TokenGenerado = string.Empty;
        ClientCookie obj = new ClientCookie();

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registrate(Registro registro)
        {
            Register register = new Register();
            var result = new BLogin().AgregarRegistro(registro);
            if (result != -1)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
        public ActionResult Login(LoginRequest request)
        {
            var result = new LoginController().Login(request);

            if (result.Count() > 0)
            {
                crearCookieNavegador(result[0]);
                var redirectUrl = new UrlHelper(Request.RequestContext).Action("vuelosyOtros", "vuelosyOtros");
                return Json(new { Url = urlBase + redirectUrl, jwt = result });
            }
            else
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public void crearCookieNavegador(DataResult datos)
        {
            ManagerCookie cookie = new ManagerCookie();
            obj.token = datos.token;
            obj.userName = datos.userName;

            //Obtiene el listado de cookies guardadas en la BD, utiliza el servicio RetornarCookies que recibe como parametro el número de Linea
            //Obtiene los objetos del Json de respuesta 
            HttpContext.Response.Cookies.Add(cookie.CrearCookie(obj));


        }

        private static IEnumerable<JToken> AllChildren(JToken json)
        {
            foreach (var c in json.Children())
            {
                yield return c;
                foreach (var cc in AllChildren(c))
                {
                    yield return cc;
                }
            }
        }
    }
}

