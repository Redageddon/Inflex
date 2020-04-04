using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject levelButtonTemp;

    public void Start()
    {
        var levelNames = LevelDataLoader.Instance.Load(GenericPaths.LevelsDataPath);
        if(levelNames == null) return;
        foreach (var level in levelNames)
        {
            CreateLevelButton(level);
        }
    }
    
    private void Update()
    {
        CheckForLevelsRefreshMacro();
    }

    private void CheckForLevelsRefreshMacro()
    {
        if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetKeyDown(KeyCode.R)) return;
        LevelDataLoader.Instance.Save(GenericPaths.LevelsDataPath);
        SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
    }

    private void CreateLevelButton(LevelData level)
    {
        GameObject button = Instantiate(levelButtonTemp, levelButtonTemp.transform.parent, false);
        button.SetActive(true);
        button.GetComponent<LevelButton>().levelData = level;
    }
}