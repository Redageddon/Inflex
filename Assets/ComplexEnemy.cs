using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public Text text;
    private SavedSettings _settings;
    private double _distance, _rotation;
    private double _rotation;
    private float _movementOverTime, _rotationOverTime;
    private float _speed, _rotationSpeed;
    private float _lifetime;

    private void Start()
    {
        _settings = GameControl.GlobalSettings;
        self = MapButton.Map.Enemies[CurrentEnemy];

        _rotationSpeed = self.Rotation;
        _speed = self.Speed;
        
        // this is what determines what will the center text be...V
        text.text = _settings.Keys[self.KillKey].ToString();
        // this is what determines what will the center text be...^
        
        var startX = self.XLocation;
        var startY = self.YLocation;

        transform.localPosition = new Vector2(_x, _y);

        _rotation = 180d / Math.PI * Math.Atan2(_y, _x) + 90d;
        _distance = Math.Sqrt(_x * _x + _y * _y);
        gameObject.SetActive(false);
    }
    
    public void Contain()
    {
        gameObject.SetActive(_distance - (audioSource.time - self.SpawnTime) * _speed > 0 && audioSource.time > self.SpawnTime);
    }

    private void Update()
    {
        Contain();
        _lifetime = audioSource.time - self.SpawnTime;
        _movementOverTime = _lifetime * _speed;
        _rotationOverTime = _lifetime * _rotationSpeed;

        _rotation = Math.PI * (-1 * ((_rotation + _rotationOverTime) / 180d) - 1);
        var currentX = (float) ((_distance - _movementOverTime) * Math.Sin(_rotation));
        var currentY = (float) ((_distance - _movementOverTime) * Math.Cos(_rotation));

        transform.localPosition = new Vector2(currentX, currentY);
    }
}