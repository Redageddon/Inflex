using System;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("aaaa");
    }

    private void Start()
    {
        InvokeRepeating(nameof(SetZRotation), 0, 0.00002f);
    }

    private double GetZ()
    {
        var x = Screen.width/2 - Input.mousePosition.x;
        var y = Screen.height/2 - Input.mousePosition.y;
        return 180 * Math.Atan2(y, x) / Math.PI + 90;
    }

    private void SetZRotation()
    {
        if(GameControl.GamePaused) return;
        transform.localRotation = Quaternion.Euler(0, 0, (float) GetZ());
    }
}