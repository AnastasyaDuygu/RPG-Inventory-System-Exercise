using DG.Tweening;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float currentHealth { get; set; }
    public int Maxhealth = 100;

    public Stat protectiveItem;
    public Stat damage;
    private void Awake()
    {
        currentHealth = Maxhealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(damage.getValue());
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= protectiveItem.getValue();
        damage = Mathf.Clamp(damage, 0, Maxhealth);

        currentHealth -= damage;

        /*character who takes damage jumps
        var randomAngle = Random.Range(0f, 10f);
        var randomVector = Quaternion.AngleAxis(randomAngle, Vector3.up) * (0 * Vector3.forward);
        //transform.DOJump(transform.position + randomVector, .2f, 1, 0.25f).Kill();
        transform.DOJump(transform.position + randomVector, .2f, 1, 0.25f);
        */

        Debug.Log(transform.name +" takes " +  damage + " damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die() 
    {
        //override this
        Debug.Log(transform.name + " died.");
    }
}
