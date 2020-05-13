using UnityEngine;
using UnityEngine.UI;

namespace Ui.Scenes.MainMenu
{
    public class Version : MonoBehaviour
    {
        [SerializeField] private Text version;

        private void Start() => this.version.text = Application.version;
    }
}