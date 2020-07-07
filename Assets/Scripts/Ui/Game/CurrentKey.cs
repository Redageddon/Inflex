using Logic;
using UnityEngine;

namespace Ui.Game
{
    public class CurrentKey : VisibleElement
    {
        [SerializeField] private Sprite[] sprites;
        public Sprite[] Sprites => this.sprites;
        
        public static int Key { get; private set; }

        private void Update()
        {
            for (int i = 0; i < 4; i++)
            {
                if (!Input.GetKeyDown((KeyCode) Assets.Instance.Settings.Keys[i]))
                {
                    continue;
                }
                
                this.SetSize(new Vector2(-this.sprites[i].rect.xMax, -this.sprites[i].rect.yMax));
                this.Image.texture = this.sprites[i].texture;
                Key = i;
            }
        }

        public override void SetSize(Vector2 size) => this.RectTransform.offsetMin = size;
    }
}