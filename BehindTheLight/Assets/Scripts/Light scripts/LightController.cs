using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private LayerMask lighteableObjectsMask;
    private float distance = 5f;
    [SerializeField] private GameObject lightedObject;
    private GameObject lastLightedObject;
    [SerializeField] private bool lightsOn;
    [SerializeField] private GameObject lanternLight;

    public bool LightsOn { get => lightsOn; set => lightsOn = value; }

    private void Start()
    {
        lightsOn = false;
    }

    void Update()
    {
        if (lightsOn)
        {
            lanternLight.SetActive(true);
            DetectLighteableObjects();
        }
        else
        {
            lanternLight.SetActive(false);
            RemoveLightedObject();
        }
    }

    /// <summary>
    /// Function that detects if there is an object on the lantern light
    /// </summary>
    private void DetectLighteableObjects()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, distance, lighteableObjectsMask))
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

    void RemoveLightedObject()
    {
        if(!lightsOn && lastLightedObject != null)
        {
            lastLightedObject.GetComponent<LightedObjects>().StartFadeOut();
            lastLightedObject = null;
        }
    }
}
