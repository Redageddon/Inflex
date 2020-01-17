using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapButton : MonoBehaviour
{
    [SerializeField] private RawImage background;
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
        
        var asd = File.ReadAllBytes(@"C:\Users\527251\AppData\Roaming\CircleRhythm\Maps\Map2\bg1.png");
        Texture2D zxc = new Texture2D(100,100);
        zxc.LoadRawTextureData(asd);
        zxc.Apply();
        background.GetComponent<RawImage>().texture = zxc;
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