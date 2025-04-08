using UnityEngine;

public class TestKey : MonoBehaviour, IInteractable
{
    [SerializeField] private string interactMsg;
    public string OnInteractMsg => interactMsg;

    public void OnInteract()
    {
        print("Agarraste la llave");
        Destroy(gameObject);
    }

}
