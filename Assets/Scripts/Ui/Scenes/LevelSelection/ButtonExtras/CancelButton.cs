using UnityEngine;

public class CancelButton : Button
{
    [SerializeField] private GameObject levelButtonControl;
    protected override void Left()
    {
        levelButtonControl.SetActive(false);
    }
}