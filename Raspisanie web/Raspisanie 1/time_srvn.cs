using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Raspisanie
{
    class time_srvn
    {
        DateTime now_time = DateTime.Now;
        public bool srvn(string t)
        {
            int day = now_time.Day;
            int hour = now_time.Hour;
            int minute = now_time.Minute;

            int day1 = Convert.ToInt32(t.Substring(t.Length - 17, 2));
            int hour1 = Convert.ToInt32(t.Substring(t.Length - 8, 2));
            int minute1 = Convert.ToInt32(t.Substring(t.Length - 5, 2));

            if ((day1 < day) || ((day1 == day) && (hour1 < hour)) || ((day1 == day) && (hour1 == hour) && (minute1 < minute)))
            {
                return true;
            }
            return false;
        }
    }
}
