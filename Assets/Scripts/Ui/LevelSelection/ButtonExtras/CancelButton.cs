namespace Ui.LevelSelection.ButtonExtras
{
    public class CancelButton : MouseNavigationControl
    {
        protected override void LeftClick() => this.transform.parent.gameObject.SetActive(false);
    }
}