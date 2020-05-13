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
        private readonly List<GameObject> levels = new List<GameObject>();
        [SerializeField] private GameObject levelButtonTemp;

        public void Start() => this.CreateAllButtons();

        private void Update()
        {
            if (InputManager.MacroDown("RefreshMaps"))
            {
                this.RefreshLevels();
            }
        }

        private void DeleteAllButtons() => this.levels.ForEach(Destroy);

        private void CreateAllButtons() => LevelDataLoader.Load().ToList().ForEach(this.CreateSingleButton);

        private void RefreshLevels()
        {
            this.DeleteAllButtons();
            this.levels.Clear();
            LevelDataLoader.Save();
            this.CreateAllButtons();
        }

        private void CreateSingleButton(LevelData level)
        {
            GameObject button = Instantiate(this.levelButtonTemp, this.levelButtonTemp.transform.parent, false);
            button.SetActive(true);
            button.GetComponent<LevelButton>().SetButtonData(level);
            this.levels.Add(button);
        }
    }
}