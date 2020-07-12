using Audio;
using Beatmaps.Events;
using Ui.Game;
using UnityEngine;

namespace Logic.Creators
{
    public class HitObjectCreator : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        private int offset;

        private void Update()
        {
            for (int i = this.offset; i < Assets.Instance.BeatMap.Enemies.Count; i++)
            {
                if (Assets.Instance.Settings.IncomingSpeed * (-AudioPlayer.Instance.TrueAudioTime + Assets.Instance.BeatMap.Enemies[i].SpawnTime) +
                    5.6 * Assets.Instance.Settings.ElementsSize <= Assets.Instance.Settings.Resolution.Corner)
                {
                    this.CreateEnemy(Assets.Instance.BeatMap.Enemies[i]);
                    this.offset++;
                }
            }
        }

        private void CreateEnemy(EnemyEvent self)
        {
            GameObject enemyInstance = Instantiate(this.enemy, this.transform, false);
            enemyInstance.GetComponent<HitObject>().Construct(self, Assets.Instance.Settings.IncomingSpeed);
        }
    }
}