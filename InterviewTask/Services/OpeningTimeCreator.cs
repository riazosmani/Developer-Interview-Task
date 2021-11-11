using InterviewTask.DataItems;
using InterviewTask.Models;
using System;
using System.Collections.Generic;

namespace InterviewTask.Services
{
    public class OpeningTimeCreator : IOpeningTimeCreator
    {
        private readonly HelperServiceModel _helperServiceModel;
        private MessageAndColour _messageAndColour;

        private Dictionary<string, List<int>> _serviceOpeningTimes;

        public OpeningTimeCreator(HelperServiceModel helperServiceModel)
        {
            _helperServiceModel = helperServiceModel;
        }

        public MessageAndColour CreateOpeningTimeMessageAndColour()
        {
            DateTime now = DateTime.Now;
            string day = now.DayOfWeek.ToString();
            int hour = now.Hour;
            int minute = now.Minute;

            _serviceOpeningTimes = TimesDictionary.GetTimesDictionary(_helperServiceModel);

            ITimeCalculator timeCalculator;     
            timeCalculator = new TimeCalculator(day, hour, minute, _serviceOpeningTimes);
            _messageAndColour = timeCalculator.GetOpeningTimeMessageAndColour();
            
            return _messageAndColour;
        }
    }
}