using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SettingsBase : MonoBehaviour
{
    protected IEnumerable<UnityEngine.Resolution> Resolutions;

    private void OnEnable()
    {
       Resolutions = Screen.resolutions.Select(resolution => new UnityEngine.Resolution { width = resolution.width, height = resolution.height }).Distinct();
    }

    protected void SetScreenValues()
    {
        Screen.SetResolution(Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
                             Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
                                  (FullScreenMode) Assets.Instance.Settings.FullscreenModeIndex, 
                                 Assets.Instance.Settings.PreferredFps);
        Application.targetFrameRate = Assets.Instance.Settings.PreferredFps;
    }
}