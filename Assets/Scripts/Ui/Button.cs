using System;
using UnityEngine.EventSystems;

public abstract class Button : VisibleElement, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                Left();
                break;
            case PointerEventData.InputButton.Right:
                Right();
                break;
            case PointerEventData.InputButton.Middle:
                Middle();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    protected abstract void Left();
    
    protected virtual void Middle() => Left();
    
    protected virtual void Right() => Left();
}