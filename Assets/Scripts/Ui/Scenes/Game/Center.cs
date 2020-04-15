using UnityEngine;

public class Center : VisibleElement
{
    private void Awake()
    {
        image.texture = Assets.Instance.Skin.Center ? Assets.Instance.Skin.Center : image.texture;
        rectTransform.sizeDelta = new Vector2(Assets.Instance.Settings.ElementsSize * 4.2f, Assets.Instance.Settings.ElementsSize * 4.2f);
    }
}