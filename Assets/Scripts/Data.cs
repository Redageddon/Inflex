[System.Serializable]
public class Data
{
    public Data(string title, string path, string icon, float difficulty, string songFile)
    {
        Title = title;
        Path = path;
        Icon = icon;
        Difficulty = difficulty;
        SongFile = songFile;
    }

    public string Title { get; }
    public string Path { get; }
    public string Icon { get; }
    public float Difficulty { get; }
    public string SongFile { get; }
}
