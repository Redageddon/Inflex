using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class VisibleElement : MonoBehaviour
    {
        [SerializeField] private RawImage      image;
        [SerializeField] private RectTransform rectTransform;

        public RawImage Image
        {
            get => this.image;
            set => this.image = value;
        }

        public RectTransform RectTransform
        {
            get => this.rectTransform;
            set => this.rectTransform = value;
        }

        public virtual void SetSize(Vector2 vector2) => this.RectTransform.sizeDelta = vector2;
    }
}