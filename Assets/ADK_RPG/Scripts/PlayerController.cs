using UnityEngine;
[RequireComponent (typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
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
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, range, movementMask))
            {
                motor.MoveToPoint(hit.point);
                Debug.Log("We hit " + hit.collider.name + " " + hit.point);
                //Move our player to what we hit

                //Stop focusing any objects
            }
        }
    }
}
