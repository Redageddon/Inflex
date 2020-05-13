using System.Diagnostics;

namespace Ui.Scenes.MainMenu
{
    public class HyperLink : ButtonBase
    {
        protected override void Left() => Process.Start("https://github.com/rubiksmaster02/Inflex");
    }
}