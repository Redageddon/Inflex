using System;
using UnityEngine;

public class Pointer : VisibleElement
{
    [SerializeField] private EdgeCollider2D edgeCollider2D;

    private void Awake()
    {
        var centerSize = Assets.Instance.SavedSettings.ElementsSize;
        image.texture = Assets.Instance.Skin.Pointer ? Assets.Instance.Skin.Pointer: image.texture;
        rectTransform.sizeDelta = new Vector2(centerSize * 5.6f, centerSize * 5.6f);
        edgeCollider2D.points = new[]
        {
            new Vector2(centerSize * -0.37f, centerSize * 2.27f),
            new Vector2(0, centerSize * 2.8f),
            new Vector2(centerSize * 0.37f, centerSize * 2.27f)
        };
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<HitObject>().killKey != CurrentKey.Key)
        {
            Lives.Health -= 1;
        }

        other.GetComponent<HitObject>().Hit();
    }

    public static double GetZRotation()
    {
        var x = Screen.width / 2d - Input.mousePosition.x;
        var y = Screen.height / 2d - Input.mousePosition.y;
        return Math.Atan2(x, -y) * Mathf.Rad2Deg + 180;
    }

    private void Update() => SetZRotation();

    private void SetZRotation() => transform.localRotation = Quaternion.Euler(0, 0, (float) (GetZRotation() - 180));
    
}