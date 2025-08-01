using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : MindfulnessActivity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time you overcame a challenge.",
        "Recall a moment you felt truly at peace.",
        "Think of someone who made a difference in your life."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn from it?",
        "How did you grow as a result?",
        "How did this experience make you feel?"
    };

    public ReflectionActivity()
        : base("Reflection Activity", "This activity helps you reflect on meaningful moments in your life.")
    {
    }

    protected override void PerformActivity()
    {
        string prompt = _prompts[new Random().Next(_prompts.Count)];
        Console.WriteLine($"--- {prompt} ---");
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        foreach (var question in _questions)
        {
            if (DateTime.Now >= endTime) break;

            Console.WriteLine($"> {question}");
            ShowSpinner(5);
        }
    }
}
