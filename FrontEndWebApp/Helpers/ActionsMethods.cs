using FrontEndWebApp.Interfaces;
using System.Net;

namespace FrontEndWebApp.Helpers
{
    public class ActionsMethods : IActionsMethods
    {
        //public const string urlAPI = "http://localhost:44323/api/";
        public const string urlAPI = "http://localhost:80/api/";
        public HttpWebRequest Action(string Method, string Controller)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAPI + Controller);
            request.Method = Method;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
        public HttpWebRequest Action(string Method, string Controller, int id)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlAPI + Controller + "/" + id);
            request.Method = Method;
            request.ContentType = "application/json";
            request.Accept = "application/json";
            return request;
        }
    }
}
