using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    private float speed;
    [SerializeField] private float finalAngle;
    [SerializeField] private float startAngle;
    private float angle;
    private Vector3 direction;
    private Transform doorPivot;
    private AudioSource audioSource;

    private bool canBeOpen;
    private bool isOpen;

    private string onInteractMsg;

    public string OnInteractMsg => onInteractMsg;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        doorPivot = transform.parent;
        speed = 100f;
        isOpen = false;
        canBeOpen = false;
        if (!canBeOpen)
        {
            onInteractMsg = "Door Locked";
        }
        else
        {
            if (!isOpen)
            {
                onInteractMsg = "Open Door";
            }
            else
            {
                onInteractMsg = "Close Door";
            }
        }
        angle = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(doorPivot.eulerAngles.y) != angle)
        {
            doorPivot.Rotate(direction * speed * Time.deltaTime);
        }
    }

    public void OnInteract()
    {
        if(canBeOpen)
        {
            if (isOpen == false)
            {
                angle = finalAngle;
                direction = Vector3.up;
                isOpen = true;
                onInteractMsg = "Close door";
                audioSource.Play();
            }
            else if (isOpen == true)
            {
                angle = startAngle;
                direction = Vector3.down;
                isOpen = false;
                onInteractMsg = "Open door";
                audioSource.Play();
            }
        }
    }

    public void UnlockDoor()
    {
        canBeOpen = true;
        onInteractMsg = "Open Door";
    }
}
