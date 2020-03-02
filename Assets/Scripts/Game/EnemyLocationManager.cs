using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _distance;
    private readonly double _rotation;
    private readonly float _speed;
    private readonly float _rotationSpeed;
    private readonly float _spawnTime;
    public float HitTime = float.PositiveInfinity;

    public EnemyLocationManager(Enemy self)
    {
        _rotationSpeed = self.RotationSpeed;
        _speed = self.Speed;
        _rotation = self.SpawnDegrees;
        _distance = self.Distance;
        _spawnTime = Time.deltaTime + (float) (self.SpawnTime - (_distance - GlobalSettings.Settings.CenterSize * 2.565) / _speed);
        //Debug.Log(_spawnTime - self.SpawnTime);
    }

    public bool DespawnOutOfBounds(float audioSourceTime)
    {
        return _distance - (audioSourceTime - _spawnTime) * _speed > 0 && audioSourceTime > _spawnTime && audioSourceTime < HitTime;
    }
    
    public Vector3 GetLocation(float audioSourceTime)
    {
        var lifetime = audioSourceTime - _spawnTime;
        var movementOverTime = lifetime * _speed;
        var rotationOverTime = lifetime * _rotationSpeed;

        var handler = Math.PI * (-1 * ((_rotation + rotationOverTime) / 180d) - 1);

        var x = (float) ((_distance - movementOverTime) * Math.Sin(handler));
        var y = (float) ((_distance - movementOverTime) * Math.Cos(handler));
        
        return new Vector3(x, y, -1);
    }
}