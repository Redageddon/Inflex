using UnityEngine;

public class CurrentKey : VisibleElement
{
    public static int Key;
    [SerializeField] private Sprite[] sprites;

    private void Awake() => SetImage(0);

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown((KeyCode)Assets.Instance.Settings.Keys[i])) continue;
            SetImage(i);
            Key = i;
        }
    }

    private void SetImage(int current)
    {
        image.texture = Assets.Instance.Skin.CurrentKeys[current] is null ? sprites[current].texture : Assets.Instance.Skin.CurrentKeys[current];
        rectTransform.offsetMin = new Vector2(-sprites[current].rect.xMax, -sprites[current].rect.yMax);
    }
}