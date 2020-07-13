using Ui.Game;
using Ui.Game.Pointer;
using UnityEngine;

namespace Logic
{
    public class HitObjectHandler : MonoBehaviour
    {
        [SerializeField] private Judgement Judgement;
        private static Judgement sJudgement;

        private void Awake() => sJudgement = this.Judgement;

        public static void OnHit(HitObject hitObject)
        {
            if (hitObject.killKey != CurrentKey.Key || hitObject.distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                StaminaBar.Score--;
            }
            
            sJudgement.Judge(hitObject.rotation, Arrow.GetPointerRotation());

            Destroy(hitObject.gameObject);
        }
    }
}