public class BackButton : Button
{
    private void Update()
    {
        image.texture = Assets.Instance.Skin.BackButton ? Assets.Instance.Skin.BackButton : image.texture;
    }
}