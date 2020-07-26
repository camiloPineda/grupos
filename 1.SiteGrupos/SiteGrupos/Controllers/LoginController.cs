using SiteGrupos.Bussines;
using SiteGrupos.Models;
using System.Collections.Generic;
using System.Web.Http;

namespace SiteGrupos.Controllers
{
    public class LoginController : ApiController
    {
        public List<DataResult> Login(LoginRequest login)
        {
            var resultado = new BLogin().ValidarAcceso(login);
            return resultado;
        }
    }
}
