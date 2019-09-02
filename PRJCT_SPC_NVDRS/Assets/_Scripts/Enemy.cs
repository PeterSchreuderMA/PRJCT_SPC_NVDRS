using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _HP = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Bullet(Clone)")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GetComponentInParent<EnemyBase>().ChildDied();
        }
    }
}
