
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
}
