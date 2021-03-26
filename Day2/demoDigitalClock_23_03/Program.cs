using System;

namespace DigitalClock
{
    class Program
    {
        static void Main(string[] args)
        {
            ClockPublisher clockPublisher = new ClockPublisher();
            ClockSubScriber clockSubscriber = new ClockSubScriber();
            clockSubscriber.Subscribe(clockPublisher);

            clockPublisher.Run();
        }
    }
}