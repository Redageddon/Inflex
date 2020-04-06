using UnityEngine;
using UnityEngine.UI;

public class Lives : VisibleElement
{
    [SerializeField] private Text lives;
    public static int Health;

    private void Awake()
    {
        Health = Assets.Instance.Level.Lives;
    }

    private void Update()
    {
        lives.text = " Lives: " + Health;
    }
}