using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(IDestroy))]
public class GenerateLevelEnvironment : MonoBehaviour
{
    IHandleSpawn spawnHandler;
    IDestroy destructionHandler;

    #region Spawned Objects

    [Header("Spawned Objects"), Space]
    [SerializeField]
    GameObject spawnedPlayer;

    [SerializeField] 
    GameObject spawnedPlatform;

    [SerializeField] 
    GameObject spawnedCoinSet;
    #endregion

    #region Spawn Positions

    [Header("Spawn Positions"), Space]
    [SerializeField]
    Vector3 playerPosition;

    [SerializeField]
    Vector3 coinSetPosition;

    [SerializeField]
    Vector3 platformPosition;
    #endregion

    #region Environment Holder

    [Header("Environment Parent Object"), Space]
    [SerializeField]
    Transform environmentHolder;
    #endregion

    Quaternion defaultRotation = Quaternion.identity;
    private void OnEnable()
    {
        LevelManager.OnLevelLoad += GenerateEnvironment;
        LevelManager.OnLevelClear += ClearSpawnedLevelAssets;
    }
    private void OnDisable()
    {
        LevelManager.OnLevelLoad -= GenerateEnvironment;
        LevelManager.OnLevelClear -= ClearSpawnedLevelAssets;
    }
    private void Awake()
    {
        spawnHandler = new SpawnHandler(); 
        destructionHandler = GetComponent<IDestroy>();
    }
    public void GenerateEnvironment(LevelInfo levelInfo)
    {
        spawnedPlatform = spawnHandler.Spawn(levelInfo.platform, platformPosition, defaultRotation, environmentHolder);
        spawnedPlayer = spawnHandler.Spawn(levelInfo.player, playerPosition, defaultRotation, environmentHolder);
        spawnedCoinSet = spawnHandler.Spawn(levelInfo.environment, coinSetPosition, defaultRotation, environmentHolder);
    }
    public void ClearSpawnedLevelAssets()
    {
        destructionHandler.Destruction(spawnedPlatform);
        destructionHandler.Destruction(spawnedPlayer);
        destructionHandler.Destruction(spawnedCoinSet);
    }
}
