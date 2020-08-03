using System;
using System.Globalization;
using System.Threading.Tasks;
using UnityEngine;

namespace Ui.Game
{
    public class Judgement : WrittenElement
    {
        public async void Judge(double hitObjectRotation, double arrowRotation)
        {
            this.gameObject.SetActive(true);
            double accuracy = Grade(hitObjectRotation, arrowRotation);

            this.Text.color = Color.HSVToRGB((float)accuracy / 100, 1, 1, true);
            this.Text.text  = accuracy.ToString(CultureInfo.CurrentCulture);

            await Task.Delay(150);
            this.gameObject.SetActive(false);
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