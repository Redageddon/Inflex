using UnityEngine;
using UnityEngine.UI;

public class Lives : VisibleElement
{
    [SerializeField] private Text lives;

    private static int _health;

    public static int Health
    {
        get => _health;
        set
        {
            if (value <= 0) EndpointConditions.GameLose();
            _health = value;
        }
    }

    private void Awake()  => _health = Assets.Instance.Level.Lives;

    private void Update() => lives.text = $"Lives: {_health}";
}