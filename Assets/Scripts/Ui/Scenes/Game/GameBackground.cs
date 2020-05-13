using Components;
using Components.Loaders;

namespace Ui.Scenes.Game
{
    public class GameBackground : VisibleElement
    {
        private void Start() => this.Image.texture = Loader.LoadTexture2D($"{Assets.Instance.BeatMap.Path}/{Assets.Instance.BeatMap.Background}");
    }
}