using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace KVaas.Net
{
    public static class KVaaSClient
    {
        private static string HTTP_API_PREFIX = "https://api.keyvalue.xyz";

        private static string USER_AGENT = "api.keyvalue.xyz .Net API/1.0";
        
        static KVaaSClient()
        {

        }
       
        public static async Task<string> NewKey(string key)
        {
            string action = $"new/{key}";
            var result = await PostRequest(action);

            // return token
            var matches = Regex.Match(result, $@"{HTTP_API_PREFIX}/?(\w+)/{key}");
            
            return matches.Groups[1].Value;
        }
      
        public static async Task<string> GetValue(string token, string key)
        {
            string action = $"{token}/{key}";
            var result = await GetRequest(action);
            return result.Replace("\r\n", string.Empty)
                .Replace("\n", string.Empty)
                .Replace("\r", string.Empty);
        }
       
        public static async Task<string> PutValue(string token, string key, string value)
        {
            string action = $"{token}/{key}";
            var result = await PostRequest(action, value);
            return result;
        }

        private static async Task<string> GetRequest(string action)
        {
            string url = $"{HTTP_API_PREFIX}/{action}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var result = await client.GetStringAsync(url);

                return result;
            }
        }

        private static async Task<string> PostRequest(string action, string value = "")
        {
            string url = $"{HTTP_API_PREFIX}/{action}";

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var result = await client.PostAsync(url, new StringContent(value));

                if(result.StatusCode != HttpStatusCode.OK)
                    throw new Exception(result.ReasonPhrase);

                return await result.Content.ReadAsStringAsync();
            }
        }
    }
}
