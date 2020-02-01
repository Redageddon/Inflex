using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private float time;
    public static bool GamePaused = false;
    private Rect _viewportSize;
    private int _currentEnemy;
    private Map _map;

    private void Start()
    {
        _map = MapButton.Map;
        _viewportSize = GetComponent<RectTransform>().rect;
        InvokeRepeating(nameof(FastUpdate), 0, 0.00002f);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePaused = !GamePaused;
            pauseScreen.SetActive(GamePaused);
        }
        
    }

    private void FastUpdate()
    {
        if(GamePaused) return;
        if (_map.Enemies.Count == _currentEnemy || !(audioSource.time > _map.Enemies[_currentEnemy].SpawnTime)) return;
        
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.SetActive(true);
        enemyInstance.GetComponent<ComplexEnemy>().CurrentEnemy = _currentEnemy;
        
        _currentEnemy++;
    }
}