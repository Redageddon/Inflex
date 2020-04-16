using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : ButtonBase
{
    [SerializeField] private string navigation;
    protected override void Left()
    {
        if (string.Equals(navigation , "Exit", StringComparison.OrdinalIgnoreCase)) Application.Quit();
        else SceneManager.LoadScene(navigation, LoadSceneMode.Single);
    }
}