using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class WrittenElement : MonoBehaviour
    {
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Text          text;

        public Text Text
        {
            get => this.text;
            set => this.text = value;
        }

        public RectTransform RectTransform
        {
            get => this.rectTransform;
            set => this.rectTransform = value;
        }

        public virtual void SetSize(Vector2 vector2) => this.RectTransform.sizeDelta = vector2;
    }
}