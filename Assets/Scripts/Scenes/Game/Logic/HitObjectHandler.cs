using Audio;
using SceneLessLogic;
using SceneLessLogic.Beatmaps.Events;
using Scenes.Game.Ui;
using Scenes.Game.Ui.Pointer;
using UnityEngine;

namespace Scenes.Game.Logic
{
    public class HitObjectHandler : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
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
            enemyInstance.GetComponent<HitObject>().Ctor(self, Assets.Instance.Settings.IncomingSpeed);
        }

        public static void OnHit(HitObject hitObject)
        {
            if (hitObject.KillKey != CurrentKey.Key || hitObject.LocationHandler.Distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            { 
                JudgementHandler.Judge();
                StaminaBar.Score--;
            }
            else
            {
                JudgementHandler.Judge(hitObject.LocationHandler.Rotation, Arrow.GetPointerRotation());
            }

            Destroy(hitObject.gameObject);
        }
    }
}