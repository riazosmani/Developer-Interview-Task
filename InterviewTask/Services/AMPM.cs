using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterviewTask.Services
{
    public static class AMPM
    {
        public static string GiveAMPM(int hour)
        {
            if (hour < 12) return string.Format("{0}am", hour);

            switch (hour)
            {
                case 12:
                    return string.Format("{0}pm", hour);
                case 13:
                    return string.Format("{0}pm", 1);
                case 14:
                    return string.Format("{0}pm", 2);
                case 15:
                    return string.Format("{0}pm", 3);
                case 16:
                    return string.Format("{0}pm", 4);
                case 17:
                    return string.Format("{0}pm", 5);
                case 18:
                    return string.Format("{0}pm", 6);
                case 19:
                    return string.Format("{0}pm", 7);
                case 20:
                    return string.Format("{0}pm", 8);
                case 21:
                    return string.Format("{0}pm", 9);
                case 22:
                    return string.Format("{0}pm", 10);
                case 23:
                    return string.Format("{0}pm", 11);
            }
            
            return string.Empty;
        }
    }
}