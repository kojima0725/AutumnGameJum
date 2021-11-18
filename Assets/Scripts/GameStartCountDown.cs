using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameStartCountDown : MonoBehaviour
{
    [SerializeField] Text _countDownText;
    [SerializeField] private float _countDownTimer = 5;
    [SerializeField] UnityEvent _event;
    private bool _isStart = false;
    private void OnEnable()
    {
        _isStart = false;
    }
    private void FixedUpdate()
    {
        if (_isStart) return;

        _countDownTimer -= Time.deltaTime;
        _countDownText.text = _countDownTimer.ToString("F0");

        if(_countDownTimer <= 0)
        {
            _isStart = true;
            _event.Invoke();
        }
    }
}
