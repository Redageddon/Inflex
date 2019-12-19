using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D _rigidbody;
    private float lerpTime = 10;
    private float _currentLerpTime = 0;
    private Vector2 _spawnLocation;
    private Vector2 _origin = new Vector2(0,0);

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _spawnLocation = new Vector2(_rigidbody.position.x, _rigidbody.position.y);
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