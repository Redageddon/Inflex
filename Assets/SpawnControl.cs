using UnityEngine;

public class SpawnControl : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioSource audioSource;
    private Rect _viewportSize;
    private int _currentEnemy;
    private Map _map;

    private void Start()
    {
        _map = MapButton.Map;
        _viewportSize = GetComponent<RectTransform>().rect;
    }

    private void Update()
    {
        if (_map.Enemies.Count != _currentEnemy && audioSource.time > _map.Enemies[_currentEnemy].SpawnTime)
        {
            GameObject enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
            var spawnPoint = new Vector2(_map.Enemies[_currentEnemy].XLocation, _map.Enemies[_currentEnemy].YLocation);
            
            if (Mathf.Abs(spawnPoint.x) < _viewportSize.width / 2 || Mathf.Abs(spawnPoint.y) < _viewportSize.height / 2)
            {
                if (spawnPoint.x / _viewportSize.width < spawnPoint.y / _viewportSize.height)
                {
                    if (spawnPoint.x < 0) 
                        spawnPoint.x = -1 * _viewportSize.width / 2;
                    else 
                        spawnPoint.x = _viewportSize.width / 2;
                }
                else
                {
                    if (spawnPoint.y < 0) 
                        spawnPoint.y = -1 * _viewportSize.height / 2;
                    else 
                        spawnPoint.y = _viewportSize.height / 2;
                }
            }

            enemyInstance.transform.localPosition = spawnPoint;
            enemyInstance.SetActive(true);
            enemyInstance.GetComponent<EnemyControl>().CurrentEnemy = _currentEnemy;
            _currentEnemy++;
        }
    }
}