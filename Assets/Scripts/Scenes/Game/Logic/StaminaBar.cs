using SceneLessLogic;
using UnityEngine;

namespace Scenes.Game.Logic
{
    public class StaminaBar : MonoBehaviour
    {
        private static int score;

        public static int Score
        {
            get => score;
            set
            {
                if (value <= 0)
                {
                    EndpointConditions.GameLose();
                }

                score = value;
            }
        }

        private void Awake() => Score = Assets.Instance.BeatMapMeta.Lives;
    }
}