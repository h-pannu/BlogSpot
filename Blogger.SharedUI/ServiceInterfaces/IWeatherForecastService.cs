using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blogger.Shared;

namespace Blogger.SharedUI.ServiceInterfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]?> GetWeatherForecastAsync();
    }
}
