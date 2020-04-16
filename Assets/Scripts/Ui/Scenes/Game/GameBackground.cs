public class GameBackground : VisibleElement
{
    private void Start() => image.texture = JsonLoader.LoadTexture2D($"{Assets.Instance.Level.Path}/{Assets.Instance.Level.Background}");
}