using TMPro;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("Camera Rotation")]
    [SerializeField] private Transform playerPos;
    [SerializeField] private float yOffset;
    [SerializeField] private float sensitivity;
    [SerializeField] private float minY;
    [SerializeField] private float maxY;

    [Header("Interaction Detect")]
    [SerializeField] private LayerMask interactLayer;
    private float interactDistance = 3f;
    [SerializeField] private TMP_Text interactText;



    private float xRotation;
    private float yRotation;

    private void Start()
    {
        playerPos = GameObject.FindObjectOfType<PlayerMovement>().GetComponent<Transform>();
    }

    private void Update()
    {
        if (!GameManager.instance.IsPaused)
        {
            CameraRotation();
            InteractionDetect();
        }
    }


    private void LateUpdate()
    {
        transform.position = new Vector3(playerPos.position.x, playerPos.position.y +yOffset, playerPos.position.z);
    }

    /// <summary>
    /// Rotate the camera with the mouse input
    /// </summary>
    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, minY, maxY);
        yRotation += mouseX;
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void InteractionDetect()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); 
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            IInteractable interactObj = hit.collider.GetComponent<IInteractable>();
            if (interactObj != null)
            {
                interactText.text = interactObj.OnInteractMsg;
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactObj.OnInteract();
                }
            }
        }
        else
        {
            interactText.text = "";
        }
    }
}
