using System;
using System.Threading;

public class BreathingActivity : MindfulnessActivity
{
    public BreathingActivity()
        : base("Breathing Activity", "This activity helps you relax by guiding you through deep breaths.")
    {
    }

    protected override void PerformActivity()
    {
        for (int i = 0; i < _duration / 10; i++)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(4);
            Console.WriteLine();

            Console.Write("Hold... ");
            ShowCountdown(2);
            Console.WriteLine();

            Console.Write("Breathe out... ");
            ShowCountdown(4);
            Console.WriteLine("\n");
        }
    }
}
