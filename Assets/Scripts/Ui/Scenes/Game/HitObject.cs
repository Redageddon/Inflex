using UnityEngine;

public class HitObject : VisibleElement
{
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private Sprite[] sprites;
    private HitObjectLocationManager _locationManager;
    private float _speed;
    public int killKey;

    public void SetVariables(EnemyEvent enemyEvent, float speed)
    {
        image.texture = Assets.Instance.Skin.HitObjects[enemyEvent.KillKey] is null ? sprites[enemyEvent.KillKey].texture : Assets.Instance.Skin.HitObjects[enemyEvent.KillKey];
        _speed = speed;
        
        _locationManager = new HitObjectLocationManager(enemyEvent);
        killKey = enemyEvent.KillKey;
        circleCollider2D.radius = Assets.Instance.Settings.ElementsSize;
        rectTransform.sizeDelta = new Vector2(Assets.Instance.Settings.ElementsSize * 2, Assets.Instance.Settings.ElementsSize * 2);
        
        gameObject.transform.localPosition = _locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, _speed);
        gameObject.SetActive(true);
    }

    public void Hit()
    {
        JudgementCreator.Create(_locationManager.Rotation);
        gameObject.SetActive(false);
    }

    private void UpdateLocation()
    {
        if (_locationManager.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
        {
            Lives.Health -= 1;
            Hit();
        }

        gameObject.transform.localPosition = _locationManager.GetLocation(AudioPlayer.Instance.TrueAudioTime, _speed);
    }

    public void Update() => UpdateLocation();
}