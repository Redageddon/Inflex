using System;
using UnityEngine;

public class HitObject : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private Sprite[] sprites;
    
    public EnemyLocationManager _locationManager;
    
    private void Awake()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        _locationManager = new EnemyLocationManager(self);
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[self.KillKey];
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
    }


    
    private void Update()
    {
        if (audioSource.time >= self.SpawnTime)
        {
            //2.565 is miss 3.7 is max
            var asd = Math.Round(_locationManager.Distance / GlobalSettings.Settings.CenterSize * 100) / 100 - 2.565;
            print(asd / 3.7);
            gameObject.SetActive(false);
            GameControl.Map.Lives -= 1;
        }
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
    }
}