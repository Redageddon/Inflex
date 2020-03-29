using UnityEngine;

public class Center : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector3(SettingsHandler.LoadSettings().CenterSize, SettingsHandler.LoadSettings().CenterSize);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        GameControl.Map.Lives -= 1;
        other.GetComponent<HitObject>().Hit();
    }
}