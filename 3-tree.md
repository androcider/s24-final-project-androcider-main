# Tree

## Introduction
Trees are a fundamental data structure in computer science that simulate a hierarchical tree structure with a root value and subtrees of children, represented as a set of linked nodes. Trees are used to represent hierarchical relationships, such as file systems, organization structures, and more.
## Purpose
1. ### Hierarchical Data Representation
Trees naturally represent hierarchical data, such as organizational structures, file systems, and more. Each node can have multiple children, making it ideal for representing parent-child relationships.

        Example:

        File System: Directories contain files and subdirectories.
        Organization Chart: Employees have subordinates and supervisors.

2. ### Efficient Search and Sorting
Trees can be used to implement efficient search and sorting algorithms. Binary Search Trees (BST), for example, allow for quick search, insertion, and deletion operations.

        Example:

        Binary Search Tree (BST): Provides O(log n) average-case time complexity for search, insertion, and deletion operations.
        AVL Tree: A self-balancing BST that maintains O(log n) time complexity even in the worst case.
3. ### Priority Queues and Heaps
Trees can implement priority queues, where each element has a priority, and the element with the highest priority is served first. Heaps are a type of binary tree used to implement priority queues.

        Example:

        Heap: Supports efficient extraction of the minimum or maximum element.
4. ### Expression Parsing and Evaluation
Trees are used to parse and evaluate mathematical expressions. Expression trees represent expressions where each internal node is an operator, and each leaf node is an operand.

        Example:

        Expression Tree: Used in compilers and interpreters for parsing and evaluating expressions.
5. ### Routing and Navigation
Trees are used in networking and graph algorithms for routing and navigation. They help find the shortest path and manage connections between nodes.

        Example:

        Shortest Path Tree: Used in algorithms like Dijkstra's for finding the shortest path in a graph.
        Spanning Tree: Used in networking to prevent loops in Ethernet networks.
6. ### Indexing in Databases
Trees, particularly B-trees and their variants, are used in databases for indexing to provide efficient data retrieval.

        Example:

        B-tree: Used in database systems for indexing and ensuring balanced data retrieval times.
        B+ tree: A variant of B-tree used for storing data and indexing in databases.
7. ### Autocompletion and Spell Checking
Trees can be used to implement autocompletion and spell-checking features. Trie is a type of tree used for this purpose.

        Example:

        Trie (Prefix Tree): Used in autocomplete and spell-checking applications to efficiently store and search for strings.
8. ### Game Development
Trees are used for various purposes, including managing game scenes, AI decision-making, and collision detection.

        Example:

        Scene Graph: Represents the hierarchical structure of a game scene.
        Behavior Tree: Used for AI decision-making in games.

## Methods
1. ### Insert(T data)
Purpose: Adds a new node with the specified data to the tree.
Description: This method places the new node in the appropriate position according to the tree's ordering rules (e.g., left child for smaller values in a BST).
Example:

```csharp

public void Insert(T data)
{
    if (Root == null)
    {
        Root = new Node<T>(data);
    }
    else
    {
        InsertRec(Root, new Node<T>(data));
    }
}

private void InsertRec(Node<T> root, Node<T> newNode)
{
    if (newNode.Data.CompareTo(root.Data) < 0)
    {
        if (root.Left == null)
        {
            root.Left = newNode;
        }
        else
        {
            InsertRec(root.Left, newNode);
        }
    }
    else
    {
        if (root.Right == null)
        {
            root.Right = newNode;
        }
        else
        {
            InsertRec(root.Right, newNode);
        }
    }
}
```
2. ### Delete(T data)
Purpose: Removes the node with the specified data from the tree.
Description: This method finds and removes the node, then rearranges the tree to maintain its properties.
Example:

