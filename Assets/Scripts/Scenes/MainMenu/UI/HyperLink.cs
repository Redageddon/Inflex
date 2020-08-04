using System.Diagnostics;
using Ui;

namespace Scenes.MainMenu.UI
{
    public class HyperLink : MouseNavigationControl
    {
        protected override void LeftClick() => Process.Start("https://github.com/rubiksmaster02/Inflex");
    }
}