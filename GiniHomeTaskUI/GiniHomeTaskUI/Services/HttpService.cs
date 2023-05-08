using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using System.Security.Policy;
using System.Threading;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace GiniHomeTaskUI.Services
{
    internal class HttpService
    {
        public static async Task<object> GetRequest(string API)
        {
            try
            {
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:3000")
                };
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await client.GetAsync(API))
                {
                    if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return "Bad request";
                    }

                    return await response.Content.ReadAsStringAsync();
                }
            }catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        public static async Task<bool> PostRequest(string API, object value)
        {
            JObject o = (JObject)JToken.FromObject(value);
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri($"http://localhost:3000")
            };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await client.PostAsJsonAsync(API, o);
                var result = await response.Content.ReadAsStringAsync();

                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
