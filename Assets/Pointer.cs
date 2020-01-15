using UnityEngine;

public class Pointer : MonoBehaviour
{
    private Vector2 _xy;

    float MakeRotation()
    {
        
        _xy.x = Input.mousePosition.x - Screen.width / 2;
        _xy.y = Input.mousePosition.y - Screen.height / 2;
        float rotation = (Mathf.Atan2(_xy.y, _xy.x) * Mathf.Rad2Deg) - 90;
        if (rotation >= 0) return rotation;
        return rotation + 360;
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