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
        BackgroundChanger.SetBackground(background, Path.Combine(GameControl.Map.Path, GameControl.Map.Background));
    }

    private void Update()
    {
        UpdateUi();
    }
    
    private void UpdateUi()
    {
        for (var i = 0; i < 4; i++)
        {
            if (!Input.GetKeyDown(SettingsHandler.LoadSettings().Keys[i])) continue;
            currentKey.text = SettingsHandler.LoadSettings().Keys[i].ToString();
            CurrentKey = i;
        }
        
        lives.text = " Lives: " + GameControl.Map.Lives;
    }
    
    
}