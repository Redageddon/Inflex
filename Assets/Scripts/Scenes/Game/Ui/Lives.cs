using Scenes.Game.Logic;
using Ui;

namespace Scenes.Game.Ui
{
    public class Lives : WrittenElement
    {
        private void Update() => this.Text.text = $"Lives: {StaminaBar.Score}";
    }
}