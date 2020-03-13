using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.GetComponent<HitObject>().self.KillKey != GameControl.CurrentKey) GameControl.Map.Lives -= 1;
        other.GetComponent<HitObject>().Hit();
        print("hit");
    }
    
    public static double GetZ()
    {
        return 28.67075;
        var x = Screen.width/2d - Input.mousePosition.x;
        var y = Screen.height/2d - Input.mousePosition.y;
        return Math.Atan2(x, -y) * Mathf.Rad2Deg + 180;
    }

    private void Update()
    {
        if(GameControl.GamePaused) return;
        transform.localRotation = Quaternion.Euler(0, 0, (float) (GetZ() - 180));
    }
}