```csharp

public void Delete(T data)
{
    Root = DeleteRec(Root, data);
}

private Node<T> DeleteRec(Node<T> root, T data)
{
    if (root == null) return root;

    if (data.CompareTo(root.Data) < 0)
    {
        root.Left = DeleteRec(root.Left, data);
    }
    else if (data.CompareTo(root.Data) > 0)
    {
        root.Right = DeleteRec(root.Right, data);
    }
    else
    {
        // Node with only one child or no child
        if (root.Left == null) return root.Right;
        if (root.Right == null) return root.Left;

        // Node with two children: Get the inorder successor (smallest in the right subtree)
        root.Data = MinValue(root.Right);

        // Delete the inorder successor
        root.Right = DeleteRec(root.Right, root.Data);
    }

    return root;
}

private T MinValue(Node<T> node)
{
    T minv = node.Data;
    while (node.Left != null)
    {
        minv = node.Left.Data;
        node = node.Left;
    }
    return minv;
}
```
3. ### Search(T data)
Purpose: Searches for a node with the specified data in the tree.
Description: This method traverses the tree to find the node containing the specified data.
Example:

```csharp

public Node<T> Search(T data)
{
    return SearchRec(Root, data);
}

private Node<T> SearchRec(Node<T> root, T data)
{
    if (root == null || root.Data.Equals(data))
    {
        return root;
    }

    if (data.CompareTo(root.Data) < 0)
    {
        return SearchRec(root.Left, data);
    }
    else
    {
        return SearchRec(root.Right, data);
    }
}
```
4. ### InOrderTraversal(Node<T> node)
Purpose: Traverses the tree in in-order (left, root, right).
Description: This method prints or processes each node's data in in-order.
Example:

```csharp

public void InOrderTraversal(Node<T> node)
{
    if (node != null)
    {
        InOrderTraversal(node.Left);
        Console.Write(node.Data + " ");
        InOrderTraversal(node.Right);
    }
}
```
5. ### PreOrderTraversal(Node<T> node)
Purpose: Traverses the tree in pre-order (root, left, right).
Description: This method prints or processes each node's data in pre-order.
Example:

```csharp

public void PreOrderTraversal(Node<T> node)
{
    if (node != null)
    {
        Console.Write(node.Data + " ");
        PreOrderTraversal(node.Left);
        PreOrderTraversal(node.Right);
    }
}
```
6. ### PostOrderTraversal(Node<T> node)
Purpose: Traverses the tree in post-order (left, right, root).
Description: This method prints or processes each node's data in post-order.
Example:

```csharp

public void PostOrderTraversal(Node<T> node)
{
    if (node != null)
    {
        PostOrderTraversal(node.Left);
        PostOrderTraversal(node.Right);
        Console.Write(node.Data + " ");
    }
}
```
7. ### FindMin()
Purpose: Finds the node with the minimum value in the tree.
Description: This method traverses the leftmost path of the tree to find the minimum value.
Example:

```csharp

public T FindMin()
{
    return FindMinRec(Root);
}

private T FindMinRec(Node<T> root)
{
    T minv = root.Data;
    while (root.Left != null)
    {
        minv = root.Left.Data;
        root = root.Left;
    }
    return minv;
}
```
8. ### FindMax()
Purpose: Finds the node with the maximum value in the tree.
Description: This method traverses the rightmost path of the tree to find the maximum value.
Example:

```csharp

public T FindMax()
{
    return FindMaxRec(Root);
}

private T FindMaxRec(Node<T> root)
{
    T maxv = root.Data;
    while (root.Right != null)
    {
        maxv = root.Right.Data;
        root = root.Right;
    }
    return maxv;
}
```
## Efficiency of common operations
|Method	|Best Case Time Complexity	|Worst Case Time Complexity|
|:------|------------:|-------------:|
|Insert(T data)	|O(log n) |O(n)|
|Delete(T data)	|O(log n)	|O(n)|
|Search(T data)	|O(log n)|	O(n)|
|InOrderTraversal()	|O(n)	|O(n)|
|PreOrderTraversal()|	O(n)|	O(n)|
|PostOrderTraversal()|	O(n)|	O(n)|
|FindMin()|	O(log n)|	O(n)|
|FindMax()|	O(log n)|	O(n)|
## Example Problem

## Problem to Solve




[Return to home page](0-welcome.md)