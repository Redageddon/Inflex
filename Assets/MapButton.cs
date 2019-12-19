using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text text;
    internal string ButtonInstancePath = "";
    
    public void SetText(string textString)
    {
        text.text = textString;
    }

    public void OnClick()
    {
        MapCreator.LoadPath(ButtonInstancePath);
    }    
}