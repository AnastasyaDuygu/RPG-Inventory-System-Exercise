
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : CharacterStats
{
    public override void Die()
    {
        base.Die();
        //player dies
        //restart scene
        PlayerManager.instance.KillPlayer();
    }

    private void Update()
    {
        if (currentHealth < 100)
            StartCoroutine(HealthRegen());
    }
    public IEnumerator HealthRegen() //TODO: Fix this
    {
        yield return new WaitForSeconds(5);
        currentHealth += 5;
        if (currentHealth >= 100) yield break;
        HealthRegen();
    }
}
