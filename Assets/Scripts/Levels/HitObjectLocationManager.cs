using System;
using UnityEngine;
 
public class HitObjectLocationManager
{
    public readonly double Rotation;
    private readonly float _rotationSpeed;
    private readonly float _deathTime;

    public HitObjectLocationManager(EnemyEvent self)
    {
        _rotationSpeed = self.RotationSpeed;
        Rotation = self.SpawnDegrees;
        _deathTime = self.SpawnTime;
    }

    public double Distance;
    public Vector3 GetLocation(float audioSourceTime, float speed)
    {
        Distance = speed * (-audioSourceTime + _deathTime) + 5.6 * Assets.Instance.Settings.ElementsSize;
        double radians = Rotation * Mathf.Deg2Rad;
        
        float x = (float) (Distance * Math.Sin(radians));
        float y = (float) (Distance * -Math.Cos(radians));
        
        return new Vector3(x, y, -1);
    }
}