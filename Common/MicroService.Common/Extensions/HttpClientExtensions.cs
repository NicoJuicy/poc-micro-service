using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class HttpClientExtensions
    {
        public static async Task<T> GetJsonAsync<T>(this HttpClient client, string url)
        {
            return await System.Text.Json.JsonSerializer.DeserializeAsync<T>(await client.GetStreamAsync(url));
        }
    }
}
