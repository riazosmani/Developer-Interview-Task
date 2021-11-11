using InterviewTask.Models;
using InterviewTask.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InterviewTask.Controllers
{
    public class HomeController : Controller
    {
        /*
         * Prepare your opening times here using the provided HelperServiceRepository class.       
         */
        public ActionResult Index()
        {
            IIPAddressService ipAddressService = new IPAddressService();
            ipAddressService.Go();

            IHelperServiceRepository serviceRepository = new HelperServiceRepository();
            var services = serviceRepository.Get();
            var displays = new List<DisplayInfoModel>();
            IOpeningTimeCreator creator;

            DisplayInfoModel display;
            foreach (var service in services)
            {
                display = new DisplayInfoModel
                {
                    Title = service.Title,
                    Description = service.Description,
                    TelephoneNumber = service.TelephoneNumber,
                    WeatherLocation = service.WeatherLocation
                };

                creator = new OpeningTimeCreator(service);
                var messageAndColour = creator.CreateOpeningTimeMessageAndColour();
                display.OpeningTimeMessage = messageAndColour.Message;
                display.BackgroundColour = messageAndColour.BackgroundColour.ToString();

                displays.Add(display);
            }

            return View(displays);
        }
    }
}