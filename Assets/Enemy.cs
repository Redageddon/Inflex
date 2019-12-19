using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidbody;
    private float lerpTime = 10;
    private float _currentLerpTime;
    private Vector2 _spawnLocation;
    private Vector2 _origin = new Vector2(0,0);

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        var position = _rigidbody.position;
        _spawnLocation = new Vector2(position.x, position.y);
    }

    void Update()
    {
        _currentLerpTime += Time.deltaTime;
        if (_currentLerpTime >= lerpTime)
        {
            _currentLerpTime = lerpTime;
        }
        _rigidbody.transform.position = Vector2.Lerp(_spawnLocation, _origin, _currentLerpTime / lerpTime);
        
    }
}