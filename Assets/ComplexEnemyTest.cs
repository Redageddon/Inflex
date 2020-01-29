using System;
using UnityEngine;

public class ComplexEnemyTest : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private RectTransform viewport;
    private float _timeAtStart;
    private const int Speed = 100;
    private float _x, _y;

    private void Start()
    {
        _x = transform.localPosition.x;
        _y = transform.localPosition.y;
        _timeAtStart = audioSource.time;
    }

    private void Update()
    {
        float currentX, currentY;
        float lifetime = audioSource.time - _timeAtStart;
        if (180 / Math.PI * Math.Atan2(_y, _x) + 90 > 45 && 180 / Math.PI * Math.Atan2(_y, _x) + 90 < 225)
        {
            if (Math.Abs(_x) > Math.Abs(_y))
            {
                currentX = _x - lifetime * Speed;
                currentY = _y - lifetime * (Speed * (_y / _x));
            }
            else
            {
                currentX = _x - lifetime * (Speed * _x / _y);
                currentY = _y - lifetime * Speed;
            }
        }
        else
        {
            if (Math.Abs(_x) > Math.Abs(_y))
            {
                currentX = _x + lifetime * Speed;
                currentY = _y + lifetime * (Speed * (_y / _x));
            }
            else
            {
                currentX = _x + lifetime * (Speed * _x / _y);
                currentY = _y + lifetime * Speed;
            }
        }
        
        print(currentX);
        transform.localPosition = new Vector2(currentX, currentY);
    }
}