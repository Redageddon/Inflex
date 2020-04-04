using UnityEngine;

public class Center : VisibleElement
{
    private void Awake()
    {
        rectTransform.sizeDelta = new Vector2(AssetLoader.Instance.SavedSettings.ElementsSize * 4.2f, AssetLoader.Instance.SavedSettings.ElementsSize * 4.2f);
    }
}