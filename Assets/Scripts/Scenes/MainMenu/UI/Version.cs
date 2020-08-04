using UnityEngine;
using UnityEngine.UI;

namespace Scenes.MainMenu.UI
{
    public class Version : MonoBehaviour
    {
        [SerializeField] private Text version;

        private void Start() => this.version.text = Application.version;
    }
}