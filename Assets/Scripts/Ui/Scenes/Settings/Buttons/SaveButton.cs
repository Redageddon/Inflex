using UnityEngine;
using UnityEngine.UI;

public class SaveButton : ButtonBase
{
    [SerializeField] private Button saveButton;

    protected override void Left() => JsonLoader.Save(Assets.Instance.Settings, GenericPaths.SettingsPath);
}