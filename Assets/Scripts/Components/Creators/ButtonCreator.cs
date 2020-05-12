using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject levelButtonTemp;
    private readonly List<GameObject> levels = new List<GameObject>();

    public void Start() => CreateAllButtons();

    private void Update()
    {
        if (InputManager.MacroDown("RefreshMaps")) RefreshLevels();
    }

    private void DeleteAllButtons() => levels.ForEach(Destroy);

    private void CreateAllButtons() => LevelDataLoader.Load().ToList().ForEach(CreateSingleButton);

    private void RefreshLevels()
    {
        DeleteAllButtons();
        levels.Clear();
        LevelDataLoader.Save();
        CreateAllButtons();
    }

    private void CreateSingleButton(LevelData level)
    {
        GameObject button = Instantiate(levelButtonTemp, levelButtonTemp.transform.parent, false);
        button.SetActive(true);
        button.GetComponent<LevelButton>().SetButtonData(level);
        levels.Add(button);
    }
}