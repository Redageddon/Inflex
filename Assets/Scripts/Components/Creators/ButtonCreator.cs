using System.Collections.Generic;
using System.Linq;
using Components.Input;
using Components.Loaders;
using Ui.Scenes.LevelSelection;
using UnityEngine;

namespace Components.Creators
{
    public class ButtonCreator : MonoBehaviour
    {
        private readonly List<GameObject> beatMaps = new List<GameObject>();
        [SerializeField] private GameObject beatMapButtonTemp;

        public void Start() => this.CreateAllButtons();

        private void Update()
        {
            if (InputManager.MacroDown("RefreshMaps"))
            {
                this.RefreshBeatMaps();
            }
        }

        private void DeleteAllButtons() => this.beatMaps.ForEach(Destroy);

        private void CreateAllButtons() => BeatMapDataLoader.Load().ToList().ForEach(this.CreateSingleButton);

        private void RefreshBeatMaps()
        {
            this.DeleteAllButtons();
            this.beatMaps.Clear();
            BeatMapDataLoader.Save();
            this.CreateAllButtons();
        }

        private void CreateSingleButton(BeatMapData beatMap)
        {
            GameObject button = Instantiate(this.beatMapButtonTemp, this.beatMapButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<BeatMapButton>().SetButtonData(beatMap);
            this.beatMaps.Add(button);
        }
    }
}