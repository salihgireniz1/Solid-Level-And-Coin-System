using System;
using UnityEngine;

[RequireComponent(typeof(ICollector))]
public class CoinManager : MonoBehaviour
{
    #region Properties
    public static CoinManager Instance { get; private set; }
    #endregion

    #region Variables
    ICollector collector;
    IHandleCoinData coinDataRespond;
    #endregion

    #region Initialize/MonoBehaviour
    private void OnEnable()
    {
        LevelManager.OnLevelClear += ResetLevelCoins;
    }
    private void OnDisable()
    {
        LevelManager.OnLevelClear -= ResetLevelCoins;
    }
    void Awake()
    {
        SetSingleton();
        collector = GetComponent<ICollector>();
        coinDataRespond = GetComponent<IHandleCoinData>();
    }
    #endregion

    #region Methods

    /// <summary>
    /// Assign singleton property as this class. 
    /// Destroy this class if a singleton already exist.
    /// </summary>
    void SetSingleton()
    {
        if (Instance == null) Instance = this;
        else Destroy(this.gameObject);
    }

    /// <summary>
    /// Initialize all the methods to collect a coin completely.
    /// </summary>
    /// <param name="coin">
    /// The coin object to collect, 
    /// the one that player collided.
    /// </param>
    public void CollectCoin(GameObject coin)
    {
        collector.Collect(coin);
    }
    
    public int GetWholeCoinScore()
    {
        return coinDataRespond.GetCurrentCoinScore();
    }
    public int GetCoinScoreOnLatestLevel()
    {
        return collector.TotalCollectedAmount;
    }
    public void ResetLevelCoins()
    {
        collector.TotalCollectedAmount = 0;
    }
    #endregion
}