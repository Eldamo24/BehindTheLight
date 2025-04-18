using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour
{
    public float Speed;
    public float Angle;
    public Vector3 Direction;

    public bool CanOpen;
    public bool Open;

    private AudioSource audioSource;
    void Start()
    {
        Angle = transform.eulerAngles.y;
        audioSource = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Round(transform.eulerAngles.y) != Angle)
        {
            transform.Rotate(Direction * Speed * Time.deltaTime);
        }
        if(Input.GetButtonDown("Fire1") && CanOpen == true && Open == false)
        {
            audioSource.Play();
            Angle = 80;
            Direction = Vector3.up;
            Open = true;
            
        }
        else if (Input.GetButtonDown("Fire1") && CanOpen == true && Open == true)
        {
            Angle = 0;
            Direction = Vector3.down;
            Open = false;
        }

    }
    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            CanOpen = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            CanOpen = false;
        }
    }
}
