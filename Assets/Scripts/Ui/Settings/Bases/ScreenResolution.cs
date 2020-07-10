using System.Collections.Generic;
using System.Linq;
using Logic;
using UnityEngine;

namespace Ui.Settings.Bases
{
    public static class ScreenResolution
    {
        static ScreenResolution()
        {
            foreach (Resolution resolution1 in UnityEngine.Screen.resolutions.Distinct())
            {
                Debug.Log(resolution1);
            }
        }

        private static readonly IEnumerable<Resolution> Resolutions =
            UnityEngine.Screen.resolutions.Select(resolution => new Resolution {width = resolution.width, height = resolution.height}).Distinct();

        public static void Refresh()
        {
            UnityEngine.Screen.SetResolution(Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).width,
                                             Resolutions.ElementAt(Assets.Instance.Settings.ResolutionIndex).height,
                                             (FullScreenMode) Assets.Instance.Settings.FullscreenModeIndex,
                                             Assets.Instance.Settings.PreferredFps);
            Application.targetFrameRate = Assets.Instance.Settings.PreferredFps;
        }
    }
}