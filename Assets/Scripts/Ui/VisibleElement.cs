using UnityEngine;
using UnityEngine.UI;

public class VisibleElement : MonoBehaviour
{
    [SerializeField] private RawImage image;
    [SerializeField] private RectTransform rectTransform;

    protected RawImage Image
    {
        get => this.image;
        set => this.image = value;
    }

    protected RectTransform RectTransform
    {
        get => this.rectTransform;
        set => this.rectTransform = value;
    }
}