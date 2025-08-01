using System;
using System.Collections.Generic;
using System.Threading;

public class GratitudeActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "What people in your life are you thankful for?",
        "Name things around you right now that bring comfort.",
        "What small things made you smile recently?"
    };

    public GratitudeActivity()
        : base("Gratitude Activity", "This activity helps you focus on the things you're thankful for.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"Prompt:\n-- {prompt} --\n");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"\nYou listed {count} things you're grateful for.");
    }
}
