using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChaosDisplayer : MonoBehaviour
{
    [SerializeField] GameObject viewport;
    [SerializeField] TMP_Text content;

    public void UpdateChaosInfo(int currentChaosLevel)
    {
        content.text = "Текущий уровень хаоса: " + currentChaosLevel.ToString();
    }
}
