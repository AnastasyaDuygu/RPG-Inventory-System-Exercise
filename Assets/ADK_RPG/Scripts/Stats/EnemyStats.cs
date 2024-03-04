
public class EnemyStats : CharacterStats
{
    public override void Die()
    {
        base.Die();

        //death animation

        Destroy(gameObject);
    }
}
