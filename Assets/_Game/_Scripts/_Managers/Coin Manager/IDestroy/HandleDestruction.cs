using System;
using System.Collections.Generic;
using UnityEngine;

public class HandleDestruction : MonoBehaviour, IDestroy
{
    /// <summary>
    /// Destroys the a dedicated object.
    /// </summary>
    public void Destruction(GameObject go)
    {
        Destroy(go);
    }
}
