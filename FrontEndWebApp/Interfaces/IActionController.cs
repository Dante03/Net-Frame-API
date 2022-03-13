using System.Collections.Generic;
using System.Net;

namespace FrontEndWebApp.Interfaces
{
    public interface IActionController<T>
    {
        List<T> GetAll(HttpWebRequest httpWebRequest);
        T GetByID(HttpWebRequest httpWebRequest);
        T Post(HttpWebRequest httpWebRequest, T data);
        int Put(HttpWebRequest httpWebRequest, T data);
        int Delete(HttpWebRequest httpWebRequest, T data);
    }
}
