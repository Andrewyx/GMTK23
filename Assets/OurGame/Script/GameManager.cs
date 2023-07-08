using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateGameState(GameState.Playing);
    }

    public void UpdateGameState(GameState gs)
    {
        switch (gs)
        {
            case GameState.Playing:
                break;
            case GameState.GameOver:
                HandleGameOver();
                break;
            case GameState.Win:
                SceneManager.LoadScene("PlayScene2");
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(gs), gs, null);
        }

    }

    public void Update()
    {
        if (PlayerData.instance.lives <= 0)
        {
            UpdateGameState(GameState.GameOver);
        }

        if (PlayerData.instance.currentPoints >= 5 /* TODO: Change Later*/)
        {
            UpdateGameState(GameState.Win);
        }
    }

    public void HandleGameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerData.instance.Reset();
    }
}

public enum GameState
{
    Playing,
    GameOver,
    Win
}