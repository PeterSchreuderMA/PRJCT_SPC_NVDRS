using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectDestroyInTime : MonoBehaviour
{
    public void DestroyObject(float _time)
    {
        Destroy(gameObject, _time);
    }
}
