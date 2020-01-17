using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private Text mapName;
    [SerializeField] private Text enemyCount;
    [SerializeField] private Text difficulty;
    [SerializeField] private Text creator;
    private bool _selected;
    public Map map;
    

    private void Start()
    {
        mapName.text = map.MetaData.Title;
        enemyCount.text = "Enemy Count: " + map.Enemies.Count;
        difficulty.text = "00"; //not implemented yet
        creator.text = map.MetaData.Creator;
    }
    public void Select()
    {
        _selected = true;
    }
    public void OnClick()
    {
        if (!_selected || Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Return))
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        else
            _selected = false;
    }    
}