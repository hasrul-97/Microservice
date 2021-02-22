using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using Steeltoe.Discovery;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DMSAPI.ServiceWrapper.Utility
{
    public class WrapperUtility
    {
        private static IDiscoveryClient _client;
        private static Dictionary<string, int> Services = new Dictionary<string, int>();
        private HttpClient _httpClient;

        public WrapperUtility(IDiscoveryClient client, IHttpClientFactory factory)
        {
            _client = client;
            _httpClient = factory.CreateClient();
        }
        public async Task<string> GetInstanceURI(string serviceId)
        {
            return _client.GetInstances(serviceId)[GetInstanceCount(serviceId)].Uri.ToString();
        }
        public static int GetInstanceCount(string instanceId)
        {
            int serviceCount = 0;
            if (Services.ContainsKey(instanceId))
            {
                serviceCount = Services[instanceId] != (_client.GetInstances(instanceId).Count - 1) ? Services[instanceId] += 1 : Services[instanceId] = 0;
            }
            else
            {
                Services.Add(instanceId, 0);
            }
            return serviceCount;
        }

        public async Task<T> GetAsync<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(await _httpClient.GetAsync(url).Result.Content.ReadAsStringAsync());
        }

        public async Task<string> GetStringAsync(string url)
        {
            return (await _httpClient.GetStringAsync(url));
        }

        public async Task<string> PostAsync<T>(T data, string url)
        {
            var postData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return (await _httpClient.PostAsync(url, postData).Result.Content.ReadAsStringAsync());
        }

        public async Task<string> PutAsync<T>(T data, string url)
        {
            var putData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return (await _httpClient.PutAsync(url, putData).Result.Content.ReadAsStringAsync());
        }

        public async Task<string> DeleteAsync<T>(T data, string url)
        {
            var deleteData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            return (await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, url) { Content = deleteData }).Result.Content.ReadAsStringAsync());
        }
    }
}
