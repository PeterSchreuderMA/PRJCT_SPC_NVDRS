using System;
using System.Collections;
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
    private DramaticDeath _dramaticDeath;
    public event Action OnPlayerDeath;

    // Fire
    public GameObject _bullet;
    private bool _canShoot = true;

    // Sound
    private SoundEmitterInit _soundEmitter;

    private void Start()
    {
        _input = GameObject.FindGameObjectWithTag("InputManager").GetComponent<InputManager>();
        _soundEmitter = gameObject.GetComponent<SoundEmitterInit>();
        _dramaticDeath = gameObject.GetComponent<DramaticDeath>();

        OnPlayerDeath += GameObject.FindObjectOfType<GameManager>().PlayerDied;

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
        _soundEmitter.PlaySound();
        _canShoot = false;
        GameObject currentBullet = Instantiate(_bullet, transform);
        currentBullet.transform.parent = null;
        currentBullet.transform.position += Vector3.up * .5f;
        yield return new WaitForSeconds(0.3f);
        _canShoot = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.name == "EnemyBullet(Clone)")
        {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().PlayerDied();
            StartCoroutine(DeathAnim());
        }
    }

    IEnumerator DeathAnim()
    {
        _dramaticDeath.StartDeath();
        OnPlayerDeath?.Invoke();
        yield return new WaitForSeconds(0.01f);
        
    }
}
