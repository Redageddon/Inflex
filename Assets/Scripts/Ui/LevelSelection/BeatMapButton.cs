using System;
using Beatmaps;
using Logic;
using Logic.Loaders;
using Ui.LevelSelection.ButtonExtras;
using UnityEngine;
using UnityEngine.UI;

namespace Ui.LevelSelection
{
    public class BeatMapButton : NavigationButton
    {
        [SerializeField] private Text        beatMapNameText;
        [SerializeField] private Text        difficulty;
        private                  BeatMapData beatMapData;
        public static            GameObject  Options;

        public void SetData(BeatMapData data)
        {
            this.beatMapData          = data ?? throw new NullReferenceException();
            this.beatMapNameText.text = this.beatMapData.Title;
            this.difficulty.text      = this.beatMapData.Difficulty.ToString();
        }

        protected override void LeftClick()
        {
            base.LeftClick();
            Assets.Instance.BeatMap = FileLoader.LoadBeatMap(this.beatMapData.Path);
        }

        protected override void RightClick()
        {
            Options.SetActive(true);
            DeleteMapButton.Button = this.gameObject;
            DeleteMapButton.Data   = this.beatMapData;
        }
    }
}