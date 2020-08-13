using SiteGrupos.Bussines;
using SiteGrupos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiteGrupos.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Usuarios()
        {
            return View();
        }

        public JsonResult ListadoUsuarios()
        {
            return Json(new BUsuario().ListadoUsuarios(), JsonRequestBehavior.AllowGet);
        }
    }
}