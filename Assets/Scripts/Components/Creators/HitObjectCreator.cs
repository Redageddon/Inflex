using UnityEngine;

public class HitObjectCreator : MonoBehaviour
{
    [SerializeField] private GameObject enemy;
    [SerializeField] private AudioPlayer audioPlayer;
    private int _offset;
    
    private void Update() 
    {
        WaitToSpawnEnemy();
    }
    
    private void WaitToSpawnEnemy()
    {
        for (var i = _offset; i < Assets.Instance.Level.Enemies.Count; i++)
        {
            if (GameState.GetSpeed(_offset) * (-audioPlayer.TrueAudioTime + Assets.Instance.Level.Enemies[i].SpawnTime) + 5.6 * Assets.Instance.SavedSettings.ElementsSize > 1100) return;
            CreateEnemy(Assets.Instance.Level.Enemies[i], GameState.GetSpeed(_offset));
            _offset ++;
        }
    }

    private void CreateEnemy(EnemyEvent self, float speed)
    {
        var enemyInstance = Instantiate(enemy, enemy.transform.parent, false);
        enemyInstance.GetComponent<HitObject>().SetVariables(self, speed);
    }
}