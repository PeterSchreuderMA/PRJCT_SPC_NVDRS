using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float _speed;

    void Update()
    {
        transform.position += Vector3.up * _speed * Time.deltaTime;
    }
}
