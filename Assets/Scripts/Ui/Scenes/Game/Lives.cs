using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (value <= 0) SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
            _health = value;
        }
    }

    private void Awake()
    {
        _health = Assets.Instance.Level.Lives;
    }

    private void Update()
    {
        lives.text = " Lives: " + _health;
    }
}