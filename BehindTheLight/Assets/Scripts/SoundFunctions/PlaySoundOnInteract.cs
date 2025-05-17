using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlaySoundOnInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private AudioClip clip;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private string onInteractMsg;
    public string OnInteractMsg => onInteractMsg;

    AudioSource _src;

    void Awake()
    {
        _src = gameObject.AddComponent<AudioSource>();
        _src.playOnAwake = false;
        _src.spatialBlend = 1f;
        _src.maxDistance = maxDistance;
        _src.rolloffMode = AudioRolloffMode.Linear;
    }

    public void OnInteract()
    {
        if (clip == null) return;
        _src.PlayOneShot(clip);
    }
}