using UnityEngine;
using UnityEngine.UI;

public class GameUi : MonoBehaviour
{
    [SerializeField] private Text lives;

    private void Awake()
    {
        Health.Lives = AssetLoader.Instance.Level.Lives;
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