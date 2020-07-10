using UnityEngine;

namespace Ui.Settings.Buttons
{
    public class KeySetterCreator : MonoBehaviour
    {
        [SerializeField] private GameObject keySetButton;

        private void Start()
        {
            for (int i = 0; i < 4; i++)
            {
                KeySetter keySetter = Instantiate(this.keySetButton, this.transform, false).GetComponent<KeySetter>();
                keySetter.keyIndex = i;
            }
        }
    }
}