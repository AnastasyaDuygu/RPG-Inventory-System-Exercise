using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Vector3 offset; //camera offset

    
    private float zoomSpeed = 4f;
    private float minZoom = 5f;
    private float currentZoom = 10f;
    private float maxZoom = 15f;

    private float currentRotation = 0f;
    private float rotationSpeed = 80f;

    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

        currentRotation -= Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;

        transform.LookAt(target.position + Vector3.up * 2); //this is needed for rotation
        transform.RotateAround(target.position, Vector3.up, currentRotation);
    }
}
