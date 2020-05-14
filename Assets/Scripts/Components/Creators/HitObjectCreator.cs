using BeatMaps.Events;
using Components.Audio;
using Ui.Scenes.Game;
using UnityEngine;

namespace Components.Creators
{
    public class HitObjectCreator : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        private int offset;

        private void Update() => this.WaitToSpawnEnemy();

        private void WaitToSpawnEnemy()
        {
            for (int i = this.offset; i < Assets.Instance.BeatMap.Enemies.Count; i++)
            {
                if (GameState.GetSpeed(this.offset) * (-AudioPlayer.Instance.TrueAudioTime + Assets.Instance.BeatMap.Enemies[i].SpawnTime) +
                    5.6 * Assets.Instance.Settings.ElementsSize > 1100)
                {
                    return;
                }

                this.CreateEnemy(Assets.Instance.BeatMap.Enemies[i], GameState.GetSpeed(this.offset));
                this.offset++;
            }
        }

        private void CreateEnemy(EnemyEvent self, float speed)
        {
            GameObject enemyInstance = Instantiate(this.enemy, this.enemy.transform.parent, false);
            enemyInstance.GetComponent<HitObject>().SetVariables(self, speed);
        }
    }
}