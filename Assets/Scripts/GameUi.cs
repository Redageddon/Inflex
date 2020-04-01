using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Text lives;
    [SerializeField] private Text currentKey;
    [SerializeField] private Image background;
    public static int CurrentKey;
    
    private void Awake()
    {
        BackgroundChanger.SetBackground(background, Path.Combine(MapHandler.Map.Path, MapHandler.Map.Background));
        Health.Lives = MapHandler.Map.Lives;
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
            if (!Input.GetKeyDown(SettingsHandler.LoadSettings().Keys[i])) continue;
            currentKey.text = SettingsHandler.LoadSettings().Keys[i].ToString();
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