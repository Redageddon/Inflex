using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _rotation;
    private readonly float _speed;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;
    private readonly float _spawnTime;

    public EnemyLocationManager(Enemy self)
    {
        
        _rotationSpeed = self.RotationSpeed;
        _speed = self.Speed;
        _rotation = self.SpawnDegrees;
        _spawnTime = self.SpawnTime;
        _deathTime = (float) (self.SpawnTime - (1100 - GlobalSettings.Settings.CenterSize * 1.71) / _speed);
    }

    public bool TimeToSpawn(float audioSourceTime)
    {
        return audioSourceTime > _deathTime;
    }

    private double CalculateDistance(double rotation, Rect bounds)
    {
        // https://www.desmos.com/calculator/ctqpudpztm -- this is a visual representation
        var distance = 0d;
        var h = bounds.height / 2;
        var w = bounds.width / 2;
        var z = Math.Sqrt(h * h + w * w);

        if (rotation > 180)
        {
            rotation -= 180;
        }

        if (0 <= rotation && rotation <= 45)
        {
            distance = (z - h) * rotation / 45 + h;
        }
        else if (45 <= rotation && rotation <= 90)
        {
            distance = (w - z) * (rotation - 45) / 45 + z;
        }
        else if (90 <= rotation && rotation <= 135)
        {
            distance = (z - w) * (rotation - 90) / 45 + w;
        }
        else if (135 <= rotation && rotation <= 180)
        {
            distance = (h - z) * (rotation - 135) / 45 + z;
        }

        return distance;
    }

    public Vector3 GetLocation(float audioSourceTime)
    {
        /*var lifetime = audioSourceTime - _deathTime;
        var rotationOverTime = lifetime * _rotationSpeed;
        var handler = Math.PI + (_rotation + rotationOverTime) * -Math.PI / 180;*/
        var movementOverTime = _speed * (-audioSourceTime + _spawnTime) + 1.71 * GlobalSettings.Settings.CenterSize;
        var radians = _rotation * Mathf.Deg2Rad;
        
        var x = (float) (movementOverTime * Math.Sin(radians));
        var y = (float) (movementOverTime * -Math.Cos(radians));

        return new Vector3(x, y, -1);
    }
}