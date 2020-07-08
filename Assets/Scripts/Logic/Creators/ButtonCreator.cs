using System.Collections.Generic;
using System.Linq;
using Beatmaps;
using Database;
using Logic.Loaders;
using Ui.LevelSelection;
using Ui.LevelSelection.ButtonExtras;
using UnityEngine;

namespace Logic.Creators
{
    public class ButtonCreator : MonoBehaviour
    {
        [SerializeField] private GameObject beatMapButtonTemp;
        [SerializeField] private GameObject options;
        private readonly List<GameObject> beatMaps = new List<GameObject>();
        
        public void Start() => this.CreateAllButtons();
        
        private void CreateAllButtons()
        {
            foreach (BeatMapData beatMapData in InflexContext.Load())
            {
                this.CreateSingleButton(beatMapData);
            }

            BeatMapButton.Options = this.options;
        }

        private void CreateSingleButton(BeatMapData beatMap)
        {
            GameObject button = Instantiate(this.beatMapButtonTemp, this.gameObject.transform, false);
            button.GetComponent<BeatMapButton>().SetData(beatMap);
            this.beatMaps.Add(button);
        }
        
        private void Update()
        {
            if (InputManager.MacroDown("RefreshMaps"))
            {
                this.RefreshBeatMaps();
            }
        }
        
        private void RefreshBeatMaps()
        {
            this.DeleteAllButtons();
            this.beatMaps.Clear();
            InflexContext.Save();
            this.CreateAllButtons();
        }

        private void DeleteAllButtons() => this.beatMaps.ForEach(Destroy);
    }
}