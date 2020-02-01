using System;
using UnityEngine;
using UnityEngine.UI;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    private Enemy self;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Text text;
    private double _distance, _rotation;
    private double _handler;
    private float _movementOverTime, _timeAtStart, _rotationOverTime;
    private float _currentX, _currentY;
    private float _x, _y;
    private float _speed, _rotationSpeed;
    private float _lifetime;

    private void Start()
    {
        self = MapButton.Map.Enemies[CurrentEnemy];
        
        _rotationSpeed = self.Rotation;
        _speed = self.Speed;
        text.text = self.KillKey;
        _x = self.XLocation;
        _y = self.YLocation;

        transform.localPosition = new Vector2(_x, _y);

        _timeAtStart = audioSource.time;

        _rotation = 180d / Math.PI * Math.Atan2(_y, _x) + 90d;
        _distance = Math.Sqrt(_x * _x + _y * _y);
        InvokeRepeating(nameof(FastestUpdate), 0, 0.00002f);
    }

    private void FastestUpdate()
    {
        if(GameControl.GamePaused) audioSource.Pause();
        else audioSource.UnPause();

        _lifetime = audioSource.time - _timeAtStart;
        _movementOverTime = _lifetime * _speed;
        _rotationOverTime = _lifetime * _rotationSpeed;

        _handler = Math.PI * (-1 * ((_rotation + _rotationOverTime) / 180d) - 1);
        _currentX = (float) ((_distance - _movementOverTime) * Math.Sin(_handler));
        _currentY = (float) ((_distance - _movementOverTime) * Math.Cos(_handler));

        transform.localPosition = new Vector2(_currentX, _currentY);
    }
}