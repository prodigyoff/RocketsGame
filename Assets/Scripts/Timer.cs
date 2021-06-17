using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text counterText;
    private Player _player;
    
    private float _seconds, _minutes;
    private bool _isGameOver;
    
    private void Start()
    {
        _player = (Player)FindObjectOfType(typeof(Player));
        _player.onDestroyed.AddListener(StopTimer);
        InvokeRepeating("CountTime", 0, 1);
    }
    
    private void CountTime()
    {
        if (!_isGameOver)
        {
            _minutes = (int) (Time.timeSinceLevelLoad / 60f);
            _seconds = (int) (Time.timeSinceLevelLoad % 60f);
            counterText.text = "Your time is: \n" + _minutes.ToString("00") + ":" + _seconds.ToString("00");
        }
        else
        {
            CancelInvoke("CountTime");
        }
    }
    
    private void StopTimer()
    {
        _isGameOver = true;
    }
}
