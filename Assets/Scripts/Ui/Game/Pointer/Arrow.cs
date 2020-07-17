using System;
using Logic.Creators;
using UnityEngine;
using X10D;

namespace Ui.Game.Pointer
{
    public class Arrow : VisibleElement
    {
        [SerializeField] private HitObjectHandler hitObjectHandler;
        public static double GetPointerRotation()
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mousePosition = Input.mousePosition;
            Vector2 screenMousePosition = screenCenter - mousePosition;

            return Math.Atan2(screenMousePosition.x, - screenMousePosition.y).RadiansToDegrees() + 180;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            HitObject hitObject = other.GetComponent<HitObject>();
            this.hitObjectHandler.OnHit(hitObject);
        }

        private void Update() => this.transform.localRotation = Quaternion.Euler(0, 0, (float) (GetPointerRotation() - 180));
    }
}