using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    private static List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void AddEntry()
    {
        Random rand = new Random();
        string prompt = _prompts[rand.Next(_prompts.Count)];

        Console.WriteLine($"\nPrompt: {prompt}");
        Console.Write("Your response: ");
        string response = Console.ReadLine();

        Entry newEntry = new Entry(prompt, response);
        _entries.Add(newEntry);
        Console.WriteLine("Entry added successfully!\n");
    }

    public void DisplayEntries()
    {
        Console.WriteLine("\n--- Journal Entries ---\n");
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                writer.WriteLine(entry.ToFileFormat());
            }
        }
        Console.WriteLine("Journal saved successfully!\n");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();

        var lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            _entries.Add(Entry.FromFileFormat(line));
        }

        Console.WriteLine("Journal loaded successfully!\n");
    }
}
