using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Text text;
    
    private EnemyLocationManager _locationManager;
    
    private void Awake()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        _locationManager = new EnemyLocationManager(self);
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
        text.text = GlobalSettings.Settings.Keys[self.KillKey].ToString();
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