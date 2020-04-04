using UnityEngine;

public class CurrentKey : VisibleElement
{
    public static int Key;
    [SerializeField] private Sprite[] sprites;
    
    private void Update()
    {
        for (var i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(AssetLoader.Instance.SavedSettings.Keys[i])) continue;
            image.sprite = sprites[i];
            Key = i;
        }
    }
}