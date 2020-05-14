using System;
using System.Globalization;
using Components;
using Components.Loaders;
using Ui.Scenes.LevelSelection.ButtonExtras;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ui.Scenes.LevelSelection
{
    public class BeatMapButton : ButtonBase
    {
        [SerializeField] private GameObject beatMapButtonOptions;
        private BeatMapData beatMapData;
        [SerializeField] private Text beatMapNameText;
        [SerializeField] private Text difficulty;

        public void SetButtonData(BeatMapData data)
        {
            this.beatMapData = data ?? throw new NullReferenceException();
            this.Image.texture = Assets.Instance.Skin.BeatMapButton
                ? Assets.Instance.Skin.BeatMapButton
                : this.Image.texture;
            this.Image.SetNativeSize();
            this.beatMapNameText.text = this.beatMapData.Title;
            this.difficulty.text = this.beatMapData.Difficulty.ToString(CultureInfo.CurrentCulture);
        }

        protected override void Left()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
            Assets.Instance.BeatMap = Loader.LoadBeatMap(this.beatMapData.Path);
        }

        protected override void Right()
        {
            this.beatMapButtonOptions.SetActive(true);
            this.beatMapButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionIndex = this.beatMapData.Id;
            this.beatMapButtonOptions.transform.Find("DeleteMap").GetComponent<DeleteMapButton>().DeletionButton = this.gameObject;
        }
    }
}