using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int currentHealth { get; private set; }
    public int Maxhealth = 100;

    public Stat protectiveItem;

    private void Awake()
    {
        currentHealth = Maxhealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }
    public void TakeDamage(int damage)
    {
        damage -= protectiveItem.getValue();
        damage = Mathf.Clamp(damage, 0, Maxhealth);

        currentHealth -= damage;
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
