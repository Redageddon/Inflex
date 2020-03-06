using UnityEngine;
using UnityEngine.UI;

public class HitObject : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private Sprite[] sprites;
    
    private EnemyLocationManager _locationManager;
    
    private void Awake()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        _locationManager = new EnemyLocationManager(self);
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[self.KillKey];
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
    }

    private void FixedUpdate()
    {
        if (audioSource.time > self.SpawnTime)
        {
            gameObject.SetActive(false);
            GameControl.Map.Lives -= 1;
        }
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
    }
}