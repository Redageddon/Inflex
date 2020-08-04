using Scenes.Game.Logic;
using Ui;
using UnityEngine;
using X10D;

namespace Scenes.Game.Ui.Pointer
{
    public class Arrow : VisibleElement
    {
        public static float GetPointerRotation()
        {
            Vector2 screenCenter        = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mousePosition       = Input.mousePosition;
            Vector2 screenMousePosition = screenCenter - mousePosition;

            return Mathf.Atan2(screenMousePosition.x, -screenMousePosition.y).RadiansToDegrees() + 180;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            HitObject hitObject = other.GetComponent<HitObject>();
            HitObjectHandler.OnHit(hitObject);
        }

        private void Update() => this.transform.localRotation = Quaternion.Euler(0, 0, (GetPointerRotation() - 180));
    }
}