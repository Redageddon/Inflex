using System;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private Sprite[] sprites;

    public EnemyLocationManager locationManager;

    private void Awake()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        locationManager = new EnemyLocationManager(self);
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[self.KillKey];
        transform.localPosition = locationManager.GetLocation(audioSource.time + AudioPlayer.Difference, GameControl.Speed);
    }

    public void Hit()
    {
        var hitLocation = Math.Round(locationManager.Distance / GlobalSettings.Settings.CenterSize * 100) / 100;
        transform.parent.GetComponent<GameControl>().GradeAccuracy(hitLocation);
    }

    private void Update()
    {
        if (audioSource.time + AudioPlayer.Difference >= self.SpawnTime)
        {
            Hit();
            gameObject.SetActive(false);
            GameControl.Map.Lives -= 1;
        }

        transform.localPosition = locationManager.GetLocation(audioSource.time + AudioPlayer.Difference, GameControl.Speed);
    }
}