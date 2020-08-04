using Audio;
using SceneLessLogic;
using SceneLessLogic.Beatmaps;
using Ui;
using UnityEngine;
using UnityEngine.UI;

namespace Scenes.BeatmapSelection.Ui
{
    public class BeatMapButton : NavigationButton
    {
        public static            GameObject      Options;
        [SerializeField] private Text beatMapNameText;
        [SerializeField] private Text difficulty;
        private                  BeatMapMetadata beatMapMetadata;

        public void Ctor(BeatMapMetadata metadata)
        {
            this.beatMapMetadata = metadata;
            this.beatMapNameText.text = this.beatMapMetadata.Title;

            //Todo: implement difficulty calculation
            this.difficulty.text = "0";
        }

        protected override void LeftClick()
        {
            base.LeftClick();
            Assets.Instance.BeatMapMeta = FileLoader.LoadBeatMap(this.beatMapMetadata.Path);
            AudioPlayer.Instance.LoadAudio($"{Assets.Instance.BeatMapMeta.Path}/{Assets.Instance.BeatMapMeta.SongFile}");
            AudioPlayer.Instance.PlayGameAudio();
        }

        protected override void RightClick()
        {
            Options.SetActive(true);
            DeleteMapButton.Button   = this.gameObject;
            DeleteMapButton.Metadata = this.beatMapMetadata;
        }
    }
}