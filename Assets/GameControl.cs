using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private Text key;
    public static SavedSettings GlobalSettings = JsonLoader.LoadSettings();
    public static readonly List<Action> ContainmentList = new List<Action>();

    public static bool GamePaused;
    [SerializeField] private Text lives;

    private void Start()
    {
        CreateEnemies();
        lives.text = "Lives: " + MapButton.Map.Lives;
    }

    private void Update()
    {
        UpdatePause();
        UpdateEnemy();
        UpdateKey();
    }

    private void UpdateKey()
    {
        foreach (var keyCode in GlobalSettings.Keys.Where(Input.GetKeyDown))
        {
            key.text = keyCode.ToString();
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
    
    private void CreateEnemies()
    {
        for (var i = 0; i < MapButton.Map.Enemies.Count; i++)
        {
            var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
            enemyInstance.SetActive(true);
            enemyInstance.name = "Enemy" + i;
            enemyInstance.GetComponent<ComplexEnemy>().CurrentEnemy = i;

            ContainmentList.Add(enemyInstance.GetComponent<ComplexEnemy>().IsInBounds);
            //ContainmentList.Add(enemyInstance.GetComponent<ComplexEnemy>().DespawnOutOfBounds);
        }
    }

    private void UpdateEnemy()
    {
        for (int i = 0; i < ContainmentList.Count; i++)
        {
            if (audioSource.time - MapButton.Map.Enemies[i].SpawnTime > -1 || audioSource.time - MapButton.Map.Enemies[i].SpawnTime < 1)
            {
                ContainmentList[i].Invoke();
            }
        }
    }
}