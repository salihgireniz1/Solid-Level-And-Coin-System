using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHandleSpawn
{
    /// <summary>
    /// Spawn an object.
    /// </summary>
    /// <param name="spawnObject">Object prefab to spawn.</param>
    /// <returns>Spawned object as type of GameObject.</returns>
    GameObject Spawn(GameObject spawnObject, Vector3 spawnPosition, Quaternion rotation, Transform parent = null);
}
