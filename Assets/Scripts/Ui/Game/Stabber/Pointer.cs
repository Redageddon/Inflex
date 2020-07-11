using System;
using UnityEngine;
using X10D;

namespace Ui.Game.Hitter
{
    public class Pointer : VisibleElement
    {
        public static double GetPointerRotation()
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mousePosition = Input.mousePosition;
            Vector2 screenMousePosition = screenCenter - mousePosition;

            return Math.Atan2(screenMousePosition.x, - screenMousePosition.y).RadiansToDegrees() + 180;
        }

        private void Update() => this.transform.localRotation = Quaternion.Euler(0, 0, (float) (GetPointerRotation() - 180));
    }
}