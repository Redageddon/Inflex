using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text text;
    private Map _map;
    
    public void SetText(string textString)
    {
        text.text = textString;
    }

    public void SetMap(Map map)
    {
        _map = map;
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }    
}