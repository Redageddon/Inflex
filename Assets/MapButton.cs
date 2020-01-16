using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text text;
    internal string ButtonInstancePath = "";
    internal Map map;
    
    public void SetText(string textString)
    {
        text.text = textString;
    }

    public void SetMap()
    {
    }

    public void OnClick()
    {
        LoadMap.LoadPath(ButtonInstancePath);
    }    
}