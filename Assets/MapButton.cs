using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text text;
    
    public void SetText(string textString)
    {
        text.text = textString;
    }

    public void OnClick()
    {
    }    
}
