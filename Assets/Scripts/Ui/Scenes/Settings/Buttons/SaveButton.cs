using Inflex.Rron;
using UnityEngine;
using UnityEngine.UI;

public class SaveButton : ButtonBase
{
    [SerializeField] private Button saveButton;

    protected override void Left() => RronConvert.SerializeObjectToFile(Assets.Instance.Settings, GenericPaths.SettingsPath);
}