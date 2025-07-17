using System;
using System.Collections.Generic;

public class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = new List<Word>();

        string[] parts = text.Split(' ');
        foreach (string part in parts)
        {
            Word word = new Word(part);
            _words.Add(word);
        }
    }

    public void Display()
    {
        Console.WriteLine(_reference.GetDisplayText());

        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }

        Console.WriteLine();
    }

    public void HideRandomWords(int numberToHide)
    {
        Random random = new Random();
        List<int> availableIndexes = new List<int>();

        // Gather indexes of words that are not hidden
        for (int i = 0; i < _words.Count; i++)
        {
            if (!_words[i].IsHidden())
            {
                availableIndexes.Add(i);
            }
        }

        // Hide a few of them
        for (int i = 0; i < numberToHide && availableIndexes.Count > 0; i++)
        {
            int randomIndex = random.Next(availableIndexes.Count);
            int wordIndex = availableIndexes[randomIndex];
            _words[wordIndex].Hide();
            availableIndexes.RemoveAt(randomIndex); // So we don't pick it again
        }
    }

    public bool AllWordsHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}
