using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Configuration;

namespace InterviewTask.Services
{
    public class WeatherService : IWeatherService
    {        
        private readonly string _city;
        private readonly string _weatherURL;
        private readonly string _weatherKey;
        private readonly string _units;
        private readonly string _fullURL;
        private readonly string _weatherString;

        public WeatherService(string city)
        {
            _city = city;
            _weatherURL = WebConfigurationManager.AppSettings["WeatherURL"];
            _weatherKey = WebConfigurationManager.AppSettings["WeatherKey"];
            _units = WebConfigurationManager.AppSettings["Units"];
            _fullURL = string.Format("{0}?q={1}&appid={2}&units={3}", _weatherURL, _city, _weatherKey, _units);


            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(_fullURL).Result;
            if (response.IsSuccessStatusCode)
            {
                _weatherString = response.Content.ReadAsStringAsync().Result;
            }
            else
            {
                // throw an exception
            }
        }

        public string GetWeatherString()
        {
            return _weatherString;
        }
    }
}