using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class BackButtonBase : ButtonBase
    {
        [SerializeField] private string navigation;
        protected override void Left() => SceneManager.LoadScene(this.navigation, LoadSceneMode.Single);
    }
}