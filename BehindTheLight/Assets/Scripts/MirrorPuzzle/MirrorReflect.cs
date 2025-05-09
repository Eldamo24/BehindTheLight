using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.ProBuilder;

public class MirrorReflect : MonoBehaviour
{
    [SerializeField] private GameObject mirrorLight;
    private float lightOffset = 0.05f;

    public void ReflectLight(Vector3 incomingDir, Vector3 hitPoint, int bounceRemain)
    {
        if (bounceRemain <= 0) return;
        Vector3 normalMirror = transform.forward;
        Vector3 reflectDirection = Vector3.Reflect(incomingDir, normalMirror);
        if(mirrorLight != null)
        {
            mirrorLight.SetActive(true);
            mirrorLight.transform.position = hitPoint + normalMirror * lightOffset;
            mirrorLight.transform.rotation = Quaternion.LookRotation(reflectDirection);
        }
        if (Physics.Raycast(hitPoint + normalMirror * 0.01f, reflectDirection, out RaycastHit hit, 100f))
        {
            Debug.DrawRay(hitPoint, reflectDirection * hit.distance, Color.red);
            MirrorReflect nextMirror = hit.collider.GetComponent<MirrorReflect>();
            if (nextMirror != null)
            {
                nextMirror.ReflectLight(reflectDirection, hit.point, bounceRemain - 1);
            }
            else if (hit.collider.CompareTag("Door") && bounceRemain <= 0)
            {
                print("Unlocked door");
            }
        }
    }

    public void DisableReflection()
    {
        if (mirrorLight != null)
            mirrorLight.SetActive(false);
    }
}
