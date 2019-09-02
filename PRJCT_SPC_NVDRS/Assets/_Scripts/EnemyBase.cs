using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private int _childrenAmount; public int ChildrenAmount { get => _childrenAmount; set => _childrenAmount = value; }

    public void ChildDied()
    {
        _childrenAmount--;
        if (ChildrenAmount <= 0 )
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().NextWaveCaller();
        }
        print(_childrenAmount);
    }

    public void StartMoving()
    {
        print("Move");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
