using System.Collections;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    private void Update()
    {
        if (currentHealth < 100)
            HealthRegen();
    }
    private void HealthRegen()
    {
        currentHealth += Time.deltaTime / 10;
    }
    public override void Die()
    {
        base.Die();
        //player dies
        //restart scene
        PlayerManager.instance.KillPlayer();
    }
}
