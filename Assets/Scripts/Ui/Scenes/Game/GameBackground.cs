using Components;
using Logic.Loaders;

namespace Ui.Scenes.Game
{
    public class GameBackground : VisibleElement
    {
        private void Start() => this.Image.texture = FileLoader.LoadTexture2D($"{Assets.Instance.BeatMap.Path}/{Assets.Instance.BeatMap.Background}");
    }
}