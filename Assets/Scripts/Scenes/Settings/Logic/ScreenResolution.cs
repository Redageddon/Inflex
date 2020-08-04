using SceneLessLogic;
using UnityEngine;

namespace Scenes.Settings.Logic
{
    public static class ScreenResolution
    {
        public static void Refresh()
        {
            Screen.SetResolution(Assets.Instance.Settings.Resolution.Width,
                                 Assets.Instance.Settings.Resolution.Height,
                                 Assets.Instance.Settings.FullscreenMode,
                                 Assets.Instance.Settings.Resolution.RefreshRate);
            Application.targetFrameRate = Assets.Instance.Settings.Resolution.RefreshRate;
        }
    }
}