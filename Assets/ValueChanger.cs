using UnityEngine;
using UnityEngine.UI;

public class ValueChanger : MonoBehaviour
{
    [SerializeField] private Scrollbar scrollbar;

    private void Update()
    {
        scrollbar.value = Mathf.Clamp(scrollbar.value += Input.GetAxis("Mouse ScrollWheel"), 0, 1);
    }
}