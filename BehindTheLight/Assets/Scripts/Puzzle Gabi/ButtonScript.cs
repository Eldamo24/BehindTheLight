using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour, IInteractable
{
    [SerializeField] private string onInteractMsg;
    [SerializeField] private Material material;
    [SerializeField] private List<GameObject> boxes;
    private Color startColor;
    private Color endColor;

    public string OnInteractMsg => onInteractMsg;

    private void Start()
    {
        startColor = material.color;
        endColor = Color.green;
    }

    public void OnInteract()
    {
        material.color = endColor;
        gameObject.layer = 0;
        foreach (var box in boxes)
        {
            box.gameObject.SetActive(true);
        }
    }

    private void OnDestroy()
    {
        material.color = startColor;
    }
}
