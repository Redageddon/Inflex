using UnityEngine;

namespace Logic
{
    public class StaminaBar : MonoBehaviour
    {
        private void Awake() => Score = Assets.Instance.BeatMap.Lives;

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
    }
}