using System;
using UnityEngine;

public class EnemyLocationManager
{
    private readonly double _rotation;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;
    private readonly float _spawnTime;

    public EnemyLocationManager(Enemy self)
    {
        _rotationSpeed = self.RotationSpeed;
        _rotation = self.SpawnDegrees;
        _spawnTime = self.SpawnTime;
    }

    public float Distance;
    public Vector3 GetLocation(float audioSourceTime, float speed)
    {
        //min speed 100, max 700
        Distance = (float)(speed * (-audioSourceTime + _spawnTime) + 2.565 * GlobalSettings.Settings.CenterSize);
        var radians = _rotation * Mathf.Deg2Rad;
        
        var x = (float) (Distance * Math.Sin(radians));
        var y = (float) (Distance * -Math.Cos(radians));

        return new Vector3(x, y, -1);
    }
}