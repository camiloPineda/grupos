using SiteGrupos.Bussines;
using SiteGrupos.Data;
using SiteGrupos.Exception;
using SiteGrupos.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace SiteGrupos.Controllers
{
    public class RecuperarPasswordController : Controller
    {
        ClientCookie obj = new ClientCookie();
        // GET: RecuperarPassword
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AsignarPassword(string d, string tokenNumber)
        {
            ManagerCookie cookie = new ManagerCookie();
            obj.userName = d;
            HttpContext.Response.Cookies.Add(cookie.CrearCookie(obj));
            return View();
        }
        public ActionResult CambiarPassword(string tokenNumber, string passwordChange)
        {
            string emailDesencriptado = string.Empty;
            ManagerCookie cookie = new ManagerCookie();
            ClientCookie coookieSession = cookie.ObtenerCookie(HttpContext.Request.Cookies["userAuth"]);
            string emailEncriptado = string.IsNullOrEmpty(coookieSession.userName) ? string.Empty : coookieSession.userName.ToString();
            if (!emailEncriptado.IsEmpty())
            {
                Seguridad seguridad = new Seguridad();
                emailDesencriptado = seguridad.desencriptar(emailEncriptado);
            }
            long respuesta = new BRecuperarPassword().CambiarPassword(emailDesencriptado, tokenNumber, passwordChange);
            return Json(respuesta);
        }
        public ActionResult EnviarCorreoRecuperacion(string email)
        {
            int respuesta = 0;//0 => correo no existe, 1 => error al enviar correo, 2 => correo enviado
            try
            {
                bool correoExistente = new BRecuperarPassword().CorreoExistente(email);
                if (correoExistente)
                {
                    string token = tokenNumber();
                    if (token != "")
                    {
                        EToken nuevoToken = new EToken
                        {
                            NumberToken = token,
                            CreateDate = DateTime.Now,
                            ExpireDate = DateTime.Now.AddMinutes(5),
                            Email = email,
                            Status = true
                        };
                        long IdToken = new BRecuperarPassword().CrearToken(nuevoToken);
                        if (IdToken > 0)
                        {
                            long resultado = sendMail(nuevoToken);
                            if (resultado > 0)//email enviado
                            {
                                respuesta = 2;//enviado
                            }
                            else
                            {
                                resultado = 1;
                            }
                        }
                    }
                }
                else
                {
                    respuesta = 0;//no existe
                }
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
            return Json(respuesta);
        }
        private static string tokenNumber()
        {
            string number = "";
            try
            {
                int _min = 10000;
                int _max = 99999;
                Random _rdm = new Random();
                var randomNumber = _rdm.Next(_min, _max);
                number += randomNumber;
                return number;
            }
            catch (GettingException ex)
            {
                StackTrace st = new StackTrace(ex, true);
                StackFrame frame = st.GetFrame(0);
                throw new GettingException(string.Format("{0}", "Error: " + ex.Message.ToString() + " Origen: " + ex.TargetSite.ReflectedType.FullName.ToString() + " Metodo: " + frame.GetMethod().Name.ToString() + " Linea: " + frame.GetFileLineNumber().ToString()));
            }
        }
        private static long sendMail(EToken token)
        {
            long result = -1;

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress("notificaciones@grupos.co");
            message.To.Add(new MailAddress(token.Email));
            message.Subject = "Grupos - Recordar Contraseña";
            message.IsBodyHtml = true;
            message.Body = getHtml(token);
            smtp.Port = 25;
            smtp.Host = "190.8.176.202";
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("notificaciones@grupos.co", "Grupos2020*");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
                result = 1;
            }
            catch (SmtpException ex)
            {
                return result;
            }
            return result;
        }
        private static string getHtml(EToken token)
        {
            Seguridad seguridad = new Seguridad();
            var emailEncriptado = seguridad.Encriptar(token.Email);
            var url = "https://localhost:44300/RecuperarPassword/AsignarPassword?d=" + emailEncriptado;
            string html = @"<div bgcolor='#f3f3f3' style='margin:5px 0 0 0;padding:0;background-color:#f3f3f3'><p></p>"
        + "<table bgcolor = '#f3f3f3' border='0' cellpadding='0' cellspacing ='0' style = 'color:#4a4a4a;font-family:'Museo Sans Rounded',Museo Sans Rounded,'Museo Sans',Museo Sans,'Helvetica Neue',Helvetica,Arial,sans-serif;font-size:14px;line-height:20px;border-collapse:callapse;border-spacing:0;margin:0 auto' width='100%'>"
        + "<tbody><tr><td style ='padding-left:20px;padding-right:20px'><table align ='center' border ='0' cellpadding = '0 cellspacing = '0' style = 'width:100%;margin:0 auto;max-width:600px' width = '100%'>"
        + "<tbody><tr style = 'background: white;font-weight: bold;'><td style = 'text-align:center;padding-top:3%'>CAMBIAR CONTRASEÑA</td></tr><tr><td bgcolor = '#ffffff' style = 'background-color:#ffffff;padding:9%'>"
        + "<table border = '0' cellpadding = '0' cellspacing = '0' id = 'm_-740823046140379716intro' style = 'width:100%;margin:0 auto'><tbody><tr><td style = 'max-width:600px' width = '100%'>"
        + "Tu código es <b>[token]</b>, recuerda que será valido por 5 minutos.<br><br>Ingresa a la siguiente dirección para cambiar tu contraseña: [url]</td></tr></tbody></table></td></tr>"
        + "<tr><td border = '0' cellpadding='0' cellspacing='0' style='padding:20px 0' width='100%'><table border = '0' cellpadding='0' cellspacing='0' style='border-collapse:collapse' width='100%'>"
        + "<tbody><tr>"
        + "<td style = 'padding:20px' width='100%'><div style = 'margin:0;text-align:center;font-size:12px;color:#bbbbbb'> NO RESPONDER - Mensaje Generado Automáticamente</div><div style = 'margin:0;font-size:11px;text-align:center;color:#bbbbbb' >©2020 Grupos.co | Bogotá, Colombia</div>"
        + "</td></tr></tbody></table></td></tr></tbody></table></td></tr></tbody></table></div>";
            html = html.Replace("[token]", token.NumberToken.ToString());
            html = html.Replace("[url]", url);

            return html;
        }
    }
}