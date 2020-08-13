using SiteGrupos.Data;
using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SiteGrupos.Bussines
{
    public class BRecuperarPassword
    {
        public bool CorreoExistente(string email)
        {
            try
            {
                return new DRecuperarPassword().CorreoExistente(email);
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
        }
        public long CrearToken(EToken token)
        {
            try
            {
                long IdToken = new DRecuperarPassword().CrearToken(token);
                return IdToken;
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
        }
        public long CambiarPassword(string correo, string token, string password)
        {
            try
            {
                long respuesta = -1;
                respuesta = new DRecuperarPassword().CambiarPassword(correo, token, password);
                return respuesta;
            }
            catch (GettingException)
            {
                return 2;
            }
        }
    }
}