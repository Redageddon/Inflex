using UnityEngine;

public class Center : VisibleElement
{
    private void Awake()
    {
        rectTransform.sizeDelta = new Vector2(SettingsHandler.Instance.SavedSettings.ElementsSize * 4.2f, SettingsHandler.Instance.SavedSettings.ElementsSize * 4.2f);
    }
}