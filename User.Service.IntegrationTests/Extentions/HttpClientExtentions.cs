using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using User.Service.API.Domian.Models;

namespace User.Service.IntegrationTests.Extentions
{
    public static class HttpClientExtentions
    {
        public static async Task<HttpResponseMessage> PostAsyncAsJson<T>(this HttpClient client, string uri, T entity)
        {
            var stringContent = ParseToStringContent(entity);
            return await client.PostAsync(uri, stringContent);
        }

        public static async Task<HttpResponseMessage> PutAsyncAsJson<T>(this HttpClient client, string uri, T entity)
        {
            var stringContent = ParseToStringContent(entity);
            return await client.PutAsync(uri, stringContent);
        }

        private static StringContent ParseToStringContent<T>(T entity)
        {
            var json = JsonConvert.SerializeObject(entity);
            return new StringContent(json, UnicodeEncoding.UTF8, "application/json");
        }
    }
}
