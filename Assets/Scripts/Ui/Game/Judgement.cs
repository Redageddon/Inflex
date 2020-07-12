using System;
using System.Globalization;
using UnityEngine;

namespace Ui.Game
{
    public class Judgement : WrittenElement
    {
        public static void CreateNewJudgement(double hitObjectRotation, double arrowRotation)
        {
            
        }

        private void Judge(double hitObjectRotation, double arrowRotation)
        {
            double accuracy = Grade(hitObjectRotation, arrowRotation);

            this.Text.color = Color.HSVToRGB((float) accuracy / 100, 1, 1, true);
            this.Text.text = accuracy.ToString(CultureInfo.CurrentCulture);
            Destroy(this.gameObject, 0.15f);
        }

        private static double Grade(double hitObjectRotation, double arrowRotation)
        {
            const int grader = 15;

            double truePointerRotation = FixPointerRotation(arrowRotation, hitObjectRotation);

            return Math.Abs(truePointerRotation - hitObjectRotation) < grader
                ? Math.Round(100 * (Math.Abs(truePointerRotation - hitObjectRotation) - grader) / -grader)
                : 0;
        }

        private static double FixPointerRotation(double pointerRotation, double hitObjectRotation) => 
            pointerRotation - hitObjectRotation > 100 ? pointerRotation -= 360 : pointerRotation;
    }
}