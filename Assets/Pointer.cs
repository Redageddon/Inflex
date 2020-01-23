using System;
using System.Collections;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        print("aaaa");
    }

    private void Start()
    {
        IEnumerator coroutine = Loop();
        StartCoroutine(coroutine);
    }

    private double SetZRotation()
    {
        var x = Screen.width/2 - Input.mousePosition.x;
        var y = Screen.height/2 - Input.mousePosition.y;
        return 180 * Math.Atan2(y, x) / Math.PI + 90;
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(0);
            transform.localRotation = Quaternion.Euler(0, 0, (float) SetZRotation());
        }
    }
}