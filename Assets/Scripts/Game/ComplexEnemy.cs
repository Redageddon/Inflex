using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public Text text;
    private EnemyLocationManager _rotationManager;

    private void Start()
    {
        self = MapButton.Map.Enemies[CurrentEnemy];
        _rotationManager = new EnemyLocationManager(self);

        text.text = GlobalSettings.Settings.Keys[self.KillKey].ToString();
        transform.localPosition = new Vector2(self.XLocation, self.YLocation);
        gameObject.SetActive(false);
    }
    
    private void Update()
    {
        IsInBounds();
        transform.localPosition = _rotationManager.GetLocation(audioSource.time);
    }
    
    public void IsInBounds()
    {
        gameObject.SetActive(_rotationManager.DespawnOutOfBounds(audioSource.time));
    }
}