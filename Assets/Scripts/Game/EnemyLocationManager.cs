using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _distance;
    private readonly double _rotation;
    private readonly float _speed;
    private readonly float _rotationSpeed;
    private readonly float _spawnTime;
    private readonly float _deathTime;
    public float HitTime = float.PositiveInfinity;

    public EnemyLocationManager(Enemy self)
    {
        _rotationSpeed = self.RotationSpeed;
        _speed = self.Speed;
        _rotation = self.SpawnDegrees;
        _distance = self.Distance;
        
        CalculateDistance(_rotation);
        
        _spawnTime = self.SpawnTime;
        _deathTime = (float) (_spawnTime - (_distance - GlobalSettings.Settings.CenterSize * 2.565) / _speed);
    }

    public bool DespawnOutOfBounds(float audioSourceTime)
    {
        return audioSourceTime > _deathTime && audioSourceTime < HitTime;
    }

    private void CalculateDistance(double rotation)
    {
        float shortenAmount = 0;
        
        var h = Screen.height / 2;
        var w = Screen.width / 2;
        
        var z = (float)Math.Sqrt(w * w + h * h);
        
        var x = (float)Math.Sin(rotation) * z;
        var y = (float)-Math.Cos(rotation) * z;
        
        if (x > w)
        {
            shortenAmount = w / x;
        }
        else if (x < -w)
        {
            shortenAmount = -w / x;
        }
        else if (y > h)
        {
            shortenAmount = h / y;
        }
        else if (y < -h)
        {
            shortenAmount = -h / y;
        }
        
        x *= shortenAmount;
        y *= shortenAmount;
        x += w;
        y += h;

        Debug.Log($"{x}::{y}");
    }

    public Vector3 GetLocation(float audioSourceTime)
    {
        var lifetime = audioSourceTime - _deathTime;
        var movementOverTime = lifetime * _speed;
        var rotationOverTime = lifetime * _rotationSpeed;

        var handler = Math.PI * (-1 * ((_rotation + rotationOverTime) / 180d) - 1);

        var x = (float) ((_distance - movementOverTime) * Math.Sin(handler));
        var y = (float) ((_distance - movementOverTime) * Math.Cos(handler));
        
        return new Vector3(x, y, -1);
    }
}