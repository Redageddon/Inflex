using System;
using UnityEngine;
using static UnityEngine.Mathf;

public class Pointer : MonoBehaviour
{
    private Vector2 XY;

    float MakeRotation()
    {
        XY.x = Input.mousePosition.x - Screen.width / 2;
        XY.y = Input.mousePosition.y - Screen.height / 2;
        float rotation = (Atan2(XY.y, XY.x) * Rad2Deg) - 90;
        if (rotation >= 0)
        {
            return rotation;
        }
        else
        {
            return rotation + 360;
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        print("aaaa");
    }
    


    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, 0, MakeRotation());
    }
}