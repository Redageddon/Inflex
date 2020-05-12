public class GameBackground : VisibleElement
{
    private void Start() => this.Image.texture = Loader.LoadTexture2D($"{Assets.Instance.Level.Path}/{Assets.Instance.Level.Background}");
}