using InterviewTask.DataItems;
using InterviewTask.Models;
using InterviewTask.Services;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult Index(string city)
        {
            IWeatherService weatherService = new WeatherService(city);
            string weatherString = weatherService.GetWeatherString();

            if (weatherString != null)
            {
                WeatherInfo weather = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherInfo>(weatherString);

                WeatherModel wModel = new WeatherModel();
                wModel.City = weather.name;
                wModel.Description = weather.weather[0].description;
                wModel.Temperature = weather.main.temp;
                wModel.Humidity = weather.main.humidity;

                return View(wModel);
            }

            return View("ErrorMessage");
        }
    }
}