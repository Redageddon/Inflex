using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidBody;
    private float _lerpTime = 10;
    private float _currentLerpTime;
    private Vector2 _spawnLocation;
    private Vector2 _origin = new Vector2(0,0);

    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        var position = _rigidBody.position;
        _spawnLocation = new Vector2(position.x, position.y);
    }

    void Update()
    {
        _currentLerpTime += Time.deltaTime;
        if (_currentLerpTime >= _lerpTime)
        {
            _currentLerpTime = _lerpTime;
        }
        _rigidBody.transform.position = Vector2.Lerp(_spawnLocation, _origin, _currentLerpTime / _lerpTime);
        
    }
}