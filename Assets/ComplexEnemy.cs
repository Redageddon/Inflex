using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    [SerializeField] private AudioSource audioSource;
    private double _distance, _rotation;
    private double _handler;
    private float _movementOverTime, _timeAtStart, _rotationOverTime;
    private float _currentX, _currentY;
    private float _x, _y;
    private float _speed, _rotationSpeed; 
    private float _lifetime;

    private void Start()
    {
        _rotationSpeed = MapButton.Map.Enemies[CurrentEnemy].Rotation;
        _speed = MapButton.Map.Enemies[CurrentEnemy].Speed;
        
        _x = transform.localPosition.x;
        _y = transform.localPosition.y;
        _timeAtStart = audioSource.time;
        
        _rotation = 180d / Math.PI * Math.Atan2(_y, _x) + 90d;
        _distance = Math.Sqrt(_x * _x + _y * _y);
    }

    
    private void Update()
    {
        _lifetime = audioSource.time - _timeAtStart;
        _movementOverTime = _lifetime * _speed;
        _rotationOverTime = _lifetime * _rotationSpeed;
        
        _handler = Math.PI * (-1 * ((_rotation + _rotationOverTime) / 180d) - 1);
        _currentX = (float) ((_distance - _movementOverTime) * Math.Sin(_handler));
        _currentY = (float) ((_distance - _movementOverTime) * Math.Cos(_handler));
        
        transform.localPosition = new Vector2(_currentX, _currentY);
    }
}