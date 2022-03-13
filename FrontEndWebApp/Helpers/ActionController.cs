using FrontEndWebApp.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace FrontEndWebApp.Helpers
{
    public class ActionController<T> : IActionController<T>
    {
        public List<T> GetAll(HttpWebRequest httpWebRequest)
        {
            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return null;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            return JsonConvert.DeserializeObject<List<T>>(responseBody);

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
        }
        public T GetByID(HttpWebRequest httpWebRequest)
        {
            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return default(T);
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            return JsonConvert.DeserializeObject<T>(responseBody);

                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return default(T);
            }
        }
        public T Post(HttpWebRequest httpWebRequest, T Data)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(Data));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return default(T);
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            return JsonConvert.DeserializeObject<T>(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return default(T);
            }
        }
        public int Put(HttpWebRequest httpWebRequest, T data)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(data));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return 0;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            return 1;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return 0;
            }
        }
        public int Delete(HttpWebRequest httpWebRequest, T data)
        {
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                streamWriter.Write(JsonConvert.SerializeObject(data));
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = httpWebRequest.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null) return 0;
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            return 1;
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                return 0;
            }
        }
    }
}
