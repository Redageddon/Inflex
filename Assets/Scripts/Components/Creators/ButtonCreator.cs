using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject levelButtonTemp;
    private readonly List<GameObject> levels = new List<GameObject>();

    public void Start() => CreateAllButtons();

    private void Update() => CheckForLevelsRefreshMacro();

    private void DeleteAllButtons() => levels.ForEach(Destroy);

    private void CreateAllButtons() => LevelDataLoader.Load().ToList().ForEach(CreateSingleButton);
    
    private void CheckForLevelsRefreshMacro()
    {
        if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetKeyDown(KeyCode.R)) return;
        LevelDataLoader.Save();
        DeleteAllButtons();
        levels.Clear();
        CreateAllButtons();
    }

    private void CreateSingleButton(LevelData level)
    {
        GameObject button = Instantiate(levelButtonTemp, levelButtonTemp.transform.parent, false);
        levels.Add(button);
        button.SetActive(true);
        button.GetComponent<LevelButton>().SetButtonData(level);
    }
}