using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class Enemy : MonoBehaviour
{
    private int _HP = 1;
    private bool _canShoot = true;

    public event Action<int> OnEnemyDeath;
    public event Action OnReachGround;

    public GameObject _EnemyBullet;

    void Start()
    {
        OnEnemyDeath += FindObjectOfType<ScoreManager>().AddScore;
        FindObjectOfType<Player>().OnPlayerDeath += StopShoot;
        FindObjectOfType<GameManager>().OnGameOver += StopShoot;
        OnReachGround += FindObjectOfType<GameManager>().GameOver;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bullet(Clone)")
        {
            Destroy(other.gameObject);

            _HP--;
            if (_HP <=0)
            {
                StartDeath();
                GetComponentInParent<EnemyBase>().ChildDied();
            }
        }

        if (other.gameObject.name == "Ground")
        {
            OnReachGround?.Invoke();
            //GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameOver();
            UnSubscribe();
        }
    }

    /*void Update()
    {
        if (_canShoot)
        {
            StartCoroutine(Shoot(UnityEngine.Random.Range(2f, 8f)));
        }
    }*/

    public void StopShoot()
    {
        _canShoot = false;
    }

    public void Shoot()
    {
        if (_canShoot)
        {
            GameObject currentBullet = Instantiate(_EnemyBullet, transform);
            currentBullet.transform.parent = null;
        }
    }

    void UnSubscribe()
    {
        OnEnemyDeath -= FindObjectOfType<ScoreManager>().AddScore;
        FindObjectOfType<Player>().OnPlayerDeath -= StopShoot;
        OnReachGround -= FindObjectOfType<GameManager>().GameOver;
    }

    void StartDeath()
    {
        gameObject.GetComponent<DramaticDeath>().StartDeath();
        //CameraShaker.Instance.ShakeOnce(1, 1, 1, 1);
        OnEnemyDeath?.Invoke(10);

        UnSubscribe();
    }
}
