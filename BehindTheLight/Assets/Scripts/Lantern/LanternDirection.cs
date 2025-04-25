using UnityEngine;

public class LanternDirection : MonoBehaviour
{
    private Camera cam;
    private float rotationSpeed = 5f;


    private void Start()
    {
        cam = GetComponentInParent<Camera>();
    }
    private void Update()
    {
        Vector3 lanternDirection = cam.transform.forward;
        Quaternion desiredRotation = Quaternion.LookRotation(lanternDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotation, rotationSpeed * Time.deltaTime);
    }
}
