using System;
using System.Globalization;
using Ui.Scenes.Game;
using UnityEngine;
using UnityEngine.UI;

namespace Components.Creators
{
    public class JudgementCreator : MonoBehaviour
    {
        public static void Create(double hitObjectRotation)
        {
            double accuracy = Grade(hitObjectRotation);

            GameObject judgement = GameObject.Find("Canvas").transform.Find("Judgement").gameObject;

            GameObject newJudgement = Instantiate(judgement, judgement.transform.parent, false);
            newJudgement.GetComponent<Text>().color = Color.HSVToRGB((float) accuracy / 100, 1, 1, true);
            newJudgement.GetComponent<Text>().text = accuracy.ToString(CultureInfo.CurrentCulture);
            newJudgement.SetActive(true);
            Destroy(newJudgement, 0.15f);
        }

        private static double Grade(double hitObjectRotation)
        {
            const int grader = 15;

            double truePointerRotation = FixPointerRotation(Pointer.GetZRotation(), hitObjectRotation);

            return Math.Abs(truePointerRotation - hitObjectRotation) < grader
                ? Math.Round(100 * (Math.Abs(truePointerRotation - hitObjectRotation) - grader) / -grader)
                : 0d;
        }

        private static double FixPointerRotation(double pointerRotation, double hitObjectRotation)
        {
            if (pointerRotation - hitObjectRotation > 100)
            {
                return pointerRotation -= 360;
            }

            return pointerRotation;
        }
    }
}