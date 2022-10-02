using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    int collectableCoinCount;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void OnEnable()
    {
        LevelManager.OnLevelLoad += GetCountToComplete;
        BasicCollector.OnCoinCollected += CheckWinCondition;
    }
    private void OnDisable()
    {
        LevelManager.OnLevelLoad -= GetCountToComplete;
        BasicCollector.OnCoinCollected -= CheckWinCondition;
    }
    private void Start()
    {
        LevelManager.Instance.LoadLevel();
    }
    public void LoadNextLevel()
    {
        LevelManager.Instance.LoadNewLevel();
    }
    public void GetCountToComplete(LevelInfo levelInfo)
    {
        collectableCoinCount = levelInfo.environment.transform.childCount;
    }
    public void CheckWinCondition(int amount)
    {
        collectableCoinCount--;
        if(collectableCoinCount == 0)
        {
            UIManager.Instance.PanelActivation(true);
        }
    }
}