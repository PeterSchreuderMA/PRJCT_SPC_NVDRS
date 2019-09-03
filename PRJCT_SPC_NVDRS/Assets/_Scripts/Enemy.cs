using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _HP = 1;
    private bool _canShoot = true;

    public event Action<int> OnEnemyDeath;

    public GameObject _EnemyBullet;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bullet(Clone)")
        {
            Destroy(other.gameObject);

            _HP--;
            if (_HP <=0)
            {
                Destroy(gameObject);
                GetComponentInParent<EnemyBase>().ChildDied();
            }
        }
    }

    void Update()
    {
        if (_canShoot)
        {
            StartCoroutine(Shoot(UnityEngine.Random.Range(2f, 8f)));
        }
    }

    IEnumerator Shoot(float timer)
    {
        _canShoot = false;
        yield return new WaitForSeconds(timer);
        GameObject currentBullet = Instantiate(_EnemyBullet, transform);
        currentBullet.transform.parent = null;
        _canShoot = true;
    }

    void StartDeath()
    {
        OnEnemyDeath?.Invoke(10);
    }
}
