using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class NavigationButton : MouseNavigationControl
    {
        [SerializeField] private string navigation;
        
        protected override void LeftClick() => SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);
    }
}