using System.Diagnostics;

namespace Ui.MainMenu
{
    public class HyperLink : MouseNavigationControl
    {
        protected override void LeftClick() => Process.Start("https://github.com/rubiksmaster02/Inflex");
    }
}