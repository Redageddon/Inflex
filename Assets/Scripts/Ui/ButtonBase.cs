using System;
using UnityEngine.EventSystems;

namespace Ui
{
    public abstract class ButtonBase : VisibleElement, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            if (eventData == null)
            {
                throw new NullReferenceException();
            }

            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    this.Left();
                    break;
                case PointerEventData.InputButton.Right:
                    this.Right();
                    break;
                case PointerEventData.InputButton.Middle:
                    this.Middle();
                    break;
            }
        }

        protected abstract void Left();

        protected virtual void Middle() => this.Left();

        protected virtual void Right() => this.Left();
    }
}