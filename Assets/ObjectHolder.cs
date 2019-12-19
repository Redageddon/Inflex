public class LivesO
{
    private string Name { get; set; }
    private int Lives { get; set; }

    public LivesO(string name, int lives)
    {
        Name = name;
        Lives = lives;
    }
}

public class SongO
{
    private string Name { get; set; }
    private string Song { get; set; }

    public SongO(string name, string song)
    {
        Name = name;
        Song = song;
    }
}

public class EnemyO
{
    private string Name { get; set; }
    private string KillKey { get; set; }
    private double Xloc { get; set; }
    private double YLoc { get; set; }
    private double IRot { get; set; }
    private double SpawnTime { get; set; }

    public EnemyO(string name, string killKey, double xloc, double yLoc, double iRot, double spawnTime)
    {
        Name = name;
        KillKey = killKey;
        Xloc = xloc;
        YLoc = yLoc;
        IRot = iRot;
        SpawnTime = spawnTime;
    }
}

public class ScreenO
{
    private string Name { get; set; }
    private int RSpeed { get; set; }
    private int Zoom { get; set; }
    private double SpawnTime { get; set; }

    public ScreenO(string name, int rSpeed, int zoom, double spawnTime)
    {
        Name = name;
        RSpeed = rSpeed;
        Zoom = zoom;
        SpawnTime = spawnTime;
    }
}

public class BackgroundO
{
    private string Name { get; set; }
    private string Image { get; set; }
    private double SpawnTime { get; set; }

    public BackgroundO(string name, string image, double spawnTime)
    {
        Name = name;
        Image = image;
        SpawnTime = spawnTime;
    }
}

public class EndO
{
    private string Name { get; set; }
    private double SpawnTime { get; set; }

    public EndO(string name, double spawnTime)
    {
        Name = name;
        SpawnTime = spawnTime;
    }
}