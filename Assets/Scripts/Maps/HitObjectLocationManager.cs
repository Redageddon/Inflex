using System;
using System.Collections.Generic;
using UnityEngine;

public class HitObjectLocationManager
{
    public readonly double Rotation;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;
    private readonly float _spawnTime;

    public HitObjectLocationManager(EnemyEvent self)
    {
        _rotationSpeed = self.RotationSpeed;
        Rotation = self.SpawnDegrees;
        _spawnTime = self.SpawnTime;
    }
    
    public Vector3 GetLocation(float audioSourceTime, float speed)
    {
        var distance = (float)(speed * (-audioSourceTime + _spawnTime) + 3.591 *SettingsHandler.LoadSettings().CenterSize);
        var radians = Rotation * Mathf.Deg2Rad;
        
        var x = (float) (distance * Math.Sin(radians));
        var y = (float) (distance * -Math.Cos(radians));
        
        return new Vector3(x, y, -1);
    }
}