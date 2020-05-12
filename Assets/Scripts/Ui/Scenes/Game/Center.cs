using UnityEngine;

public class Center : VisibleElement
{
    private void Awake()
    {
        this.Image.texture = Assets.Instance.Skin.Center ? Assets.Instance.Skin.Center : Image.texture;
        this.RectTransform.sizeDelta = new Vector2(Assets.Instance.Settings.ElementsSize * 4.2f, Assets.Instance.Settings.ElementsSize * 4.2f);
    }
}