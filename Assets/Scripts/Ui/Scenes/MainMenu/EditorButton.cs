using UnityEngine;

namespace Ui.Scenes.MainMenu
{
    public class EditorButton : ButtonBase
    {
        [SerializeField] private GameObject newBeatMap;
        [SerializeField] private GameObject openExisting;
        [SerializeField] private GameObject text;

        protected override void Left()
        {
            this.Image.enabled = false;
            this.text.SetActive(false);
            this.newBeatMap.SetActive(true);
            this.openExisting.SetActive(true);
            this.RectTransform.sizeDelta = new Vector2(450, 120);
        }
    }
}