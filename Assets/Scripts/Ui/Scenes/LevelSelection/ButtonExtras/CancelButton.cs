using UnityEngine;

public class CancelButtonBase : ButtonBase
{
    [SerializeField] private GameObject levelButtonControl;
    protected override void Left() => levelButtonControl.SetActive(false);
}