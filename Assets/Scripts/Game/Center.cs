using UnityEngine;

public class Center : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
    }
}