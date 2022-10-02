using System;
using UnityEngine;

public class HandleCoinData : MonoBehaviour, IHandleCoinData
{
    #region Constant
    const string COIN_SCORE = "CoinScore";
    #endregion

    #region Properties
    public int CoinScore
    {
        get => coinScore;
        set => coinScore = value;
    }
    #endregion

    #region Variables
    [SerializeField]
    private int coinScore;
    #endregion

    #region Methods
    public void SaveCoinScore()
    {
        ES3.Save(COIN_SCORE, CoinScore);
    }
    public int GetCurrentCoinScore()
    {
        return ES3.Load(COIN_SCORE, 0);
    }
    public void UpdateCoinScore(int amount)
    {
        CoinScore = GetCurrentCoinScore() + amount;
        SaveCoinScore();
        Debug.Log("Coin Score Updated!");
    }
    #endregion
}