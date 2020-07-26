using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SiteGrupos.Data
{
    public class Register
    {
        public long AgregarRegistro(Registro data)
        {
            try
            {
                var result = -1;
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    Agency objAgency = new Agency
                    {
                        documentType = data.documentType,
                        agencyName = data.agencyName,
                        contactType = data.contactType,
                        contactName = data.contactName,
                        cityName = data.cityName,
                        phoneNumber = data.phoneNumber,
                        emailAddress = data.emailAddress,
                        userName= data.emailAddress,
                        password = data.password,
                        terminos = data.terminos,
                        status = false
                    };
                    ctx.Agency.Add(objAgency);
                    ctx.SaveChanges();
                    result = objAgency.agencyId;
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
        public bool ValdidarEmail(string email)
        {
            try
            {
                bool result = false;
                using(ctx_grupos ctx = new ctx_grupos())
                {
                    var query = (from u in ctx.Agency where u.emailAddress == email select u).FirstOrDefault();
                    if(query != null)
                    {
                        result = true;
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