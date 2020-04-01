using UnityEngine;

public class HitObject : MonoBehaviour
{
    public EnemyEvent self;
    private float speed;
    private AudioSource song;
    private HitObjectLocationManager locationManager;

    public void SetVariables(EnemyEvent enemyEvent, AudioSource audioSource, float speedInput, Sprite sprite)
    {
        self = enemyEvent;
        locationManager = new HitObjectLocationManager(enemyEvent);
        speed = speedInput;
        song = audioSource;
        
        gameObject.GetComponent<Transform>().localScale = new Vector3(SettingsHandler.LoadSettings().CenterSize, SettingsHandler.LoadSettings().CenterSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprite;
        gameObject.transform.localPosition = locationManager.GetLocation(audioSource.time + AudioPlayer.Difference, this.speed);
        gameObject.SetActive(true);
    }

    public void Hit()
    {
        JudgementCreator.Create(locationManager.Rotation);
        gameObject.SetActive(false);
    }

    public void Update()
    {
        gameObject.transform.localPosition = locationManager.GetLocation(song.time + AudioPlayer.Difference, speed);
    }
}