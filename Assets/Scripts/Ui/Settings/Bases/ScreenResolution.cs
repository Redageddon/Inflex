using Logic;
using UnityEngine;

namespace Ui.Settings.Bases
{
    public static class ScreenResolution
    {
        public static void Refresh()
        {
            UnityEngine.Screen.SetResolution(Assets.Instance.Settings.Resolution.Width,
                                             Assets.Instance.Settings.Resolution.Height,
                                             Assets.Instance.Settings.FullscreenMode,
                                             Assets.Instance.Settings.Resolution.RefreshRate);
            Application.targetFrameRate = Assets.Instance.Settings.Resolution.RefreshRate;
        }
    }
}