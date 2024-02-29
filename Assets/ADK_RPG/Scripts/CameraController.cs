using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Vector3 offset = new Vector3(0, 7, -7); //camera offset

    private void Update()
    {
        transform.position = target.position + offset;
    }
}
