using System;
using Day3.Business;
using Day3.Events;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DisplayClock view = new DisplayClock();
            view.Subcribe(clock);
            LogClockToFile log = new LogClockToFile();
            clock.Run();
        }
    }
}
