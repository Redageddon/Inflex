using UnityEngine;

public class CancelButton : ButtonBase
{
    [SerializeField] private GameObject levelButtonOptions;

    protected override void Left() => this.levelButtonOptions.SetActive(false);
}