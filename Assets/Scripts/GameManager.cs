using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    private Player _player;
    private void Start()
    {
        gameOverScreen.SetActive(false);
        _player = (Player)FindObjectOfType(typeof(Player));
        _player.onDestroyed.AddListener(GameOver);
    }

    private void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
