using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _distance;
    private readonly double _rotation;
    private readonly float _speed;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;

    public EnemyLocationManager(Enemy self, Rect bounds)
    {
        _rotationSpeed = self.RotationSpeed;
        _speed = self.Speed;
        _rotation = self.SpawnDegrees;
        _distance = (float) CalculateDistance(_rotation, bounds);
        _deathTime = (float) (self.SpawnTime - (_distance - GlobalSettings.Settings.CenterSize * 1.71) / _speed);
    }

    public bool TimeToSpawn(float audioSourceTime)
    {
        return audioSourceTime > _deathTime;
    }

    private double CalculateDistance(double rotation, Rect bounds)
    {
        double shortenAmount = 0;
        
        var h = bounds.height / 2;
        var w = bounds.width / 2;
        
        var z = Math.Sqrt(w * w + h * h);
        var x = Math.Sin(Math.PI / 180 * rotation) * z;
        var y = -Math.Cos(Math.PI / 180 * rotation) * z;
        
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

        return Math.Sqrt(x * x + y * y);
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