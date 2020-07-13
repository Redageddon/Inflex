﻿using System;
using System.Collections;
using System.Globalization;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using Object = System.Object;

namespace Ui.Game
{
    public class Judgement : WrittenElement
    {
        public void Judge(double hitObjectRotation, double arrowRotation)
        {
            this.gameObject.SetActive(true);
            double accuracy = Grade(hitObjectRotation, arrowRotation);

            this.Text.color = Color.HSVToRGB((float) accuracy / 100, 1, 1, true);
            this.Text.text = accuracy.ToString(CultureInfo.CurrentCulture);
            
            Task.Delay(150).ContinueWith(t => this.gameObject.SetActive(false)).Start();
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