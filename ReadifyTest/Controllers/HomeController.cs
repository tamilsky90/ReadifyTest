using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReadifyTest.Common;

namespace ReadifyTest.Controllers
{
    [RoutePrefix("api")]
    public class HomeController : ApiController
    {
        [Route("Fibonacci/{n}")]
        [HttpGet]
        public HttpResponseMessage Fibonacci(int n)
        {

            int a = 0, b = 1, c = 0;
            for (int i = 2; i <= n; i++)
            {
                c = a + b;
                a = b;
                b = c;
            }
            return Request.CreateResponse(HttpStatusCode.OK, c);
        }

        [Route("ReverseWords/{sentence}")]
        [HttpGet]
        public HttpResponseMessage ReverseWords(string sentence)
        {
            var reversedWords = string.Join(" ",
      sentence.Split(' ')
         .Select(x => new String(x.Reverse().ToArray())));
            return Request.CreateResponse(HttpStatusCode.OK, reversedWords);
        }

        [Route("Token")]
        [HttpGet]
        public HttpResponseMessage Token()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "86e658e8-b4ba-446d-b43d-d2b96a2e2b97");
        }

        [Route("TriangleType/{a}/{b}/{c}")]
        [HttpGet]
        public HttpResponseMessage TriangleTypes(int a,int b,int c)
        {
            int[] values = new int[3] { a, b, c };
            if (a <= 0 || b <= 0 || c <= 0||values.Min()*2<=values.Max())
            {
                return Request.CreateResponse(HttpStatusCode.OK, TriangleType.Error.ToString());
            }
            else if (values.Distinct().Count() == 1)
            {
                return Request.CreateResponse(HttpStatusCode.OK,TriangleType.Equilateral.ToString());
            }
            else if (values.Distinct().Count() == 2)
            {
                return Request.CreateResponse(HttpStatusCode.OK,TriangleType.Isosceles.ToString());
            }
            else if (values.Distinct().Count() == 3)
            {
                return Request.CreateResponse(HttpStatusCode.OK,TriangleType.Scalene.ToString().ToString());
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK,TriangleType.Error);
            }

        }
       
    }
}