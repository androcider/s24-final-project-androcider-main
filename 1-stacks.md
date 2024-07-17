# Stacks

## Introduction
 A stack is a collection of objects that follows the Last-In-First-Out (LIFO) principle. This means that the last element added to the stack will be the first one to be removed. The Stack<T> class in C# provides various methods and properties to work with stack data structures.

## Purpose

Stacks in C# are used to solve a variety of programming problems that require a specific order of operations. The Last-In-First-Out (LIFO) principle makes stacks particularly useful for certain scenarios. Here are some common purposes and use cases for stacks in C#:

1. #### Function Call Management (Recursion)
Stacks are used to manage function calls, particularly in recursive algorithms. Each time a function calls another function, the current function's state (local variables, return address) is pushed onto the stack. When the called function completes, its state is popped from the stack, and the execution resumes from where it left off.

2. #### Expression Evaluation
Stacks are used in parsing and evaluating expressions, particularly in converting infix expressions (e.g., A + B * C) to postfix expressions (e.g., A B C * +) and then evaluating them.

3. #### Backtracking Algorithms
In algorithms that require exploring multiple possibilities (such as maze solving, depth-first search in graphs), stacks are used to keep track of the current state and backtrack when needed.

4. #### Undo Mechanism in Applications
Stacks are used to implement the undo functionality in applications. Each action performed by the user is pushed onto a stack. To undo an action, the application pops the top action from the stack and reverses it.

5. #### Language Parsing and Syntax Checking
Compilers and interpreters use stacks to parse and check the syntax of programming languages. For example, matching parentheses and braces in code can be efficiently checked using a stack.

6.#### Navigating Browser History
Stacks are used to manage browser history. Each visited page is pushed onto a stack. The back button pops the current page from the stack and navigates to the previous page.

7. #### Reversing Data
Stacks can be used to reverse data. For example, reversing a string can be done by pushing each character onto a stack and then popping them in reverse order.
## Methods

### Creating a Stack
You can create a stack using the Stack<T> class, where T is the type of elements stored in the stack.

```csharp

Stack<int> stack = new Stack<int>();
```
### Adding Elements to a Stack
To add elements to a stack, you use the Push method.

```csharp

stack.Push(1);
stack.Push(2);
stack.Push(3);
```
### Removing Elements from a Stack
To remove and return the top element from the stack, you use the Pop method.

```csharp

int topElement = stack.Pop(); // topElement will be 3
```
### Peeking at the Top Element
If you want to look at the top element without removing it, you use the Peek method.

```csharp

int topElement = stack.Peek(); // topElement will be 2, and it's not removed
```
### Checking the Count of Elements
You can check how many elements are in the stack using the Count property.

```csharp

int count = stack.Count; // count will be 2
```
### Checking if the Stack is Empty
You can check if the stack is empty using the Count property or the Any method from LINQ.

```csharp

bool isEmpty = stack.Count == 0;
```
### Clearing the Stack
To remove all elements from the stack, use the Clear method.

```csharp

stack.Clear();
```
## EEfficiency of common operations

|Operation|	Time Complexity|
|:--------|----------------:|
|Push|	O(1)|
|Pop|	O(1)|
|Peek|	O(1)|
|Count|	O(1)|
|Contains|	O(n)|
|Clear|	O(n)|

## Example

In the example below, we will create a playlist that will play the last song added.

Playlist requirements:
* Add song
* Remove song
* View next song
* Count number of songs in playlist
* Clear the playlist

```csharp
using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Create a playlist manager instance
        PlaylistManager playlist = new PlaylistManager();

        // Add songs to the playlist
        playlist.AddSong("Song 1");
        playlist.AddSong("Song 2");
        playlist.AddSong("Song 3");

        // View the next song
        Console.WriteLine("Next song: " + playlist.ViewNextSong());

        // Count number of songs in the playlist
        Console.WriteLine("Number of songs: " + playlist.Count());

        // Play and remove the next song
        Console.WriteLine("Playing and removing: " + playlist.RemoveSong());
        Console.WriteLine("Next song: " + playlist.ViewNextSong());

        // Clear the playlist
        playlist.Clear();
        Console.WriteLine("Number of songs after clearing: " + playlist.Count());
    }
}

public class PlaylistManager
{
    private Stack<string> playlist;

    public PlaylistManager()
    {
        playlist = new Stack<string>();
    }

    // Add song to the playlist
    public void AddSong(string song)
    {
        playlist.Push(song);
        Console.WriteLine($"Added: {song}");
    }

    // Remove and return the next song from the playlist
    public string RemoveSong()
    {
        if (playlist.Count > 0)
        {
            return playlist.Pop();
        }
        else
        {
            return "No songs in the playlist.";
        }
    }

    // View the next song without removing it
    public string ViewNextSong()
    {
        if (playlist.Count > 0)
        {
            return playlist.Peek();
        }
        else
        {
            return "No songs in the playlist.";
        }
    }

    // Count the number of songs in the playlist
    public int Count()
    {
        return playlist.Count;
    }

    // Clear the playlist
    public void Clear()
    {
        playlist.Clear();
        Console.WriteLine("Playlist cleared.");
    }
}
```

## Problem to Solve

Write a program that will keep track of the viewing history of the user.
Add to the program the abilities to see the last song listened to, add to the list, clear the list, and removed the last song added.

After you have completed the program, compare it against the solution here:

[Solution](1-stacks-solution.cs)

