using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "What are things you're grateful for today?",
        "List people who have helped you recently.",
        "List moments when you felt happy this week."
    };

    public ListingActivity()
        : base("Listing Activity", "This activity helps you reflect by listing responses to a prompt.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine("Prompt:");
        Console.WriteLine($"-- {prompt} --");
        Console.WriteLine("Start listing...");

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        int count = 0;

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items!");
    }
}
