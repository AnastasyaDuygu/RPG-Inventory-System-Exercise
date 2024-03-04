using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterStats), typeof(Rigidbody))]
public class CharacterCombat : MonoBehaviour
{
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;

    Rigidbody rb;
    CharacterStats myStats;
    private float attackDelay = .6f;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            StartCoroutine(DoDamage(targetStats, attackDelay));

            attackCooldown = 1f / attackSpeed;
        }
        
    }
    IEnumerator DoDamage(CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);
        //rb.addforce to make the target jump back when attacked
        stats.TakeDamage(myStats.damage.getValue());

    }
}
