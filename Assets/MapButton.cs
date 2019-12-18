using UnityEngine;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text text;
    public string buttonInstancePath = "";
    
    public void SetText(string textString)
    {
        text.text = textString;
    }

    public void OnClick()
    {
        print(buttonInstancePath);
    }    
}
