using UnityEngine;

public class CancelButton : ButtonBase
{
    [SerializeField] private GameObject levelButtonOptions;
    protected override void Left() => levelButtonOptions.SetActive(false);
}