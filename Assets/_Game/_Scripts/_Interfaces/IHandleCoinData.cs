public interface IHandleCoinData
{
    public int CoinScore { get; set; }
    
    /// <summary>
    /// Saves the whole coin amount to PlayerPrefs.
    /// </summary>
    void SaveCoinScore();

    /// <summary>
    /// Gives the amount we collected.
    /// </summary>
    /// <returns>All the coin amount collected and saved.</returns>
    int GetCurrentCoinScore();

    /// <summary>
    /// Updates currently collected coin amount and 
    /// initializes the saving processes to PlayerPrefs.
    /// </summary>
    /// <param name="amount">Amount of the latest coin that collected.</param>
    void UpdateCoinScore(int amount);
}
