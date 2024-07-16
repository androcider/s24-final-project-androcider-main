# Linked Lists

## Introduction
 Linked lists are a fundamental data structure that provide a way to store and manage a collection of elements. Unlike arrays, linked lists do not store elements in contiguous memory locations. Instead, each element, called a node, contains a reference (or link) to the next element in the sequence.
## Purpose
Linked lists are a fundamental data structure that provide a flexible way to store and manage a collection of elements. Here are some of the primary purposes and benefits of using linked lists:

1. Dynamic Size
Flexibility: Unlike arrays, which have a fixed size, linked lists can grow and shrink dynamically. This makes them ideal for situations where the number of elements is not known in advance or may change frequently.
2. Efficient Insertions and Deletions
Fast Modifications: Linked lists are efficient for scenarios where elements are frequently added or removed from the middle of the list.
3. Memory Utilization
Non-contiguous Storage: Linked lists use non-contiguous memory allocation, which means they can utilize scattered memory blocks. This can be advantageous when memory is fragmented.
Efficient Use: Nodes are created as needed, which can lead to more efficient use of memory in certain situations.
4. Implementation of Other Data Structures
Foundational Structure: Linked lists serve as the foundation for many other data structures, such as stacks, queues, and more complex structures like graphs and hash tables.
5. Simpler Memory Management
No Need for Resizing: Since linked lists do not require resizing (as arrays do when they grow), they avoid the overhead associated with copying elements to a new array.
6. Use Cases
Real-World Applications: Linked lists are used in a variety of real-world applications. For example, they can be used in implementing adjacency lists for graph representations, in the chaining technique for handling hash collisions, and in managing free lists in dynamic memory allocation (e.g., garbage collectors).
## Methods
### Add(T data)
Purpose: Adds a new node with the specified data at the end of the list.

Functionality: This method creates a new node and appends it to the end of the linked list. If the list is empty, the new node becomes the head.

```csharp

LinkedList<int> list = new LinkedList<int>();
list.Add(1); // Adds 1 to the list
list.Add(2); // Adds 2 to the list
list.Display(); // Output: 1 -> 2 -> null
```
### Remove(T data)
Purpose: Removes the first node that matches the specified data.

Functionality: This method traverses the list to find the first node with the specified data and removes it from the list. If the node is the head, it updates the head to the next node.

```csharp

list.Remove(1); // Removes the first occurrence of 1 from the list
list.Display(); // Output: 2 -> null
```
### ViewFirst()
Purpose: Returns the data of the first node in the list.

Functionality: This method returns the data stored in the head node. If the list is empty, it throws an exception.


```csharp

int firstElement = list.ViewFirst(); // Returns 2
Console.WriteLine(firstElement); // Output: 2
```
### Count()
Purpose: Returns the number of nodes in the list.

Functionality: This method traverses the list and counts the number of nodes, returning the total count.

```csharp
Copy code
int count = list.Count(); // Returns the number of nodes in the list
Console.WriteLine(count); // Output: 1\
```
### Clear()
Purpose: Clears the list, removing all nodes.

Functionality: This method sets the head to null, effectively removing all nodes from the list.

```csharp

list.Clear(); // Clears the list
list.Display(); // Output: null
Console.WriteLine(list.Count()); // Output: 0
```
### Display()
Purpose: Displays the data of each node in the list.

Functionality: This method traverses the list and prints the data of each node to the console, ending with "null".

```csharp

list.Add(3);
list.Add(4);
list.Display(); // Output: 3 -> 4 -> null
```
### Find(T data)
Purpose: Finds and returns the first node that contains the specified data.

Functionality: This method traverses the list to find the first node with the specified data and returns that node. If no such node is found, it returns null.


```csharp

Node<int> node = list.Find(3); // Finds the node with data 3
Console.WriteLine(node != null ? node.Data.ToString() : "Node not found"); // Output: 3
```
### InsertAfter(Node<T> previousNode, T data)
Purpose: Inserts a new node with the specified data after the given node.

Functionality: This method creates a new node and inserts it immediately after the specified node in the list.

```csharp

Node<int> nodeToInsertAfter = list.Find(3);
if (nodeToInsertAfter != null)
{
    list.InsertAfter(nodeToInsertAfter, 5);
}
list.Display(); // Output: 3 -> 5 -> 4 -> null
```
## Efficiency of common operations

|Method| Time Complexity|
|:-----|-----:|
|Add(T data)|	O(n)|
|Remove(T data)|	O(n)|
|ViewFirst()|	O(1)|
|Count()|	O(n)|
|Clear()|	O(1)|
|Display()|	O(n)|
|Find(T data)|	O(n)|
|InsertAfter(Node<T> previousNode, T data)|	O(1)|
## Example Problem
In the example below we will create a linked list that will keep track of and display recently added songs. 

```csharp
public class RecentlyAdded
{
    private LinkedList<string> recentSongs = new LinkedList<string>();
    private int capacity;

    public RecentlyAdded(int capacity)
    {
        this.capacity = capacity;
    }

    public void AddSong(string song)
    {
        if (recentSongs.Count() >= capacity)
        {
            Node<string> current = recentSongs.Find(recentSongs.ViewFirst());
            while (current.Next != null && current.Next.Next != null)
            {
                current = current.Next;
            }
            current.Next = null;
        }
        recentSongs.Add(song);
    }

    public void DisplayRecentlyAdded()
    {
        recentSongs.Display();
    }
}

// Usage
var recentlyAdded = new RecentlyAdded(2);
recentlyAdded.AddSong("New Song 1");
recentlyAdded.AddSong("New Song 2");
recentlyAdded.DisplayRecentlyAdded();  // Output: New Song 1 -> New Song 2 -> null
recentlyAdded.AddSong("New Song 3");
recentlyAdded.DisplayRecentlyAdded();  // Output: New Song 2 -> New Song 3 -> null
```
## Problem to Solve

Write a program that will be able to shuffle a playlist as a linked list.

After you have completed the program, compare it against the solution here:

[Solution](2-linkedLists-solution.cs)