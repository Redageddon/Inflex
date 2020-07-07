using UnityEngine;

namespace Ui.MainMenu
{
    public class ExitButton : MouseNavigationControl
    {
        protected override void LeftClick() => Application.Quit();
    }
}