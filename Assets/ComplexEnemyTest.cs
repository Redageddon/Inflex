using System;
using UnityEngine;

public class ComplexEnemyTest : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RectTransform viewport;
    private double _topLeft;
    private float _movementOverTime;
    private float _currentX, _currentY;
    private float _timeAtStart;
    private float _lifetime;
    private float _x, _y;
    float a = 0;
    private const int Speed = 100;
    private int _sign;

    private void Start()
    {
        _x = transform.localPosition.x;
        _y = transform.localPosition.y;
        _timeAtStart = audioSource.time;
        _topLeft = 180 / Math.PI * Math.Atan2(_y, _x) + 90;
    }

    private void Update()
    {
        // handling location
        _lifetime = audioSource.time - _timeAtStart;
        _sign = _topLeft > 45 && _topLeft < 225 ? -1 : 1;
        _movementOverTime = _sign * _lifetime * Speed;

        if (Math.Abs(_x) > Math.Abs(_y))
        {
            _currentX = _x + _movementOverTime;
            _currentY = _y + _movementOverTime * _y / _x;
        }
        else
        {
            _currentX = _x + _movementOverTime * _x / _y;
            _currentY = _y + _movementOverTime;
        }
        
        // handling rotation
        
        _currentX += (float)(Math.Abs(_currentX) * Math.Sin(a));
        _currentY += (float)(Math.Abs(_currentY) * Math.Cos(a));
        
        a += 0.1f;
        
        
        print(_currentX);
        // updating position
        transform.localPosition = new Vector2(_currentX, _currentY);
    }
}