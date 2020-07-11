using Audio;
using Beatmaps.Events;
using Logic;
using UnityEngine;

namespace Ui.Game.HitObject
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
                if (Assets.Instance.Settings.IncomingSpeed * (-AudioPlayer.Instance.TrueAudioTime + Assets.Instance.BeatMap.Enemies[i].SpawnTime) +
                    5.6 * Assets.Instance.Settings.ElementsSize > 1100)
                {
                    return;
                }

                this.CreateEnemy(Assets.Instance.BeatMap.Enemies[i]);
                this.offset++;
            }
        }

        private void CreateEnemy(EnemyEvent self)
        {
            GameObject enemyInstance = Instantiate(this.enemy, this.transform, false);
            enemyInstance.GetComponent<HitObject>().Construct(self, Assets.Instance.Settings.IncomingSpeed);
        }
    }
}