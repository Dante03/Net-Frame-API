using System.Net;

namespace FrontEndWebApp.Interfaces
{
    public interface IActionsMethods
    {
        HttpWebRequest Action(string Method, string Controller, int id);
        HttpWebRequest Action(string Method, string Controller);
    }
}
