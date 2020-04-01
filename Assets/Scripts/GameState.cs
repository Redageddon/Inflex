using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioSource audioSource;
    public static bool GamePaused;
    public static float Speed;
    private int currentSpeed;

    private void Awake()
    {
        UpdateSpeed();
    }

    public void OnGUI()
    {
        UpdatePause();
    }

    private void Update()
    {
        UpdatePause();
        UpdateSpeed();
    }

    private void UpdatePause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
            pauseScreen.SetActive(GamePaused);
        }
        if (!GamePaused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
    }
    
    private void UpdateSpeed()
    {
        if (MapHandler.Map.Speeds == null) Speed = 100;
        else
        {
            Speed = MapHandler.Map.Speeds[currentSpeed].Speed;
        }
        while (audioSource.time + AudioPlayer.Difference > MapHandler.Map.Speeds[currentSpeed].SpawnTime)
        {
            if(currentSpeed + 1 >= MapHandler.Map.Speeds.Count) return;
            currentSpeed++;
        }
    }
}