using UnityEngine;

public class SpawnHandler : IHandleSpawn
{
    #region Methods
    public GameObject Spawn(GameObject spawnObject, Vector3 spawnPosition, Quaternion rotation, Transform parent = null)
    {
        GameObject newPlatform = MonoBehaviour.Instantiate(spawnObject, spawnPosition, Quaternion.identity, parent);
        return newPlatform;
    }
    #endregion
}
