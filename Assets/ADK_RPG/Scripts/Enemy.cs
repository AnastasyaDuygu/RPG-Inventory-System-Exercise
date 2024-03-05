using DG.Tweening;
using UnityEngine;
[RequireComponent (typeof(CharacterStats))]
public class Enemy : Interactable
{
    PlayerManager playerManager;
    public CharacterStats myStats;

    PlayerController player;
    CharacterStats characterStats;
    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<CharacterStats>();

        player = FindObjectOfType<PlayerController>();
        characterStats = GetComponent<CharacterStats>();
        characterStats.onEnemyAttackedCallback += OnTakeDamage; //subscribe method to event
    }
    public override void Interact()
    {
        base.Interact();
        // Attack
        CharacterCombat playerCombat = playerManager.player.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }

    public void OnTakeDamage()
    {
        Debug.Log("PLAYER TAKES DAMAGE");
        var direction = transform.position.normalized - player.transform.position.normalized;
        transform.DOJump(transform.position + direction, .2f, 1, 0.25f);
        //transform.position = transform.position + direction;
    }
}
