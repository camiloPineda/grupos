﻿using SiteGrupos.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SiteGrupos.Data
{
    public class DCities
    {
        public List<Cities> ListaCiudades()
        {
            try
            {
                List<Cities> Listado = new List<Cities>();
                using (ctx_grupos ctx = new ctx_grupos())
                {
                    var query = (from c in ctx.Cities where c.City_Status == true select c).ToList();
                    if (query.Count > 0)
                    {
                        Listado = query;
                    }
                }
                return Listado;
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