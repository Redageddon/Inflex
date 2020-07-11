using System;
using System.Globalization;
using Ui.Game.Hitter;
using UnityEngine;

namespace Ui.Game
{
    public class Judgement : WrittenElement
    {
        public void AssignValue(double rotation)
        {
            double accuracy = Grade(rotation);

            this.Text.color = Color.HSVToRGB((float) accuracy / 100, 1, 1, true);
            this.Text.text = accuracy.ToString(CultureInfo.CurrentCulture);
            Destroy(this.gameObject, 0.15f);
        }

        private static double Grade(double hitObjectRotation)
        {
            const int grader = 15;

            double truePointerRotation = FixPointerRotation(Pointer.GetPointerRotation(), hitObjectRotation);

            return Math.Abs(truePointerRotation - hitObjectRotation) < grader
                ? Math.Round(100 * (Math.Abs(truePointerRotation - hitObjectRotation) - grader) / -grader)
                : 0;
        }

        private static double FixPointerRotation(double pointerRotation, double hitObjectRotation) => 
            pointerRotation - hitObjectRotation > 100 ? pointerRotation -= 360 : pointerRotation;
    }
}