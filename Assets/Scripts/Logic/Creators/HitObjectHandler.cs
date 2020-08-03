using Audio;
using Beatmaps.Events;
using Ui.Game;
using Ui.Game.Pointer;
using UnityEngine;

namespace Logic.Creators
{
    public class HitObjectHandler : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private Judgement  judgement;
        private                  int        offset;

        private void Update()
        {
            for (int i = this.offset; i < Assets.Instance.BeatMapMeta.Enemies.Count; i++)
            {
                if (Assets.Instance.Settings.IncomingSpeed *
                    (-AudioPlayer.Instance.TrueAudioTime + Assets.Instance.BeatMapMeta.Enemies[i].SpawnTime) +
                    5.6 * Assets.Instance.Settings.ElementsSize <= Assets.Instance.Settings.Resolution.Corner)
                {
                    this.CreateEnemy(Assets.Instance.BeatMapMeta.Enemies[i]);
                    this.offset++;
                }
            }
        }

        private void CreateEnemy(EnemyEvent self)
        {
            GameObject enemyInstance = Instantiate(this.enemy, this.transform, false);
            enemyInstance.GetComponent<HitObject>().Constructor(self, Assets.Instance.Settings.IncomingSpeed, this.OnHit);
        }

        public void OnHit(HitObject hitObject)
        {
            if (hitObject.KillKey != CurrentKey.Key || hitObject.LocationManager.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                this.judgement.Judge(0, 180);
                StaminaBar.Score--;
            }
            else
            {
                this.judgement.Judge(hitObject.LocationManager.Rotation, Arrow.GetPointerRotation());
            }

            Destroy(hitObject.gameObject);
        }
    }
}