using Ui.Game;
using Ui.Game.Pointer;
using UnityEngine;

namespace Logic
{
    public static class HitObjectHandler
    {
        public static void OnHit(HitObject hitObject)
        {
            if (hitObject.killKey != CurrentKey.Key || hitObject.distance <= 2.71 * Assets.Instance.Settings.ElementsSize)
            {
                StaminaBar.Score--;
            }
            
            Judgement.CreateNewJudgement(hitObject.rotation, Arrow.GetPointerRotation());

            Object.Destroy(hitObject.gameObject);
        }
    }
}