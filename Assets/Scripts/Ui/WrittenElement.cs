using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    public class WrittenElement : MonoBehaviour
    {
        [SerializeField] private Text          text;
        [SerializeField] private RectTransform rectTransform;

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