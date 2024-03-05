using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
[RequireComponent (typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Interactable currentFocus;
    PlayerMotor motor;
    
    [SerializeField] LayerMask movementMask;

    EnemyController enemy;
    CharacterStats characterStats;


    private float range = 100;
    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
        enemy = FindObjectOfType<EnemyController>();
        characterStats = GetComponent<CharacterStats>();
        characterStats.onPlayerAttackedCallback += OnTakeDamage; //subscribe method to event
    }
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return; //no clicking through ui
        if (Input.GetMouseButtonDown(0)) //left click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, movementMask))
            {
                //Move our player to what we hit
                motor.MoveToPoint(hit.point);

                //Stop focusing any objects
                RemoveFocus();
            }
        }
        if (Input.GetMouseButtonDown(1)) //right click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range))
            {
                //check if we hit interactible object
                var interactible = hit.collider.GetComponent<Interactable>();
                if (interactible != null)
                {
                    SetFocus(interactible);
                }
            }
        }
    }

    private void RemoveFocus()
    {
        currentFocus = null;
        if (currentFocus != null)
            currentFocus.OnDefocused();
        motor.StopFollowingTarget();
    }

    private void SetFocus(Interactable newFocus)
    {
        if (newFocus != currentFocus)
        {
            if (currentFocus != null)
                currentFocus.OnDefocused();
            currentFocus = newFocus;
            motor.FollowTarget(newFocus);
        }
        newFocus.OnFocused(transform);
        
    }
    public void OnTakeDamage()
    {
        Debug.Log("PLAYER TAKES DAMAGE");
        var direction = transform.position.normalized - enemy.transform.position.normalized;
        transform.DOJump(transform.position + direction, .2f, 1, 0.25f);
        //transform.position = transform.position + direction;
    }
}
