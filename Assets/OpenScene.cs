using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenScene : MonoBehaviour
{
    public string scene;
    private bool _selected;
    public void Select()
    {
        _selected = true;
    }
    public void OnClicked()
    {
        if (!_selected || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return) || Input.GetKey(KeyCode.Mouse0))
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        else
            _selected = false;
    }  
}
