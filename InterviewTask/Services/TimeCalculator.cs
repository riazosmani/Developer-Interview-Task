using InterviewTask.DataItems;
using System;
using System.Collections.Generic;

namespace InterviewTask.Services
{
    public class TimeCalculator : ITimeCalculator
    {
        private readonly string _day;
        private readonly int _hour;
        private readonly int _minute;
        private readonly Dictionary<string, List<int>> _serviceOpeningTimes;

        private string _message;
        private string _backgroundColour;

        public TimeCalculator(string day, int hour, int minute, Dictionary<string, List<int>> serviceOpeningTimes)
        {
            _day = day;
            _hour = hour;
            _minute = minute;
            _serviceOpeningTimes = serviceOpeningTimes;

        }

        public MessageAndColour GetOpeningTimeMessageAndColour()
        {
            if (_serviceOpeningTimes == null)
            {
                _message = string.Format("Sorry, we are unable to display any information right now");
                _backgroundColour = BackgroundColour.Grey;
            }
            else
            {
                int open = _serviceOpeningTimes[_day][0];
                int close = _serviceOpeningTimes[_day][1];
                string newDayString;
                int newDayInt = (int)DateTime.Now.DayOfWeek;

                if (open == 0)
                {
                    do
                    {
                        newDayInt = newDayInt == 6 ? 0 : newDayInt + 1;
                        newDayString = Enum.GetName(typeof(DayOfWeek), newDayInt);
                    }
                    while (_serviceOpeningTimes[newDayString][0] == 0);

                    open = _serviceOpeningTimes[newDayString][0];
                    _message = string.Format("CLOSED - REOPENS {0} at {1}", newDayString, AMPM.GiveAMPM(open));
                    _backgroundColour = BackgroundColour.Grey;
                }
                else
                {
                    if (_hour < open)
                    {
                        newDayString = Enum.GetName(typeof(DayOfWeek), newDayInt);
                        _message = string.Format("CLOSED - REOPENS {0} at {1}", newDayString, AMPM.GiveAMPM(open));
                        _backgroundColour = BackgroundColour.Grey;
                    }
                    else if ((_hour > close) || (_hour == close && _minute > 0))
                    {
                        do
                        {
                            newDayInt = newDayInt == 6 ? 0 : newDayInt + 1;
                            newDayString = Enum.GetName(typeof(DayOfWeek), newDayInt);
                        }
                        while (_serviceOpeningTimes[newDayString][0] == 0);

                        open = _serviceOpeningTimes[newDayString][0];
                        _message = string.Format("CLOSED - REOPENS {0} at {1}", newDayString, AMPM.GiveAMPM(open));
                        _backgroundColour = BackgroundColour.Grey;
                    }
                    else
                    {
                        _message = string.Format("OPEN - OPEN TODAY UNTIL {0}", AMPM.GiveAMPM(close));
                        _backgroundColour = BackgroundColour.Orange;
                    }
                }               
            }

            var messageAndColour = new MessageAndColour
            {
                Message = _message,
                BackgroundColour = _backgroundColour
            };

            return messageAndColour;
        }
    }
}