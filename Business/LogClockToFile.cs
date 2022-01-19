using Day3.Events;
using System.IO;

namespace Day3.Business
{
    public class LogClockToFile
    {
        public void Subcribe(Clock clock)
        {
            clock.SecondChange += new Clock.SecondChangeHandler(WriteToFile);
        }
        public void WriteToFile(object clock, TimeInfoEventArgs timeInfo)
        {
            string outputString = "Time: " + timeInfo.hour + ":" + timeInfo.minute + ":" + timeInfo.second;
            using (FileStream stream = File.Open("F://Log1.txt", FileMode.Append))
            {
                byte[] bytes = new System.Text.UTF8Encoding(true).GetBytes(outputString);

                stream.Write(bytes, 0, bytes.Length);
                // StringWriter writer
            }
            using (StreamWriter writer = new StreamWriter("F://Log2.txt", true))
            {
                writer.WriteLine(outputString);
            }
        }
    }
}