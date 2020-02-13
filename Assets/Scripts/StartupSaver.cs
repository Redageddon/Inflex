using UnityEngine;

public class StartupSaver : MonoBehaviour
{
    void Update()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed, 60);
    }
}
