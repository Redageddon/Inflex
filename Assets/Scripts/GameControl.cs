using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static string MapName;
    public static int CurrentKey;
    public static bool GamePaused;
    public static Map Map;
    public int currentSpeed;
    private float _speed;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject judgement;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Text key;
    [SerializeField] private Image img;
    [SerializeField] private Text lives;
    private int _offset;

    private void Awake()
    {
        Map = MapHandler.LoadMap(MapName);
        BackgroundChanger.SetBackground(img, Path.Combine(Map.Path, Map.Background));
    }

    private void Update()
    {
        UpdateSpeed();
        WaitToSpawnEnemy();
        UpdatePause();
        UpdateUi();
        UpdateDeath();
    }

    private void UpdateSpeed()
    {
        if (Map.Speeds == null) _speed = 100;
        else
        {
            _speed = Map.Speeds[currentSpeed].Speed;
        }
        while (audioSource.time + AudioPlayer.Difference > Map.Speeds[currentSpeed].SpawnTime)
        {
            if(currentSpeed + 1 >= Map.Speeds.Count) return;
            currentSpeed++;
        }
    }

    private void WaitToSpawnEnemy()
    {
        for (var i = _offset; i < Map.Enemies.Count; i++)
        {
            if (_speed * (-audioSource.time + Map.Enemies[i].SpawnTime) + 2.565 * SettingsHandler.LoadSettings().CenterSize > 1100) return;
            CreateEnemy(i);
            _offset += 1;
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
        for (var i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(SettingsHandler.LoadSettings().Keys[i])) continue;
            key.text = SettingsHandler.LoadSettings().Keys[i].ToString();
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
        enemyInstance.GetComponent<HitObject>().Speed = _speed;
        enemyInstance.SetActive(true);
    }
    
    public void GradeAccuracy(double hitObjectRotation)
    {
        var accuracy = 0d;
        const int grader = 15;
        
        var pointerRotation = Pointer.GetZRotation();
        if (pointerRotation - hitObjectRotation > 100)
        {
            pointerRotation -= 360;
        }
        
        if (Math.Abs(pointerRotation - hitObjectRotation) < grader)
        {
            accuracy = Math.Round(100 * (Math.Abs(pointerRotation - hitObjectRotation) - grader) / -grader);
        }

        var newJudgement = Instantiate(judgement, judgement.transform.parent, false);
        newJudgement.GetComponent<Text>().color = Color.HSVToRGB((float)accuracy/100,1,1, true);
        newJudgement.GetComponent<Text>().text = accuracy.ToString();
        newJudgement.SetActive(true);
        Destroy(newJudgement, 0.15f);
    }

    
}