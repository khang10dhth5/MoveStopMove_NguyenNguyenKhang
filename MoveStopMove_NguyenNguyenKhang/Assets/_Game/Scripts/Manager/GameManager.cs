using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMono<GameManager>
{
    public GameState gameState;
    private int coin=0;
    
    public int Coin { get => coin; set => coin = value; }
    private void Awake()
    {
        gameState = GameState.Begin;
        if (!PlayerPrefs.HasKey(KeyConstant.COIN))
        {
            PlayerPrefs.SetInt(KeyConstant.COIN, coin);
        }
        else
        {
            coin = PlayerPrefs.GetInt(KeyConstant.COIN);
        }
        
    }


    internal void GetReward(int reward)
    {
        Coin += reward;
        PlayerPrefs.SetInt(KeyConstant.COIN, Coin);
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
