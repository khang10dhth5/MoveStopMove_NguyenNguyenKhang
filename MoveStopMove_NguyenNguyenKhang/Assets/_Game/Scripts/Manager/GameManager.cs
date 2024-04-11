using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    public GameState gameState;
    private int coin;

    public int Coin { get => coin; set => coin = value; }

    private void Start()
    {
        gameState = GameState.Begin;
        Coin = 1000;
    }

    internal void EndGame(bool isWin)
    {
        if(isWin)
        {
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<CanvasWin>();
        }
        else
        {
            UIManager.Instance.OpenUI<CanvasLose>();
        }
        gameState = GameState.EndGame;
        
    }
}
