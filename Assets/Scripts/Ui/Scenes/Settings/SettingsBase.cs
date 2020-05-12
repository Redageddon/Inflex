using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SettingsBase : MonoBehaviour
{
    protected IEnumerable<UnityEngine.Resolution> Resolutions { get; private set; }

    protected void SetScreenValues()
    {
        Screen.SetResolution(
            this.Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
            this.Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
            (FullScreenMode)Assets.Instance.Settings.FullscreenModeIndex,
            Assets.Instance.Settings.PreferredFps);
        Application.targetFrameRate = Assets.Instance.Settings.PreferredFps;
    }

    private void OnEnable() => this.Resolutions = Screen.resolutions.Select(resolution => new UnityEngine.Resolution { width = resolution.width, height = resolution.height }).Distinct();
}