using UnityEngine;

public class HitObject : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public float Speed { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private GameObject judgement;

    public EnemyLocationManager locationManager;

    private void Awake()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        locationManager = new EnemyLocationManager(self);
        gameObject.GetComponent<Transform>().localScale = new Vector3(SettingsHandler.LoadSettings().CenterSize, SettingsHandler.LoadSettings().CenterSize);
        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[self.KillKey];
        print(Speed);
        transform.localPosition = locationManager.GetLocation(audioSource.time + AudioPlayer.Difference, Speed);
    }

    public void Hit()
    {
        JudgementCreator.Create(locationManager.Rotation, judgement);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        var currentTime = audioSource.time + AudioPlayer.Difference;
        transform.localPosition = locationManager.GetLocation(currentTime, Speed);
    }
}