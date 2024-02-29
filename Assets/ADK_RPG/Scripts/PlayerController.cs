using System;
using UnityEngine;
[RequireComponent (typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Camera cam;
    public Interactable currentFocus;
    PlayerMotor motor;
    
    [SerializeField] LayerMask movementMask;

    private float range = 100;
    private void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //left click
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, movementMask))
            {
                motor.MoveToPoint(hit.point);
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //Move our player to what we hit

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
        motor.StopFollowingTarget();
    }

    private void SetFocus(Interactable newFocus)
    {
        currentFocus = newFocus;
        motor.FollowTarget(newFocus);
    }
}
