using System.Net.Http.Json;
using Blogger.Shared;
using Blogger.SharedUI.ServiceInterfaces;
using static System.Net.WebRequestMethods;

namespace Blogger.Client.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly HttpClient http;

        //public WeatherForecastService(HttpClient http)
        //{
        //    this.http = http;
        //}

        public WeatherForecastService(HttpClient http) => this.http = http;

        //public Task<WeatherForecast[]?> GetWeatherForecastAsync()
        //{
        //    return http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
        //}

        public Task<WeatherForecast[]?> GetWeatherForecastAsync() => http.GetFromJsonAsync<WeatherForecast[]>("WeatherForecast");
    }
}
