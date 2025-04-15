using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private LayerMask lighteableObjectsMask;
    private float distance = 5f;
    [SerializeField] private GameObject lightedObject;
    private GameObject lastLightedObject;


    void Update()
    {
        DetectLighteableObjects();
    }

    /// <summary>
    /// Function that detects if there is an object on the lantern light
    /// </summary>
    private void DetectLighteableObjects()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, distance, lighteableObjectsMask))
        {
            lightedObject = hit.collider.gameObject;
            if(lightedObject != lastLightedObject)
            {
                if(lastLightedObject != null)
                {
                    lastLightedObject.GetComponent<LightedObjects>().StartFadeOut();
                }
                LightedObjects fadeObject = lightedObject.GetComponent<LightedObjects>();
                if(fadeObject != null)
                {
                    fadeObject.StartFadeIn();
                }
                lastLightedObject = lightedObject;
            }
        }
        else
        {
            if(lastLightedObject != null)
            {
                lastLightedObject.GetComponent<LightedObjects>().StartFadeOut();
                lastLightedObject = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.red);
    }
}
