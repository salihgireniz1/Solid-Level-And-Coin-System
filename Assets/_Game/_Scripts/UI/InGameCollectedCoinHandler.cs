using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameCollectedCoinHandler : MonoBehaviour
{
    TextMeshProUGUI textMesh;

    private void OnEnable()
    {
        BasicCollector.OnCoinCollected += UpdateText;
    }
    private void Awake()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }
    public void UpdateText(int levelCoinAmount)
    {
        textMesh.text = levelCoinAmount.ToString();
    }
}
