using System;
using Logic;
using UnityEngine;
using X10D;

namespace Ui.Game
{
    public class Pointer : VisibleElement
    {
        [SerializeField] private EdgeCollider2D edgeCollider2D;

        public EdgeCollider2D EdgeCollider2D
        {
            get => this.edgeCollider2D;
            set => this.edgeCollider2D = value;
        }

        public static double GetPointerRotation()
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);
            Vector2 mousePosition = Input.mousePosition;
            Vector2 screenMousePosition = screenCenter - mousePosition;

            return Math.Atan2(screenMousePosition.x, - screenMousePosition.y).RadiansToDegrees() + 180;
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.GetComponent<HitObject>().KillKey != CurrentKey.Key)
            {
                ScoreBar.Score -= 1;
            }

            other.GetComponent<HitObject>().Hit();
        }

        private void Update() => this.transform.localRotation = Quaternion.Euler(0, 0, (float) (GetPointerRotation() - 180));
    }
}