using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SiteGrupos.Data
{
    public class Authentication
    {
        public Agency Login(LoginRequest request)
        {
            try
            {
                Agency result = null;
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    var query = (from l in ctx.Agency
                                 where l.userName == request.userName && l.password == request.password
                                 && l.status == true
                                 select l).FirstOrDefault();
                    if (query != null)
                    {
                        result = query;
                    }
                }
                return result;
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
        }
    }
}