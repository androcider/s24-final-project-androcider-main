using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a history tracker instance
        HistoryTracker history = new HistoryTracker();

        // Add songs to the history
        history.AddSong("Song 1");
        history.AddSong("Song 2");
        history.AddSong("Song 3");

        // View the last song played
        Console.WriteLine("Last song played: " + history.ViewLastSong());

        // Count number of songs in the history
        Console.WriteLine("Number of songs in history: " + history.Count());

        // Remove the last song played
        Console.WriteLine("Removing last song played: " + history.RemoveSong());
        Console.WriteLine("Last song played: " + history.ViewLastSong());

        // Clear the history
        history.Clear();
        Console.WriteLine("Number of songs after clearing: " + history.Count());
    }
}

public class HistoryTracker
{
    private Stack<string> history;

    public HistoryTracker()
    {
        history = new Stack<string>();
    }

    // Add song to the history
    public void AddSong(string song)
    {
        history.Push(song);
        Console.WriteLine($"Added to history: {song}");
    }

    // Remove and return the last song played
    public string RemoveSong()
    {
        if (history.Count > 0)
        {
            return history.Pop();
        }
        else
        {
            return "No songs in the history.";
        }
    }

    // View the last song played without removing it
    public string ViewLastSong()
    {
        if (history.Count > 0)
        {
            return history.Peek();
        }
        else
        {
            return "No songs in the history.";
        }
    }

    // Count the number of songs in the history
    public int Count()
    {
        return history.Count;
    }

    // Clear the history
    public void Clear()
    {
        history.Clear();
        Console.WriteLine("History cleared.");
    }
}
