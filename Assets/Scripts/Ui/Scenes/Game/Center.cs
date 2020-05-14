using Components;
using UnityEngine;

namespace Ui.Scenes.Game
{
    public class Center : VisibleElement
    {
        private void Awake()
        {
            this.Image.texture = Assets.Instance.Skin.Center ? Assets.Instance.Skin.Center : this.Image.texture;
            this.RectTransform.sizeDelta = new Vector2(Assets.Instance.Settings.ElementsSize * 4.2f, Assets.Instance.Settings.ElementsSize * 4.2f);
        }
    }
}