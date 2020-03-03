using System;
using UnityEngine;

public class Center : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<Transform>().localScale = new Vector3(GlobalSettings.Settings.CenterSize, GlobalSettings.Settings.CenterSize);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        GameControl.Map.Lives -= 1;
        other.GetComponent<ComplexEnemy>().SetHitTime();
    }
}