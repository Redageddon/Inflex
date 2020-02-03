using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    public static bool GamePaused;

    private void Start()
    {
        for (var i = 0; i < MapButton.Map.Enemies.Count; i++)
        {
            var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
            enemyInstance.SetActive(true);
            enemyInstance.name = "Enemy" + i;
            enemyInstance.GetComponent<ComplexEnemy>().CurrentEnemy = i;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
            pauseScreen.SetActive(GamePaused);
        }
        if (!GamePaused)
        {
            audioSource.UnPause();
        }
        else
        {
            audioSource.Pause();
        }
    }
}