using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    private int _childrenAmount; public int ChildrenAmount { get => _childrenAmount; set => _childrenAmount = value; }

    [Range(0, 3)]
    public float _speedMulti = 1;

    private bool _movingRight = true;
    private float _speedStart = 0.2f, _speed = 0.2f;
    private bool _canMove = true;

    void Start()
    {
        FindObjectOfType<GameManager>().OnGameOver += StopMove;
    }

    public void StopMove()
    {
        _canMove = false;
    }

    public void ChildDied()
    {
        _childrenAmount--;
        if (ChildrenAmount <= 0 )
        {
            Destroy(this.gameObject);
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().NextWaveCaller();
        }
        //print(_childrenAmount);
        _speed += 0.028f;

        if (_childrenAmount <= 3)
        {
            if (_childrenAmount == 1)
            {
                _speed += _speedStart * 2;
            }
            _speed += _speedStart;
        }
    }

    private void Update()
    {
        if (!_canMove)
            return;

        _speed = _speed * _speedMulti;

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
            transform.position -= Vector3.right * _speed * Time.deltaTime;
            if (transform.position.x < -1.5f)
            {
                _movingRight = !_movingRight;
                transform.position += Vector3.down * 0.5f;
            }
        }
    }
}
