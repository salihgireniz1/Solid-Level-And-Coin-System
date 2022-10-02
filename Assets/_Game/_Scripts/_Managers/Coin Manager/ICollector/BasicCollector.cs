using UnityEngine;
using System;

[RequireComponent(typeof(IHandleCoinData))]
[RequireComponent(typeof(IDestroy))]
public class BasicCollector : MonoBehaviour, ICollector
{
    #region Event
    public static Action<int> OnCoinCollected;
    #endregion
    #region Properties
    public int TotalCollectedAmount
    {
        get => totalCollectedAmount;
        set
        {
            totalCollectedAmount = value;

            // Trigger collected event for listeners.
            OnCoinCollected?.Invoke(totalCollectedAmount);
        }
    }
    #endregion

    #region Variables
    int totalCollectedAmount;
    IHandleCoinData coinDataRespond;
    IDestroy coinDestroyRespond;
    #endregion

    private void Awake()
    {
        coinDataRespond = GetComponent<IHandleCoinData>();
        coinDestroyRespond = GetComponent<IDestroy>();
    }
    public void Collect(GameObject collectedObject)
    {
        // Handle the amount of collection.
        int amount = HandleCollectionAmount(collectedObject);

        TotalCollectedAmount += amount;

        // Handle the data of collection.
        HandleCollectionData(amount);

        coinDestroyRespond.Destruction(collectedObject);
    }

    public int HandleCollectionAmount(GameObject collectedObject)
    {
        ICollectable coinAmountRespond = collectedObject.GetComponent<ICollectable>();

        // Tell them to save new coin amount.(Give them coin amount.)
        int collectedAmount = coinAmountRespond.Amount;
        return collectedAmount;
    }

    public void HandleCollectionData(int amount)
    {
        coinDataRespond.UpdateCoinScore(amount);
    }
}
