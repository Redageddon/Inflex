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
        if (GameControl.Map.Speeds == null) Speed = 100;
        else
        {
            Speed = GameControl.Map.Speeds[currentSpeed].Speed;
        }
        while (audioSource.time + AudioPlayer.Difference > GameControl.Map.Speeds[currentSpeed].SpawnTime)
        {
            if(currentSpeed + 1 >= GameControl.Map.Speeds.Count) return;
            currentSpeed++;
        }
    }
}