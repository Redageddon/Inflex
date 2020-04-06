using System;
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

    public float Distance;
    public Vector3 GetLocation(float audioSourceTime, float speed)
    {
        Distance = (float)(speed * (-audioSourceTime + _spawnTime) + 5.6 * Assets.Instance.SavedSettings.ElementsSize);
        var radians = Rotation * Mathf.Deg2Rad;
        
        var x = (float) (Distance * Math.Sin(radians));
        var y = (float) (Distance * -Math.Cos(radians));
        
        return new Vector3(x, y, -1);
    }
}