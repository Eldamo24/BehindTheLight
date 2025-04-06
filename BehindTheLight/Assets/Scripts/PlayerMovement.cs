using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    [SerializeField]
    private float movSpeed = 5f;

    private Vector3 direction;

    Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        direction = new Vector3(x,0,z);

        animator.SetFloat("xMov", x);
        animator.SetFloat("zMov", z);
    }

    private void FixedUpdate()
    {
        if(direction.sqrMagnitude != 0)
        {
            Movement(direction);
        }

    }

    /// <summary>
    /// Function that manages simple player character movement
    /// </summary>
    /// <param name="dir">Takes direction</param>
    private void Movement(Vector3 dir)
    {
        rb.MovePosition(transform.position + movSpeed * Time.fixedDeltaTime * dir);
    }
}
