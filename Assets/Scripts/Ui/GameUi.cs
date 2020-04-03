using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Text lives;
    [SerializeField] private Text currentKey;
    public static int CurrentKey;
    
    private void Awake()
    {
        Health.Lives = MapHandler.Instance.Map.Lives;
    }

    private void Update()
    {
        UpdateUi();
        UpdateHealth();
    }
    
    private void UpdateHealth()
    {
        lives.text = " Lives: " + Health.Lives;
    }
    
    private void UpdateUi()
    {
        for (var i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(SettingsHandler.Instance.SavedSettings.Keys[i])) continue;
            currentKey.text = SettingsHandler.Instance.SavedSettings.Keys[i].ToString();
            CurrentKey = i;
        }
    }

    public void SetLives(int l)
    {
        //lives.text = l.ToString();
    }

    public void ShowPauseMenu()
    {
        
    }
    
    public void HidePauseMenu()
    {
        
    }

    public void ShowGameMenu()
    {
        
    }

    public void HideGameMenu()
    {
        
    }
}