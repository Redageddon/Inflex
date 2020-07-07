using System.Collections.Generic;
using System.Linq;
using Logic;
using UnityEngine;

namespace Ui.Settings
{
    public class SettingsBase : MonoBehaviour
    {
        protected IEnumerable<Resolution> Resolutions { get; private set; }

        protected void SetScreenValues()
        {
            Screen.SetResolution(this.Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
                                 this.Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
                                 (FullScreenMode) Assets.Instance.Settings.FullscreenModeIndex,
                                 Assets.Instance.Settings.PreferredFps);
            Application.targetFrameRate = Assets.Instance.Settings.PreferredFps;
        }

        private void OnEnable() => this.Resolutions =
            Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct();
    }
}