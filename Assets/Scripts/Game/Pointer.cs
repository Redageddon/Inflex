using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<HitObject>().self.KillKey != GameControl.CurrentKey) GameControl.Map.Lives -= 1;
        other.GetComponent<HitObject>().Hit();
        other.gameObject.SetActive(false);
    }
    
    private static double GetZ()
    {
        var x = Screen.width/2d - Input.mousePosition.x;
        var y = Screen.height/2d - Input.mousePosition.y;
        return 180 * Math.Atan2(y, x) / Math.PI + 90;
    }

    private void Update()
    {
        if(GameControl.GamePaused) return;
        transform.localRotation = Quaternion.Euler(0, 0, (float) GetZ());
    }
}