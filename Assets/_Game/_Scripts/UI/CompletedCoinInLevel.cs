using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CompletedCoinInLevel : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    private void OnEnable()
    {
        textMesh.text = CoinManager.Instance.GetCoinScoreOnLatestLevel().ToString();
    }
}
