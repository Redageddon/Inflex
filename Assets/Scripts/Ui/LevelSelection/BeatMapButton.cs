using System;
using Audio;
using Beatmaps;
using Logic;
using Ui.LevelSelection.ButtonExtras;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.LevelSelection
{
    public class BeatMapButton : NavigationButton
    {
        public static            GameObject      Options;
        private                  BeatMapMetadata beatMapMetadata;
        [SerializeField] private Text            beatMapNameText;
        [SerializeField] private Text            difficulty;

        public void SetData(BeatMapMetadata metadata)
        {
            this.beatMapMetadata      = metadata ?? throw new NullReferenceException();
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