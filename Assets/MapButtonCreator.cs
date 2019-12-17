using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapButtonCreator : MonoBehaviour
{
    [SerializeField] private GameObject MapButton;
    private List<int> intList;
    void Start()
    {
        foreach (var map in PathData.MapNames)
        {
            GameObject button = Instantiate(MapButton);
        }
    }

    
    void Update()
    {
        
    }
}
