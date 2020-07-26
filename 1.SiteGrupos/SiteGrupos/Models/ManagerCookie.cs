using Newtonsoft.Json;
using SiteGrupos.Exception;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class ManagerCookie
    {
        public HttpCookie CrearCookie(ClientCookie obj)
        {
            string json = JsonConvert.SerializeObject(obj);//pasamos de objeto a json 
            string encriptJson = new DecryptAndEncrypt().Encrypt(json);
            // Para crear una cookie
            HttpCookie cookie = new HttpCookie("userAuth");
            cookie["Data"] = encriptJson;
            //cookie.Expires = DateTime.Now.AddDays(1d);
            cookie.Expires = DateTime.Today.AddDays(1).AddSeconds(-1);


            //cookie.HttpOnly = true;
            //cookie.Secure = true;
            return cookie;
        }

        public ClientCookie ObtenerCookie(HttpCookie Cookie)
        {
            try
            {
                if (Cookie != null)
                {
                    string Data = Cookie["Data"];
                    string json = new DecryptAndEncrypt().Decrypt(Data);
                    return JsonConvert.DeserializeObject<ClientCookie>(json); //pasamos de json a objeto 
                }
                else
                {
                    return null;
                }
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
