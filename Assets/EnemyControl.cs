using UnityEngine;
using UnityEngine.UI;

public class EnemyControl : MonoBehaviour
{
    private float _speed = 1;
    public int CurrentEnemy { private get; set; }
    [SerializeField] private Text key;

    private void Start()
    {
        key.text = MapButton.Map.Enemies[CurrentEnemy].KillKey;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(0, 0), Time.deltaTime * _speed);
    }
}