using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print(other);
    }

    private double GetZ()
    {
        var x = Screen.width/2d - Input.mousePosition.x;
        var y = Screen.height/2d - Input.mousePosition.y;
        return 180 * Math.Atan2(y, x) / Math.PI + 90;
    }

    private void Update()
    {
        if(GameControl.GamePaused) return;
        transform.localRotation = Quaternion.Euler(0, 0, (float) GetZ());
        foreach (KeyCode kcode in Settings.Keys)
        {
            if (Input.GetKeyDown(kcode))
            {print("yes");
            }
        }
    }
}