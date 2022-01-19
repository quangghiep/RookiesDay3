using System;
using System.Threading;

namespace Day3.Events
{
    public class Clock
    {
        private int _hour;
        private int _minute;
        private int _second;

        public delegate void SecondChangeHandler(object clock, TimeInfoEventArgs args);
        public event SecondChangeHandler SecondChange;
        protected void OnSecondChange(object clock, TimeInfoEventArgs args)
        {
            if (SecondChange != null)
            {
                SecondChange(clock, args);
            }
        }
        public void Run()
        {
            for (; ; )
            {
                Thread.Sleep(1000);
                DateTime dateTimeNow = DateTime.Now;
                if (dateTimeNow.Second != _second)
                {
                    TimeInfoEventArgs timeInfoEventArgs = new TimeInfoEventArgs(dateTimeNow.Hour, dateTimeNow.Minute, dateTimeNow.Second);
                    OnSecondChange(this, timeInfoEventArgs);
                }
                this._hour = dateTimeNow.Hour;
                this._minute = dateTimeNow.Minute;
                this._second = dateTimeNow.Second;
            }
        }

        internal class clockTickHandler
        {
            private Action<object, TimeInfoEventArgs> writeToFile;

            public clockTickHandler(Action<object, TimeInfoEventArgs> writeToFile)
            {
                this.writeToFile = writeToFile;
            }
        }

        public static implicit operator ConsoleSpecialKey(Clock v)
        {
            throw new NotImplementedException();
        }
    }
}