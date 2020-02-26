using System;
using UnityEngine;
using UnityEngine.UI;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Text key;

    private void OnTriggerStay2D(Collider2D other)
    {
        if (key.text != other.GetComponent<ComplexEnemy>().text.text) GameControl.Map.Lives -= 1;
        other.GetComponent<ComplexEnemy>().SetHitTime();
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