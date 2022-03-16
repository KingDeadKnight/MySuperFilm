using Microsoft.Extensions.Configuration;
using MySuperFilm.ViewModels.OMdbApi;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MySuperFilm.Repositories
{
    public class OmdbApiRepository
    {
        private readonly string ApiKey;
        private readonly IHttpClientFactory HttpClientFactory;

        public OmdbApiRepository(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            this.ApiKey = config.GetValue<string>("OMDbAPI:apiKey");
            this.HttpClientFactory = httpClientFactory;
        }

        public async Task<Film> GetFilm(string name)
        {
            var httpClient = this.HttpClientFactory.CreateClient();
            var res = await httpClient.GetStringAsync($"http://www.omdbapi.com/?t={Uri.EscapeDataString(name)}&apikey={this.ApiKey}");
            return JsonConvert.DeserializeObject<Film>(res);
        }
    }
}
