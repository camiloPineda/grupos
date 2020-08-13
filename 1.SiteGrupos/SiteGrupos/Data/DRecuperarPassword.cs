using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Management;

namespace SiteGrupos.Data
{
    public class DRecuperarPassword
    {
        public bool CorreoExistente(string correo)
        {
            try
            {
                bool existe = false;
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    var query = (from c in ctx.Agency where c.emailAddress == correo select c).FirstOrDefault();
                    if (query != null)
                    {
                        existe = true;
                    }
                }
                return existe;
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
                long IdToken = -1;
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    Token nuevoToken = new Token
                    {
                        NumberToken = token.NumberToken,
                        CreateDate = token.CreateDate,
                        ExpireDate = token.ExpireDate,
                        Email = token.Email,
                        Status = token.Status
                    };
                    ctx.Token.Add(nuevoToken);
                    ctx.SaveChanges();
                    IdToken = nuevoToken.IdToken;
                }
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
                long respuesta = -1;//1 => token no valido, 2=> password NO cambiada 3=> password Cambiada
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    var query = (from a in ctx.Agency
                                 join t in ctx.Token on a.emailAddress equals t.Email
                                 where a.emailAddress == correo && t.NumberToken == token
                                 && t.ExpireDate > DateTime.Now && t.Status == true
                                 select a).FirstOrDefault();
                    if (query != null)//token valido
                    {
                        query.password = password;
                        var tokenUsado = (from t in ctx.Token where t.NumberToken == token select t).FirstOrDefault();
                        if (tokenUsado != null)
                        {
                            tokenUsado.Status = false;
                        }
                        ctx.SaveChanges();
                        respuesta = 3;
                    }
                    else
                    {
                        respuesta = 1;
                    }
                }

                return respuesta;
            }
            catch (GettingException)
            {
                return 2;
            }
        }
    }
}