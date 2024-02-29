using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Vector3 offset; //camera offset
    private float currentZoom = 10f;
    private float zoomSpeed = 4f;
    private void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, 5f, 15f);
    }
    private void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
    }
}
