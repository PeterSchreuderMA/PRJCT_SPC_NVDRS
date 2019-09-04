using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    [SerializeField]
    string objectTag = "";

    [SerializeField]
    float  destroyTime = 0;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == tag)
        {
            Destroy(gameObject, destroyTime);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == tag)
        {
            Destroy(gameObject, destroyTime);
        }
    }
}
