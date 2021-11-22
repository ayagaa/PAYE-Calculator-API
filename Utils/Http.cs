using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAYE.API.Utils
{
    public static class Http
    {
        public static string GetRequestBody(Stream Request)
        {
            if (Request != null)
            {
                using (var reader = new StreamReader(Request, Encoding.UTF8))
                {
                    return reader.ReadToEnd();
                }
            }
            return string.Empty;
        }
    }
}
