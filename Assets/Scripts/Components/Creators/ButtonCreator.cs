using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject levelButtonTemp;

    public void Start()
    {
        foreach (var level in LevelDataLoader.Load())
        {
            CreateLevelButton(level);
        }
    }
    
    private void Update() => CheckForLevelsRefreshMacro();

    private static void CheckForLevelsRefreshMacro()
    {
        if (!Input.GetKey(KeyCode.LeftControl) || !Input.GetKeyDown(KeyCode.R)) return;
        
        LevelDataLoader.Save();
        
        SceneManager.LoadScene("LevelSelection", LoadSceneMode.Single);
    }

    private void CreateLevelButton(LevelData level)
    {
        GameObject button = Instantiate(levelButtonTemp, levelButtonTemp.transform.parent, false);
        button.SetActive(true);
        button.GetComponent<LevelButton>().SetButtonData(level);
    }
}