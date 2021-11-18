using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] float _moveSpeed = 2f;
    [SerializeField] float _stopDistance = 0.5f;
    [SerializeField] float _waitingTime = 1.5f;
    [SerializeField] bool _isWait = true;
    [SerializeField] Transform[] _points = default;
    int _count;
    float _time;
    Vector2 _move;
    Rigidbody2D _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();

        if (_points.Length == 0)
        {
            Debug.LogError("ポイントが設定されていません");
        }
        else
        {
            _count = Random.Range(0, _points.Length);
        }
    }
    private void Update()
    {
        if(_points.Length == 0)
        {
            return;
        }

        float distance = Vector2.Distance(this.transform.position, _points[_count].position);

        if(distance > _stopDistance)
        {
            _move = (_points[_count].transform.position - this.transform.position);
            _rb.velocity = new Vector2(_move.x, 0).normalized * _moveSpeed;
        }
        else
        {
            if (_isWait)
            {
                _time += Time.deltaTime;

                if (_time >= _waitingTime)
                {
                    _count = Random.Range(0, _points.Length);
                    Debug.Log(_points[_count]);
                    _time = 0;
                }
            }
            else
            {
                _count = Random.Range(0, _points.Length);
                Debug.Log(_points[_count]);
            }
        }
    }
}
