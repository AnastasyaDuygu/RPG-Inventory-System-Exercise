using UnityEngine;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    private float currentHeath = 100;
    private float prevHealth;
    [SerializeField] CharacterStats playerStats;
    [SerializeField] CharacterCombat playerCombat;
    [SerializeField] RectTransform healthBar;
    private void Update()
    {
        currentHeath = playerStats.currentHealth / 100f;
        if (currentHeath == 1 || prevHealth == currentHeath) return; // to make it less taxing
        prevHealth = currentHeath;
        healthBar.DOAnchorMax(new Vector2(currentHeath, 1), duration: .5f);
    }
}
