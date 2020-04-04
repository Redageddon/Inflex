[System.Serializable]
public class LevelData
{
    public LevelData(string title, string path, string icon, float difficulty)
    {
        Title = title;
        Path = path;
        Icon = icon;
        Difficulty = difficulty;
    }

    public string Title { get; }
    public string Path { get; }
    public string Icon { get; }
    public float Difficulty { get; }
}
