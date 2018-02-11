using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http.Formatting;
using System.Net.Http;
using JSONPDemo.Controllers;

namespace JSONPDemo
{
    public class MyJSONPFormatter : MediaTypeFormatter
    {
        public MyJSONPFormatter()
        {
            this.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/javascript"));

        }

        public override Task WriteToStreamAsync(Type type, object value, Stream writeStream, HttpContent content, TransportContext transportContext)
        {
            return Task.Factory.StartNew(() =>
            {
                var jsonp = (JSONPReturn)value;
                var sw = new StreamWriter(writeStream, UTF8Encoding.Default);
                sw.Write("{0}({1});", jsonp.Callback, jsonp.JSON);
                sw.Flush();
            });
        }

        public override bool CanWriteType(Type type)
        {
            return type == (typeof(JSONPReturn));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }
    }
}
