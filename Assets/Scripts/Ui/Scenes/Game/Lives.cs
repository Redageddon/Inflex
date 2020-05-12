using UnityEngine;
using UnityEngine.UI;

public class Lives : VisibleElement
{
    private static int health;
    [SerializeField] private Text lives;

    public static int Health
    {
        get => health;
        set
        {
            if (value <= 0)
            {
                EndpointConditions.GameLose();
            }

            health = value;
        }
    }

    private void Awake() => health = Assets.Instance.Level.Lives;

    private void Update() => this.lives.text = $"Lives: {health}";
}