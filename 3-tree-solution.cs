using System;

// Song Class
public class Song
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Album { get; set; }

    public Song(string title, string artist, string album)
    {
        Title = title;
        Artist = artist;
        Album = album;
    }
}

// Node Class
public class Node<T>
{
    public T Data { get; set; }
    public Node<T> Left { get; set; }
    public Node<T> Right { get; set; }

    public Node(T data)
    {
        Data = data;
        Left = null;
        Right = null;
    }
}

// SongBinarySearchTree Class
public class SongBinarySearchTree
{
    private Node<Song> root;

    public SongBinarySearchTree()
    {
        root = null;
    }

    public void Insert(Song song)
    {
        root = InsertRec(root, song);
    }

    private Node<Song> InsertRec(Node<Song> root, Song song)
    {
        if (root == null)
        {
            root = new Node<Song>(song);
            return root;
        }

        if (string.Compare(song.Artist, root.Data.Artist, StringComparison.OrdinalIgnoreCase) < 0)
        {
            root.Left = InsertRec(root.Left, song);
        }
        else if (string.Compare(song.Artist, root.Data.Artist, StringComparison.OrdinalIgnoreCase) > 0)
        {
            root.Right = InsertRec(root.Right, song);
        }

        return root;
    }

    public Song Search(string artist)
    {
        return SearchRec(root, artist)?.Data;
    }

    private Node<Song> SearchRec(Node<Song> root, string artist)
    {
        if (root == null || root.Data.Artist.Equals(artist, StringComparison.OrdinalIgnoreCase))
        {
            return root;
        }

        if (string.Compare(artist, root.Data.Artist, StringComparison.OrdinalIgnoreCase) < 0)
        {
            return SearchRec(root.Left, artist);
        }
        else
        {
            return SearchRec(root.Right, artist);
        }
    }

    public void InOrderTraversal(Node<Song> node)
    {
        if (node != null)
        {
            InOrderTraversal(node.Left);
            Console.WriteLine($"{node.Data.Artist} - {node.Data.Title}");
            InOrderTraversal(node.Right);
        }
    }

    public void Display()
    {
        InOrderTraversal(root);
    }
}

// Program Class
class Program
{
    static void Main()
    {
        var songTree = new SongBinarySearchTree();

        // Insert songs into the tree
        songTree.Insert(new Song("Shape of You", "Ed Sheeran", "Divide"));
        songTree.Insert(new Song("Blinding Lights", "The Weeknd", "After Hours"));
        songTree.Insert(new Song("Someone Like You", "Adele", "21"));
        songTree.Insert(new Song("Rolling in the Deep", "Adele", "21"));

        // Display all songs
        Console.WriteLine("All songs in the tree:");
        songTree.Display();

        // Search for songs by artist
        string searchArtist = "Adele";
        var foundSong = songTree.Search(searchArtist);
        Console.WriteLine(foundSong != null
            ? $"Found song by {searchArtist}: {foundSong.Title} from the album {foundSong.Album}"
            : $"Artist {searchArtist} not found");
    }
}
