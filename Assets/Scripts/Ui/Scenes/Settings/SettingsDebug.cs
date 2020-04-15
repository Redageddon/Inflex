using UnityEngine;
using UnityEngine.UI;

public class SettingsDebug : MonoBehaviour
{
    [SerializeField] private Text debugTest;

    private void Update()
    {
        debugTest.text = Screen.currentResolution.ToString();
    }
}