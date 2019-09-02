﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // input stuff
    private InputManager _input;
    private float _horizontal;
    private bool _fire;

    // player stuff
    private float _speed;

    // Fire
    public GameObject _bullet;
    private bool _canShoot = true;

    private void Start()
    {
        _input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();

        _speed = 5;
    }

    private void Update()
    {
        _horizontal = _input.GetHorizontal();
        _fire = _input.GetFire();
        if (_horizontal != 0)
        {
            Move();
        }
        if (_fire)
        {
            Fire();
        }
    }

    private void Move()
    {
        transform.position += new Vector3(_speed * _horizontal, 0, 0) * Time.deltaTime;
    }

    private void Fire()
    {
        if (_canShoot)
        {
            StartCoroutine(Shoot());
        }
    }

    private IEnumerator Shoot()
    {
        _canShoot = false;
        GameObject currentBullet = Instantiate(_bullet, transform);
        currentBullet.transform.parent = null;
        yield return new WaitForSeconds(0.3f);
        _canShoot = true;
    }

}