using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui.Scenes.MainMenu
{
    public class MainMenuButton : ButtonBase
    {
        [SerializeField] private string navigation;

        protected override void Left()
        {
            if (string.Equals(this.navigation, "Exit", StringComparison.OrdinalIgnoreCase))
            {
                Application.Quit();
            }
            else
            {
                SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);
            }
        }
    }
}