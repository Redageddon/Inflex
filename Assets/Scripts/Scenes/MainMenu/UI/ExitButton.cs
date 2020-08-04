using Ui;
using UnityEngine;

namespace Scenes.MainMenu.UI
{
    public class ExitButton : MouseNavigationControl
    {
        protected override void LeftClick() => Application.Quit();
    }
}