using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private BoxCollider2D _bc2D;

    private float _speed;

    // Start is called before the first frame update
    void Start()
    {
        _speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }
}
