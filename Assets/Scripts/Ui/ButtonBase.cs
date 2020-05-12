using System;
using UnityEngine.EventSystems;

public abstract class ButtonBase : VisibleElement, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
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
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected abstract void Left();

    protected virtual void Middle() => this.Left();

    protected virtual void Right() => this.Left();
}