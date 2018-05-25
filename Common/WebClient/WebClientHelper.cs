using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Common.WebClient
{
    public sealed class WebClientHelper
    {
        HttpClient _client;
        private static readonly Lazy<WebClientHelper> instance = new Lazy<WebClientHelper>(() => new WebClientHelper());

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static WebClientHelper()
        {

        }

        private WebClientHelper()
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["APIPath"]);
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static WebClientHelper Instance
        {
            get
            {
                return instance.Value;

            }
        }

        public async Task<T> GetRequest<T>(T value, string uri)
        {
            HttpResponseMessage response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<T>();
                return (T)Convert.ChangeType(result, typeof(T));
            }

            return default(T);
        }

        public async Task<O> PostRequest<O, I>(I value, string uri)
        {
            var response = await _client.PostAsJsonAsync(uri, value);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsAsync<O>();
                return (O)Convert.ChangeType(result, typeof(O));
            }

            return default(O);
        }

    }
}

