using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Image healthImage;
    [SerializeField] Sprite[] health;

    private void Start()
    {
        healthImage = GetComponent<Image>();
    }

    public void UpdateHealth(int currentHealth)
    {
        healthImage.sprite = health[currentHealth];
    }
}
