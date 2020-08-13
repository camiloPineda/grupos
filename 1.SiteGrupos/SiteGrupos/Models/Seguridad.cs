using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiteGrupos.Models
{
    public class Seguridad
    {
        /// Encripta una cadena
        public string Encriptar(string cadena)
        {
            byte[] encryted = System.Text.Encoding.Unicode.GetBytes(cadena);
            string result = Convert.ToBase64String(encryted);

            return result;
        }

        /// Esta función desencripta la cadena que le envíamos en el parámentro de entrada.
        public string desencriptar(string cadena)
        {
            string result = string.Empty;
            byte[] decryted = Convert.FromBase64String(cadena);
            //result = system.text.encoding.unicode.getstring(decryted, 0, decryted.toarray().length);
            result = System.Text.Encoding.Unicode.GetString(decryted);
            return result;
        }
    }
}