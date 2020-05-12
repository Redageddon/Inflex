using UnityEngine;

public class CurrentKey : VisibleElement
{
    public static int Key;
    [SerializeField] private Sprite[] sprites;

    private void Awake() => this.SetImage(0);

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown((KeyCode)Assets.Instance.Settings.Keys[i]))
            {
                continue;
            }

            this.SetImage(i);
            Key = i;
        }
    }

    private void SetImage(int current)
    {
        this.Image.texture = Assets.Instance.Skin.CurrentKeys[current] is null ? this.sprites[current].texture : Assets.Instance.Skin.CurrentKeys[current];
        this.RectTransform.offsetMin = new Vector2(-this.sprites[current].rect.xMax, -this.sprites[current].rect.yMax);
    }
}