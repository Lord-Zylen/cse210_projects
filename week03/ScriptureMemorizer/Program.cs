using System;
using System.IO;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Load scripture from file
        List<Scripture> scriptures = LoadScripturesFromFile("scriptures.txt");

        if (scriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found.");
            return;
        }

        // Pick a random scripture
        Random rand = new Random();
        Scripture scripture = scriptures[rand.Next(scriptures.Count)];

        // Start the memorization loop
        while (true)
        {
            Console.Clear();
            scripture.Display();

            if (scripture.AllWordsHidden())
            {
                Console.WriteLine("\nAll words are hidden. Good job!");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to end:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);
        }
    }

    // Load and parse scriptures from file
    static List<Scripture> LoadScripturesFromFile(string filePath)
    {
        List<Scripture> scriptures = new List<Scripture>();

        try
        {
            string[] lines = File.ReadAllLines(filePath);

            foreach (string line in lines)
            {
                if (line.Trim().Length == 0) continue;

                string[] parts = line.Split('|');
                if (parts.Length != 2) continue;

                string referencePart = parts[0].Trim();
                string text = parts[1].Trim();

                // Example: "Proverbs 3:5-6"
                string[] refParts = referencePart.Split(' ');
                string book = refParts[0];
                string chapterAndVerse = refParts[1];

                string[] verseParts = chapterAndVerse.Split(':');
                int chapter = int.Parse(verseParts[0]);
                string verseRange = verseParts[1];

                Reference reference;

                if (verseRange.Contains("-"))
                {
                    string[] range = verseRange.Split('-');
                    int startVerse = int.Parse(range[0]);
                    int endVerse = int.Parse(range[1]);
                    reference = new Reference(book, startVerse, endVerse);
                }
                else
                {
                    int startVerse = int.Parse(verseRange);
                    reference = new Reference(book, startVerse);
                }

                Scripture scripture = new Scripture(reference, text);
                scriptures.Add(scripture);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading file: " + ex.Message);
        }

        return scriptures;
    }
}
