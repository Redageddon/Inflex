using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.Game.Logic
{
    public class JudgementHandler : MonoBehaviour
    {
        [SerializeField] private Text text;
        private static           Text sText;

        private void Awake() => sText = this.text;

        public static async void Judge(float hitObjectRotation = 0, float arrowRotation = 180)
        {
            sText.gameObject.SetActive(true);
            float accuracy = Grade(hitObjectRotation, arrowRotation);

            sText.color = Color.HSVToRGB(accuracy / 100, 1, 1, true);
            sText.text  = accuracy.ToString();

            await Task.Delay(150);
            sText.gameObject.SetActive(false);
        }

        private static float Grade(float hitObjectRotation, float arrowRotation)
        {
            const int grader = 15;

            float truePointerRotation = arrowRotation - hitObjectRotation > 100 ? arrowRotation - 360 : arrowRotation;

            return Mathf.Abs(truePointerRotation - hitObjectRotation) < grader
                ? Mathf.Round(100 * (Mathf.Abs(truePointerRotation - hitObjectRotation) - grader) / -grader)
                : 0;
        }
    }
}