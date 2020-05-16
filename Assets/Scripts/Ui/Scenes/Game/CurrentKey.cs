using Components;
using UnityEngine;

namespace Ui.Scenes.Game
{
    public class CurrentKey : VisibleElement
    {
        [SerializeField] private Sprite[] sprites;
        public static int Key { get; set; }

        private void Awake() => this.SetImage(0);

        private void Update()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!Input.GetKeyDown((KeyCode) Assets.Instance.Settings.Keys[i]))
                {
                    continue;
                }

                this.SetImage(i);
                Key = i;
            }
        }

        private void SetImage(int current)
        {
            this.Image.texture = Assets.Instance.Skin.CurrentKeys[current] is null 
                ? this.sprites[current].texture 
                : Assets.Instance.Skin.CurrentKeys[current];
            this.RectTransform.offsetMin = new Vector2(-this.sprites[current].rect.xMax, -this.sprites[current].rect.yMax);
        }
    }
}