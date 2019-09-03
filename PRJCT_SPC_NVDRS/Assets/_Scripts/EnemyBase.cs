using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private int _childrenAmount; public int ChildrenAmount { get => _childrenAmount; set => _childrenAmount = value; }

    private bool _movingRight = true;
    private float _speed = 1f;

    public void ChildDied()
    {
        _childrenAmount--;
        if (ChildrenAmount <= 0 )
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().NextWaveCaller();
        }
        print(_childrenAmount);
        _speed += 0.05f;
        if (_childrenAmount <=3)
        {
            if (_childrenAmount == 1)
            {
                _speed += 1f;
            }
            _speed += 0.7f;
        }
    }

    private void Update()
    {
        if (_movingRight)
        {
            transform.position += Vector3.right * _speed * Time.deltaTime;
            if (transform.position.x > 1.5f)
            {
                _movingRight = !_movingRight;
                transform.position += Vector3.down * 0.5f;
            }
        }
        else if (!_movingRight)
        {
            transform.position += Vector3.right * -_speed * Time.deltaTime;
            if (transform.position.x < -1.5f)
            {
                _movingRight = !_movingRight;
                transform.position += Vector3.down * 0.5f;
            }
        }
    }
}
