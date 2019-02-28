using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace HubSpotIntegrationCore.Domain.Utils
{
    public class HttpUtils
    {
        public static T loadJson<T>(string url)
        {
            HttpWebRequest WebReq = (HttpWebRequest)WebRequest.Create(url);

            WebReq.Method = "GET";

            HttpWebResponse WebResp = (HttpWebResponse)WebReq.GetResponse();

            var stream = new StreamReader(WebResp.GetResponseStream()).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(stream);
        }
    }
}
