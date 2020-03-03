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
        _spawnTime = self.SpawnTime;
        _deathTime = (float) (_spawnTime - (_distance - GlobalSettings.Settings.CenterSize * 2.565) / _speed);
    }

    public bool DespawnOutOfBounds(float audioSourceTime)
    {
        return audioSourceTime > _deathTime && audioSourceTime < HitTime;
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