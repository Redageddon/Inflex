using UnityEngine.EventSystems;

namespace Ui
{
    public abstract class MouseNavigationControl : VisibleElement, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    this.LeftClick();
                    break;
                case PointerEventData.InputButton.Right:
                    this.RightClick();
                    break;
                case PointerEventData.InputButton.Middle:
                    this.MiddleClick();
                    break;
            }
        }

        protected abstract void LeftClick();

        protected virtual void MiddleClick() => this.LeftClick();

        protected virtual void RightClick() => this.LeftClick();
    }
}