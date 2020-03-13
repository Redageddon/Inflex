using UnityEngine;

public class HitObject : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public float Speed { private get; set; }
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
        transform.localPosition = locationManager.GetLocation(audioSource.time + AudioPlayer.Difference, Speed);
    }

    public void Hit()
    {
        transform.parent.GetComponent<GameControl>().GradeAccuracy(locationManager.Rotation);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        var currentTime = audioSource.time + AudioPlayer.Difference;
        transform.localPosition = locationManager.GetLocation(currentTime, Speed);
    }
}