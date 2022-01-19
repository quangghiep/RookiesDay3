using System;
using Day3.Events;

namespace Day3.Business
{
    public class DisplayClock
    {
        public void Subcribe(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(TimeHasChanged);
        }

        private void TimeHasChanged(object clock, TimeInfoEventArgs args)
        {
            Console.WriteLine("{0}:{1}:{2}", args.hour, args.minute, args.second);
        }
    }
}