using UnityEngine;

public class HitObject : VisibleElement
{
    private float _speed;
    private HitObjectLocationManager locationManager;
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Sprite[] sprites;

    public void SetVariables(EnemyEvent enemyEvent, float speed)
    {
        locationManager = new HitObjectLocationManager(enemyEvent);
        gameObject.name = enemyEvent.KillKey.ToString();
        image.sprite = sprites[enemyEvent.KillKey];
        
        circleCollider2D.radius = AssetLoader.Instance.SavedSettings.ElementsSize;
        rectTransform.sizeDelta = new Vector2(AssetLoader.Instance.SavedSettings.ElementsSize * 2, AssetLoader.Instance.SavedSettings.ElementsSize * 2);

        _speed = speed;
        gameObject.transform.localPosition = locationManager.GetLocation(AudioPlayer.Instance.GetTrueAudioTime(), _speed);
        gameObject.SetActive(true);
    }

    public void Hit()
    {
        JudgementCreator.Create(locationManager.Rotation);
        gameObject.SetActive(false);
    }

    private void UpdateLocation()
    {
        

        if (locationManager.Distance <= 2.71 * AssetLoader.Instance.SavedSettings.ElementsSize)
        {
            Health.Lives -= 1;
            Hit();
        }

        gameObject.transform.localPosition = locationManager.GetLocation(AudioPlayer.Instance.GetTrueAudioTime(), _speed);
    }

    public void Update()
    {
        UpdateLocation();
    }
}