using UnityEngine;
using DG.Tweening;
using System.Collections;

public class HealthBar : MonoBehaviour
{
    private float currentHealth = 100;
    private float prevHealth;
    [SerializeField] CharacterStats playerStats;
    [SerializeField] CharacterCombat playerCombat;
    [SerializeField] RectTransform healthBar;
    private void Update()
    {
        currentHealth = playerStats.currentHealth / 100f;
        if (prevHealth == currentHealth) return;
        prevHealth = currentHealth;
        healthBar.DOAnchorMax(new Vector2(currentHealth, 1), duration: .5f);
    }
}
