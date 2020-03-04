using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Text text;
    
    private EnemyLocationManager _locationManager;
    
    private void Start()
    {
        self = GameControl.Map.Enemies[CurrentEnemy];
        _locationManager = new EnemyLocationManager(self, gameObject.GetComponent<RectTransform>().parent.GetComponent<RectTransform>().rect);
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
        text.text = GlobalSettings.Settings.Keys[self.KillKey].ToString();
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        transform.localPosition = _locationManager.GetLocation(audioSource.time);
    }

    public void IsInBounds()
    {
        if (GameControl.Map.Enemies.Count <= CurrentEnemy + 1) return;
        if (_locationManager.TimeToSpawn(audioSource.time))
        {
            GameControl.EnemyToBeUpdated = CurrentEnemy + 1;
            gameObject.SetActive(true);
        }
    }
}