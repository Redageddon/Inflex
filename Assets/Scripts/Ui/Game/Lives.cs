using Logic;

namespace Ui.Game
{
    public class Lives : WrittenElement
    {
        private void Update() => this.Text.text = $"Lives: {StaminaBar.Score}";
    }
}