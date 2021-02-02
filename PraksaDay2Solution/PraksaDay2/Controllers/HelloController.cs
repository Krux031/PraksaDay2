using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PraksaDay2.Controllers
{
    public class HelloController : ApiController
    {
        public static List<string> popis = new List<string>() { "kruh", "mlijeko" , "jaja", "riza", "banane", "sok"};

        public List<string> Get()
        {
            return popis;
        }
        public HttpResponseMessage Post([FromBody]string item)
        {
            popis.Add(item);
            return Request.CreateResponse(HttpStatusCode.OK, "OK");
        }
        public HttpResponseMessage Put ([FromBody] string item)
        {
            if(popis.Contains(item) == false)
            {
                popis.Add(item);
                return Request.CreateResponse(HttpStatusCode.Created, "Created");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NoContent, "No Content");
            }

        }
        public HttpResponseMessage Delete([FromBody] string item)
        {
            if (popis.Contains(item) == true)
            {
                popis.Remove(item);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "Not Found");
            }
        }

    }
}
