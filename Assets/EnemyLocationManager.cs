using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _distance;
    private readonly double _rotation;
    private readonly float _speed;
    private readonly float _rotationSpeed;
    private readonly float _spawnTime;

    public EnemyLocationManager(Enemy self)
    {
        _rotationSpeed = self.Rotation;
        _speed = self.Speed;
        _spawnTime = self.SpawnTime;

        var x = self.XLocation;
        var y = self.YLocation;
        _rotation = 180d / Math.PI * Math.Atan2(y, x) + 90d;
        _distance = Math.Sqrt(x * x + y * y);
    }
    
    public bool DespawnOutOfBounds(float audioSourceTime)
    {
        return _distance - (audioSourceTime - _spawnTime) * _speed > 0 && audioSourceTime > _spawnTime;
    }

    public Vector2 GetLocation(float audioSourceTime)
    {
        var lifetime = audioSourceTime - _spawnTime;
        var movementOverTime = lifetime * _speed;
        var rotationOverTime = lifetime * _rotationSpeed;

        var handler = Math.PI * (-1 * ((_rotation + rotationOverTime) / 180d) - 1);
        var x = (float)((_distance - movementOverTime) * Math.Sin(handler));
        var y = (float)((_distance - movementOverTime) * Math.Cos(handler));

        return new Vector2(x, y);
    }
}