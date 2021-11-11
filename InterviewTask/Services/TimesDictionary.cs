using InterviewTask.Models;
using System.Collections.Generic;

namespace InterviewTask.Services
{
    public static class TimesDictionary
    {
        private static Dictionary<string, List<int>> _serviceOpeningTimes;
        private static List<int> _openingTimes;

        public static Dictionary<string, List<int>> GetTimesDictionary(HelperServiceModel helperServiceModel)
        {
            if (helperServiceModel.MondayOpeningHours == null) return null;

            _serviceOpeningTimes = new Dictionary<string, List<int>>();
            _openingTimes = new List<int>
            {
                helperServiceModel.MondayOpeningHours[0],
                helperServiceModel.MondayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Monday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.TuesdayOpeningHours[0],
                helperServiceModel.TuesdayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Tuesday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.WednesdayOpeningHours[0],
                helperServiceModel.WednesdayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Wednesday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.ThursdayOpeningHours[0],
                helperServiceModel.ThursdayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Thursday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.FridayOpeningHours[0],
                helperServiceModel.FridayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Friday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.SaturdayOpeningHours[0],
                helperServiceModel.SaturdayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Saturday", _openingTimes);
            _openingTimes = new List<int>
            {
                helperServiceModel.SundayOpeningHours[0],
                helperServiceModel.SundayOpeningHours[1]
            };
            _serviceOpeningTimes.Add("Sunday", _openingTimes);

            return _serviceOpeningTimes;
        }
    }
}