using System;
using Components;
using UnityEngine;

namespace Ui.Scenes.Game
{
    public class Pointer : VisibleElement
    {
        [SerializeField] private EdgeCollider2D edgeCollider2D;

        public static double GetZRotation()
        {
            double x = Screen.width / 2d - Input.mousePosition.x;
            double y = Screen.height / 2d - Input.mousePosition.y;
            return Math.Atan2(x, -y) * Mathf.Rad2Deg + 180;
        }

        private void Awake()
        {
            float centerSize = Assets.Instance.Settings.ElementsSize;
            this.Image.texture = Assets.Instance.Skin.Pointer ? Assets.Instance.Skin.Pointer : this.Image.texture;
            this.RectTransform.sizeDelta = new Vector2(centerSize * 5.6f, centerSize * 5.6f);
            this.edgeCollider2D.points = new[]
            {
                new Vector2(centerSize * -0.37f, centerSize * 2.27f),
                new Vector2(0, centerSize * 2.8f),
                new Vector2(centerSize * 0.37f, centerSize * 2.27f)
            };
        }

        private void OnTriggerStay2D(Collider2D other)
        {
            if (other.GetComponent<HitObject>().KillKey != CurrentKey.Key)
            {
                Lives.Health -= 1;
            }

            other.GetComponent<HitObject>().Hit();
        }

        private void Update() => this.SetZRotation();

        private void SetZRotation() => this.transform.localRotation = Quaternion.Euler(0, 0, (float) (GetZRotation() - 180));
    }
}