using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace SiteGrupos.Exception
{
    public class GettingException : ApplicationException
    {
        public GettingException()
        {
        }

        public GettingException(string message) : base(message)
        {
        }

        public GettingException(string message, ApplicationException innerException) : base(message, innerException)
        {
        }

        protected GettingException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}