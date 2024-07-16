public class Playlist
{
    private LinkedList<string> songs = new LinkedList<string>();

    public void AddSong(string song)
    {
        songs.Add(song);
    }

    public void Shuffle()
    {
        var random = new Random();
        var songList = new List<string>();
        Node<string> current = songs.Find(songs.ViewFirst());
        while (current != null)
        {
            songList.Add(current.Data);
            current = current.Next;
        }
        for (int i = songList.Count - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            var temp = songList[i];
            songList[i] = songList[j];
            songList[j] = temp;
        }
        songs.Clear();
        foreach (var song in songList)
        {
            songs.Add(song);
        }
    }

    public void DisplayPlaylist()
    {
        songs.Display();
    }
}

// Usage
var playlist = new Playlist();
playlist.AddSong("Song 1");
playlist.AddSong("Song 2");
playlist.AddSong("Song 3");
playlist.DisplayPlaylist();  // Output: Song 1 -> Song 2 -> Song 3 -> null
playlist.Shuffle();
playlist.DisplayPlaylist();  // Output: (Songs in random order)
