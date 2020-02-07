using System;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class EnemyRotationManager
{
    private double _distance { get; set; }
    private double _rotation { get; set; }
    private float  _speed { get; set; }
    private float  _rotationSpeed { get; set; }
    // TODO: rename to meaningful name.
    private float _audioSourceTime { get; set; }
    private float _spawnTime { get; set; }

    public EnemyRotationManager(Enemy enemy, float audioSourceTime)
    {
        _audioSourceTime = audioSourceTime;

        _rotationSpeed = self.Rotation;
        _speed = self.Speed;
        _spawnTime = self.SpawnTim;

        var x = self.XLocation;
        var y = self.YLocation;
        _rotation = 180d / Math.PI * Math.Atan2(y, x) + 90d;
        _distance = Math.Sqrt(x * x + y * y);
    }

    // ToDo: give a meaningful name, I don't understand the logic
    public bool IsSomething()
    {
        return Distance - (AudioSourceTime - SpawnTime) * Speed > 0 && AudioSourceTime > SpawnTime;
    }

    public Vector2 AdjustRotation()
    {
        // Audio influences rotation time- sounds really odd. I would try not to couple the two.
        // It makes sense that rotation time happens to be like audioSource.Time, but don't couple the two.
        var lifetime = _audioSourceTime - _spawnTime;
        var movementOverTime = lifetime * _speed;
        var rotationOverTime = lifetime * _rotationSpeed;

        _rotation = Math.PI * (-1 * ((_rotation + _rotationOverTime) / 180d) - 1);
        var x = (float)((_distance - movementOverTime) * Math.Sin(_rotation));
        var y = (float)((_distance - movementOverTime) * Math.Cos(_rotation));

        return new Vector2(x, y);
    }
}

public class ComplexEnemy : MonoBehaviour
{
    public int CurrentEnemy { private get; set; }
    public Enemy self;
    [SerializeField] public AudioSource AudioSource { get; set; }
    [SerializeField] public Text text;
    private EnemyRotationManager _rotationManager;
    
    private void Start()
    {
        self = MapButton.Map.Enemies[CurrentEnemy];
        _rotationManager = new EnemyRotationManager(self, audioSource.time);

        // TODO: Refactor to be used almost like a dictionary:
        // GlobalSettings.Instance[self.KillKey] // returns setting.
        text.text = GameControl.GlobalSettings.Keys[self.KillKey].ToString();
        transform.localPosition = new Vector2(self.XLocation, self.YLocation);
        gameObject.SetActive(false);
    }

    private void Update()
    {
        var isSomething = _rotationManager.IsSomething();
        gameObject.SetActive(isSomething);
        transform.localPosition = _rotationManager.AdjustRotation();
    }
}