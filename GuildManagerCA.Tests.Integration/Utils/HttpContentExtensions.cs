using Newtonsoft.Json;
using System.Text;

namespace GuildManagerCA.Tests.Integration.Utils
{
    public static class HttpContentExtensions
    {
        public static HttpContent ToJsonHttpContent(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            return httpContent;
        }
    }
}
