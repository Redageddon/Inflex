using UnityEngine;
using UnityEngine.UI;

public class KeySetter : ButtonBase
{
    [SerializeField] private int keyIndex;
    [SerializeField] private Text text;
    private bool waitingForInput;

    private void Start() => SetText();

    private void OnGUI()
    {
        if(!waitingForInput || !Event.current.isKey) return;
        Assets.Instance.Settings.Keys[keyIndex] = Event.current.keyCode;
        waitingForInput = false;
        SetText();
    }

    private void SetText() => text.text = $" Input{keyIndex}: {Assets.Instance.Settings.Keys[keyIndex]}";

    protected override void Left() => waitingForInput = true;
}