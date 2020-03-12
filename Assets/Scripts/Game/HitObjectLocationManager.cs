using System;
using UnityEngine;

public class EnemyLocationManager
{
    public readonly double Rotation;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;
    private readonly float _spawnTime;

    public EnemyLocationManager(Enemy self)
    {
        _rotationSpeed = self.RotationSpeed;
        Rotation = self.SpawnDegrees;
        _spawnTime = self.SpawnTime;
    }

    
    public Vector3 GetLocation(float audioSourceTime, float speed)
    {
        //min speed 100, max 300?
        var distance = (float)(speed * (-audioSourceTime + _spawnTime) + 3.66667 * GlobalSettings.Settings.CenterSize);
        var radians = Rotation * Mathf.Deg2Rad;
        
        var x = (float) (distance * Math.Sin(radians));
        var y = (float) (distance * -Math.Cos(radians));
        
        return new Vector3(x, y, -1);
    }
}