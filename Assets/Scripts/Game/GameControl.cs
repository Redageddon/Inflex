using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static string MapName = Environment.ExpandEnvironmentVariables(@"%AppData%\CircleRhythm\Maps\DefaultMap");
    public static int CurrentKey;
    public static bool GamePaused;
    public static Map Map;
    public static float Speed;
    public int currentSpeed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject judgement;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Text key;
    [SerializeField] private Image img;
    [SerializeField] private Text lives;
    private int offset;

    private void Awake()
    {
        Map = JsonLoader.LoadMap(MapName);
        BackgroundChanger.SetBackground(img, Path.Combine(Map.Path, Map.Background));
    }

    private void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }
    
    private void Update()
    {
        UpdateSpeed();
        EnableEnemy();
        UpdatePause();
        UpdateUi();
        UpdateDeath();
    }

    private void UpdateSpeed()
    {
        print(Speed);
        if (Map.Speeds == null || Map.Speeds[0].SpawnTime > 0) Speed = 100;
        else
        {
            Speed = Map.Speeds[currentSpeed].Speed;
        }
        if (audioSource.time + AudioPlayer.Difference > Map.Speeds[currentSpeed].SpawnTime && currentSpeed > Map.Speeds.Count)
        {
            currentSpeed++;
        }
        
    }

    private void EnableEnemy()
    {
        for (var i = offset; i < Map.Enemies.Count; i++)
        {
            if (Speed * (-audioSource.time + Map.Enemies[i].SpawnTime) + 2.565 * GlobalSettings.Settings.CenterSize > 1100) return;
            CreateEnemy(i);
            offset += 1;
        }
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

    private void UpdateUi()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(GlobalSettings.Settings.Keys[i])) continue;
            key.text = GlobalSettings.Settings.Keys[i].ToString();
            CurrentKey = i;
        }
        
        lives.text = " Lives: " + Map.Lives;
    }

    private static void UpdateDeath()
    {
        if (Map.Lives <= 0)
        {
            SceneManager.LoadScene("MapSelection", LoadSceneMode.Single);
        }
    }

    private void CreateEnemy(int i)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.name = "Enemy" + i;
        enemyInstance.GetComponent<HitObject>().CurrentEnemy = i;
        enemyInstance.SetActive(true);
    }
    
    public void GradeAccuracy(double hitLocation)
    {
        var accuracy = Math.Truncate((hitLocation - 2.565) / (3.7 - 2.565) * 100);
        var newJudgement = Instantiate(judgement, judgement.transform.parent, false);
        if (accuracy < 15)
        {
            newJudgement.GetComponent<Text>().color = Color.red;
            newJudgement.GetComponent<Text>().text = "0";
        }
        else if (accuracy >= 15 && accuracy < 40)
        {
            newJudgement.GetComponent<Text>().color = Color.grey;
            newJudgement.GetComponent<Text>().text = "50";
        }
        else if (accuracy >= 40 && accuracy < 85)
        {
            newJudgement.GetComponent<Text>().color = Color.green;
            newJudgement.GetComponent<Text>().text = "150";
        }
        else if (accuracy >= 85 && accuracy < 95)
        {
            newJudgement.GetComponent<Text>().color = Color.blue;
            newJudgement.GetComponent<Text>().text = "300";
        }
        else if (accuracy >= 95 && accuracy < 99)
        {
            newJudgement.GetComponent<Text>().color = Color.magenta;
            newJudgement.GetComponent<Text>().text = "500";
        }
        else if (accuracy >= 99)
        {
            newJudgement.GetComponent<Text>().color = Color.yellow;
            newJudgement.GetComponent<Text>().text = "600";
        }
        newJudgement.SetActive(true);
        Destroy(newJudgement, 0.15f);
    }

    
}